using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using ANDREICSLIB;
using Scanrar.ServiceReference1;

namespace Scanrar
{
    public partial class Form1 : Form
    {
        #region licensing

        private const string AppTitle = "IP Scanrar";
        private const double AppVersion = 1;
        private const String HelpString = "";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)

Licensed under GNU LGPL (http://www.gnu.org/)

OCR © Tessnet2/Tesseract (http://www.pixel-technology.com/freeware/tessnet2/)(https://code.google.com/p/tesseract-ocr/)
Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";
        #endregion

        public Boolean scanningInProgress = false;
        Thread t = null;

        public static String enablestr = "Scan all IPs in range";
        public static String disablestr = "Abort Scan";

        public static String scanenabled = "Scanning Progress:";
        public static String scandisabled = "Not Scanning";

        //store this here for every ip scanned
        Dictionary<IPAddress, Dictionary<String, String>> additionalInformation = new Dictionary<IPAddress, Dictionary<string, string>>();

        //initialise sorter here so we have a memory of the last sort (asc or desc)
        ListViewSorter additionalInformationSorter = new ListViewSorter();
        ListViewSorter scannedIPSorter = new ListViewSorter();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //turn off thread safety
            CheckForIllegalCrossThreadCalls = false;

            scanstatustext.Text = scandisabled;
            ipprogress.Visible = false;

            hostnametextbox.Text = Dns.GetHostName();
            hostnameToIP();
            threadsbox.SelectedIndex = 3;
            timeoutz.SelectedIndex = 0;
            scanbutton.Text = enablestr;
            indepthtime.SelectedIndex = 0;

            //TT
            ToolTip TT = new ToolTip();
            TT.SetToolTip(this.threadsbox, "How many targets can be connected to at any one time");

            TT = new ToolTip();
            TT.SetToolTip(this.timeoutz, "How long in milliseconds until the ping request is discarded");

            TT = new ToolTip();
            TT.SetToolTip(this.successonly, "Only show targets that respond successfully to the ping");

            TT = new ToolTip();
            TT.SetToolTip(this.indepthcheck, "Get more information about the target, but takes more time");

            TT = new ToolTip();
            TT.SetToolTip(this.indepthtime, "Getting more info on the target requires more time");

            Licensing.CreateLicense(this, menuStrip1, new Licensing.SolutionDetails(GetDetails, HelpString, AppTitle, AppVersion, OtherText));

        }

        public Licensing.DownloadedSolutionDetails GetDetails()
        {
            try
            {
                var sr = new ServicesClient();
                var ti = sr.GetTitleInfo(AppTitle);
                if (ti == null)
                    return null;
                return ToDownloadedSolutionDetails(ti);

            }
            catch (Exception)
            {
            }
            return null;
        }

        public static Licensing.DownloadedSolutionDetails ToDownloadedSolutionDetails(TitleInfoServiceModel tism)
        {
            return new Licensing.DownloadedSolutionDetails()
            {
                ZipFileLocation = tism.LatestTitleDownloadPath,
                ChangeLog = tism.LatestTitleChangelog,
                Version = tism.LatestTitleVersion
            };
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scanbutton_Click(object sender, EventArgs e)
        {
            IPAddress from = getIP(fromiptextbox.Text, fromiptextbox);
            if (from == null)
                return;

            IPAddress to = getIP(toiptextbox.Text, toiptextbox);
            if (to == null)
                return;

            int threads = getIntFromControl(threadsbox);
            if (threads == -1 || threads == 0)
                return;

            int timeout = getIntFromControl(timeoutz);
            if (timeout == -1)
                return;

            int indepthtimei = -1;
            if (indepthcheck.Checked)
            {
                indepthtimei = getIntFromControl(indepthtime);
            }

            uint toi = pingJob.ipToInt(to);
            uint fromi = pingJob.ipToInt(from);

            if (fromi > toi)
            {
                fromiptextbox.BackColor = Color.Red;
                toiptextbox.BackColor = Color.Red;
                return;
            }

            scanningInProgress = !scanningInProgress;

            if (scanningInProgress)
            {
                startScan(from, fromi, to, toi, threads, timeout, indepthtimei);
            }
            else
            {
                //stop the timer
                t.Abort();
                t = null;

                endScan();
            }

            if (scanningInProgress)
                scanbutton.Text = disablestr;
            else
                scanbutton.Text = enablestr;
        }

        private void endScan()
        {
            scanbutton.Text = enablestr;
            timer1.Enabled = false;
            scanningInProgress = false;
            ipprogress.Value = 0;

            scanstatustext.Text = scandisabled;
            ipnum.Text = "";
            ipprogress.Visible = false;

            if (sortfinish.Checked)
            {
                results.Sorting = SortOrder.Ascending;
                columnSort(scannedIPSorter, results, 1);
            }

        }

        private void startScan(IPAddress from, uint fromi, IPAddress to, uint toi, int threads, int timeout, int indepthtime)
        {
            pingJob.threadcontrollerinfo TCI = new pingJob.threadcontrollerinfo();
            TCI.from = from;
            TCI.to = to;
            TCI.threads = threads;
            TCI.timeout = timeout;
            TCI.baseform = this;
            TCI.successOnly = successonly.Checked;

            if (indepthtime == -1)
                TCI.performIndepth = false;
            else
            {
                TCI.performIndepth = true;
                TCI.indepthTimeout = indepthtime;
            }

            t = new Thread(new ParameterizedThreadStart(pingJob.start));
            t.Start(TCI);

            timer1.Enabled = true;

            //progress
            ipprogress.Maximum = (int)(toi - fromi) + 1;
            ipprogress.Step = ipprogress.Maximum / 10;
            ipprogress.Value = 0;

            scanstatustext.Text = scanenabled;
            ipprogress.Visible = true;

        }


        private void fromiptextbox_TextChanged(object sender, EventArgs e)
        {
            fromiptextbox.BackColor = Color.White;
        }

        private void toiptextbox_TextChanged(object sender, EventArgs e)
        {
            toiptextbox.BackColor = Color.White;
        }

        private void toiptextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && e.KeyChar > 32 && e.KeyChar < 127 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void fromiptextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && e.KeyChar > 32 && e.KeyChar < 127 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }


        public void hostnameToIP()
        {
            var hn = NetExtras.GetHostName();
            var ip = ANDREICSLIB.NetExtras.HostnameToIP(hn).ToString();
            try
            {
                fromiptextbox.Text = ip;
                toiptextbox.Text = ip;
            }
            catch
            {
                hostnametextbox.BackColor = Color.Red;
            }
        }

        private void extractip_Click(object sender, EventArgs e)
        {
            hostnameToIP();
        }

        private void hostnametextbox_TextChanged(object sender, EventArgs e)
        {
            hostnametextbox.BackColor = Color.White;
        }

        private void toclassC_Click(object sender, EventArgs e)
        {
            IPAddress ip = null;
            ip = getIP(fromiptextbox.Text, fromiptextbox);
            if (ip == null)
                return;

            IPAddress ip2 = null;
            ip2 = getIP(toiptextbox.Text, toiptextbox);
            if (ip2 == null)
                return;

            String from = ip.ToString();
            from = chopDot(from);

            from = from + ".1";

            String to = ip2.ToString();
            to = chopDot(to);
            to = to + ".255";

            fromiptextbox.Text = from;
            toiptextbox.Text = to;

        }

        public String chopDot(String s)
        {

            String a = s;
            try
            {
                a = s.Substring(0, s.LastIndexOf('.'));
            }
            catch
            {
            }

            return a;
        }

        public IPAddress getIP(String textz, Control c)
        {
            IPAddress ip = null;
            try
            {
                ip = IPAddress.Parse(textz);
                c.BackColor = Color.White;
            }
            catch
            {
                c.BackColor = Color.Red;
            }
            return ip;
        }

        public int getIntFromControl(Control TB)
        {
            int ret = -1;
            try
            {
                ret = int.Parse(TB.Text);
                TB.BackColor = Color.White;
            }
            catch
            {
                ret = -1;
                TB.BackColor = Color.Red;
            }
            return ret;
        }

        private void toclassB_Click(object sender, EventArgs e)
        {
            IPAddress ip = null;
            ip = getIP(fromiptextbox.Text, fromiptextbox);
            if (ip == null)
                return;

            IPAddress ip2 = null;
            ip2 = getIP(toiptextbox.Text, toiptextbox);
            if (ip2 == null)
                return;

            String from = ip.ToString();
            from = chopDot(from);
            from = chopDot(from);

            from = from + ".0.1";

            String to = ip2.ToString();
            to = chopDot(to);
            to = chopDot(to);
            to = to + ".255.255";

            fromiptextbox.Text = from;
            toiptextbox.Text = to;
        }

        private void toclassA_Click(object sender, EventArgs e)
        {
            IPAddress ip = null;
            ip = getIP(fromiptextbox.Text, fromiptextbox);
            if (ip == null)
                return;

            IPAddress ip2 = null;
            ip2 = getIP(toiptextbox.Text, toiptextbox);
            if (ip2 == null)
                return;

            String from = ip.ToString();
            from = chopDot(from);
            from = chopDot(from);
            from = chopDot(from);

            from = from + ".0.0.1";

            String to = ip2.ToString();
            to = chopDot(to);
            to = chopDot(to);
            to = chopDot(to);
            to = to + ".255.255.255";

            fromiptextbox.Text = from;
            toiptextbox.Text = to;
        }



        private void threadsbox_TextChanged(object sender, EventArgs e)
        {
            threadsbox.BackColor = Color.White;
        }

        // add ip info result
        public void addResult(ListViewItem LVI)
        {
            if (results.Items.ContainsKey(LVI.Text))
                results.Items.RemoveByKey(LVI.Text);
            results.Items.Add(LVI);
        }

        public delegate void addResultCallback(ListViewItem LVI);
        /////////

        public delegate void addAdditionalInformationCallback(IPAddress ip, Dictionary<String, String> info);

        public void addAdditionalInformation(IPAddress ip, Dictionary<String, String> info)
        {
            if (additionalInformation.ContainsKey(ip) == false)
                additionalInformation.Add(ip, info);
        }
        //////////


        /////////
        public delegate void increaseIPProgressCallback();

        public void increaseIPProgress()
        {
            if (scanningInProgress)
            {
                ipprogress.Value++;
                ipnum.Text = "(" + ipprogress.Value + "/" + ipprogress.Maximum + ")";
            }
        }
        /////////

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t == null || t.IsAlive == false)
            {
                endScan();

            }

        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            results.Items.Clear();
            additionalInformation.Clear();
            indepthlist.Items.Clear();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null)
                t.Abort();
        }

        private void results_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (results.SelectedItems.Count != 1)
            {
                indepthlist.Items.Clear();
                return;
            }

            indepthlist.Items.Clear();

            try
            {
                String ipStr = results.SelectedItems[0].Text;
                IPAddress ip = IPAddress.Parse(ipStr);

                Dictionary<String, String> res = additionalInformation[ip];

                foreach (KeyValuePair<String, String> resv in res)
                {
                    ListViewItem LVI = new ListViewItem();
                    LVI.Text = resv.Key;
                    LVI.SubItems.Add(resv.Value);

                    indepthlist.Items.Add(LVI);
                }

            }
            catch
            {
            }
        }

        private void indepthlist_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            columnSort(additionalInformationSorter, indepthlist, e.Column);

        }

        private void results_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            columnSort(scannedIPSorter, results, e.Column);
        }

        public static void columnSort(ListViewSorter LVS, ListView LV, int column)
        {
            LV.ListViewItemSorter = LVS;
            if (!(LV.ListViewItemSorter is ListViewSorter))
                return;
            LVS = (ListViewSorter)LV.ListViewItemSorter;

            if (LV.Sorting == SortOrder.Ascending)
                LV.Sorting = SortOrder.Descending;
            else
                LV.Sorting = SortOrder.Ascending;

            LVS.ByColumn = column;

            LV.Sort();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ipresultsrightclick_Opening(object sender, CancelEventArgs e)
        {
            if (results.SelectedItems.Count != 1)
                e.Cancel = true;
        }

        private void copyToIPRangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String iptext = results.SelectedItems[0].Text;
            fromiptextbox.Text = iptext;
            toiptextbox.Text = iptext;
        }




    }
}