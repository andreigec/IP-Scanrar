using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;
using System.Management;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.DirectoryServices ;

namespace Scanrar
{
	public class pingJob
	{

		private static object thisLock = new object();
	
		public class threadcontrollerinfo
		{
			public IPAddress from;
			public IPAddress to;

			public int threads;
			//number of threads in use by app
			public int threadCount = 0;

			public int timeout = 0;
			//extra info
			public Boolean performIndepth = false;
			public int indepthTimeout = 0;


			//reference to the main form
			public Form1 baseform;

			//only submit successfull pings
			public Boolean successOnly;

			//use for getting ips back in order
			private  uint lastIP;
			
			public void setLastIP(uint val)
			{
				lastIP = val;
			}

			public void addLastIP()
			{
				lastIP++;
			}

			public uint getLastIP()
			{
					return lastIP;
			}

			
			//abort threads
			public Boolean abortThreads;

			//all the threads created
			public List<Thread> createdThreads = new List<Thread>();


		}

		public static uint ipToInt(IPAddress ipa)
		{
			byte[] byteIP = ipa.GetAddressBytes();

			uint ip = (uint)byteIP[0] << 24;
			ip += (uint)byteIP[1] << 16;
			ip += (uint)byteIP[2] << 8;
			ip += (uint)byteIP[3];

			return ip;
		}



		//thread manager
		public static void start(object maininfoOB)
		{
			threadcontrollerinfo maininfo = (threadcontrollerinfo)maininfoOB;
			uint starti = ipToInt(maininfo.from);
			uint endi = ipToInt(maininfo.to);

			uint current = starti;

			List<IPAddress> todo = new List<IPAddress>();
			while (current <= endi)
			{
				IPAddress ipa = IPAddress.Parse(current.ToString());
				todo.Add(ipa);

				current++;
			}

			jobThread(todo, maininfo);
		}

		public delegate void abortScanCallback();

		public static void abortScan(threadcontrollerinfo TCI)
		{
			foreach (Thread t in TCI.createdThreads)
			{
				t.Abort();
			}
		}


		private static void jobThread(List<IPAddress> todo, threadcontrollerinfo TCI)
		{
			TCI.setLastIP(ipToInt(TCI.from));

			try
			{
				foreach (IPAddress ip in todo)
				{
				retry:

					if (TCI.threadCount < TCI.threads)
					{
						Thread t = new Thread(new ParameterizedThreadStart(threadPingJob));
						threadinfo ti = new threadinfo();
						ti.ip = ip;
						ti.TCI = TCI;

						TCI.threadCount++;
						t.Start(ti);
						TCI.createdThreads.Add(t);
					}
					else
					{
						Thread.Sleep(100);
						goto retry;
					}
				}

				while (TCI.threadCount > 0)
				{
					Thread.Sleep(100);
				}

			}
			catch (ThreadAbortException)
			{
				abortScan(TCI);
				return;
			}
		}

		public class threadinfo
		{
			public IPAddress ip;
			public threadcontrollerinfo TCI;
		}

		//threads
		static void threadPingJob(object threadinfoOB)
		{
			threadinfo ti = null;
			try
			{
			ti = (threadinfo)threadinfoOB;
			Ping p = null;
			PingReply PR = null;
			IPHostEntry IPHE = null;
			
			
				p = new Ping();
				PR = p.Send(ti.ip, ti.TCI.timeout);

				uint thisipuint = ipToInt(ti.ip);
			
					ti.TCI.addLastIP();
				
				//only add results depending on ping status, and client result filtering
				if ((ti.TCI.successOnly == true && PR.Status == IPStatus.Success) || ti.TCI.successOnly == false)
				{
					IPHE = Dns.GetHostByName(ti.ip.ToString());

					System.Windows.Forms.ListViewItem LVI = new System.Windows.Forms.ListViewItem();
					LVI.Text = ti.ip.ToString();
					LVI.Name = ti.ip.ToString();

					LVI.SubItems.Add(IPHE.HostName);
					LVI.SubItems.Add(PR.Status.ToString());

					if (PR.Status == IPStatus.Success)
						LVI.SubItems.Add(PR.RoundtripTime.ToString());

						ti.TCI.baseform.Invoke(new Form1.addResultCallback(ti.TCI.baseform.addResult),LVI);
					

					//additional info
					if (ti.TCI.performIndepth)
					{
						Dictionary<String, String> res = getRemoteInfo(ti.ip, IPHE.HostName, ti.TCI.indepthTimeout);

						if (res == null)
							res = new Dictionary<string, string>();

						res.Add("MAC Address", getMAC(ti.ip));

						WKSTA_INFO_100 infocl = getMachineNetBiosInfo(ti.ip);

						if (infocl != null)
						{
							res.Add("Computer Name", infocl.wki100_computername);
							res.Add("Group Name", infocl.wki100_langroup);
						}

						ti.TCI.baseform.Invoke(new Form1.addAdditionalInformationCallback(ti.TCI.baseform.addAdditionalInformation), ti.ip, res);
					}

					
				}
				ti.TCI.baseform.Invoke(new Form1.increaseIPProgressCallback(ti.TCI.baseform.increaseIPProgress));
					
				ti.TCI.threadCount--;
			
			}

			catch (Exception)
			{
				if (ti!=null)
				ti.TCI.threadCount--;
				return;
			}
		}


		//mac
		[DllImport("iphlpapi.dll", ExactSpelling = true)]

		static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

		public static String getMAC(IPAddress ip)
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(ip);

				if (hostEntry.AddressList.Length == 0)
					return null;

				byte[] macAddr = new byte[6];
				uint macAddrLen = (uint)macAddr.Length;
				
				if (SendARP((int)hostEntry.AddressList[0].Address, 0, macAddr,ref macAddrLen) != 0)
					return null;

				StringBuilder macAddressString = new StringBuilder();
				for (int i = 0; i < macAddr.Length; i++)
				{
					if (macAddressString.Length > 0)
						macAddressString.Append(":");
					macAddressString.AppendFormat("{0:x2}", macAddr[i]);
				}

				return macAddressString.ToString();
			}
			catch
			{
				return null;
			}

			}

		//group name/domain name/work group/ whatever its called
			[DllImport("netapi32.dll", CharSet = CharSet.Auto)]
			static extern int NetWkstaGetInfo(string server,
				int level,
				out IntPtr info);

			[DllImport("netapi32.dll")]
			static extern int NetApiBufferFree(IntPtr pBuf);

			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
			public class WKSTA_INFO_100
			{
				public int wki100_platform_id;
				[MarshalAs(UnmanagedType.LPWStr)]
				public string wki100_computername;
				[MarshalAs(UnmanagedType.LPWStr)]
				public string wki100_langroup;
				public int wki100_ver_major;
				public int wki100_ver_minor;
			}

		public static WKSTA_INFO_100 getMachineNetBiosInfo(IPAddress ip)
			{
			IPHostEntry hostEntry = Dns.GetHostEntry(ip);

				if (hostEntry.AddressList.Length == 0)
					return null;

				IntPtr pBuffer = IntPtr.Zero;

				int retval = NetWkstaGetInfo(ip.ToString(), 100, out pBuffer);
				if (retval != 0)
					return null;

				return (WKSTA_INFO_100)Marshal.PtrToStructure(pBuffer, typeof(WKSTA_INFO_100));
				
			}


		
		//admin rights required
		public static Dictionary<String, String> getRemoteInfo(IPAddress ip, String hostname,int extraInfoTimeout)
		{
			ConnectionOptions options = new ConnectionOptions();
			options.Impersonation = ImpersonationLevel.Impersonate;
			options.Authentication = AuthenticationLevel.None;

			int s = extraInfoTimeout;

			int H = s * 3600;
			s -= H * 3600;

			int M = s / 60;
			s -= M * 60;

			int S = s;

			DateTime startTime = DateTime.Now;


			options.Timeout = new TimeSpan(H, M, S);

			ManagementScope scope = new ManagementScope("\\\\" + ip.ToString() + "\\root\\cimv2");
			try
			{
				//admin rights?
				scope.Connect();
				if (scope.IsConnected == false)
					return null;
			}
			catch
			{
				return null;
			}

			//Query system for Operating System information      
			ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

			// To get information about Logical Disks on Computer

			SelectQuery query1 = new SelectQuery("Select * from Win32_LogicalDisk");

			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
			ManagementObjectCollection queryCollection = searcher.Get();

			ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(scope, query1);
			ManagementObjectCollection queryCollection1 = searcher1.Get();

			Dictionary<String, String> results = new Dictionary<string, string>();

			foreach (ManagementBaseObject envVar in searcher.Get())
			{
				foreach (PropertyData PD in envVar.Properties)
				{
					DateTime currentTime = DateTime.Now;
					TimeSpan TS = currentTime - startTime;

					if (TS.TotalSeconds > extraInfoTimeout)
					{
						return results;
					}

					if (PD.Name != null && PD.Value != null && results.ContainsKey(PD.Name.ToString()) == false)
						results.Add(PD.Name.ToString(), PD.Value.ToString());
				}
			}

			foreach (ManagementBaseObject envVar in searcher1.Get())
			{
				DateTime currentTime = DateTime.Now;
				TimeSpan TS = currentTime - startTime;

				if (TS.TotalSeconds > extraInfoTimeout)
				{
					return results;
				}

				foreach (PropertyData PD in envVar.Properties)
				{
					if (PD.Name != null && PD.Value != null && results.ContainsKey(PD.Name.ToString()) == false)
						results.Add(PD.Name.ToString(), PD.Value.ToString());
				}
			}
			return results;
		}
	}
}
