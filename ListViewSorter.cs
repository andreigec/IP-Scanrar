using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;

namespace Scanrar
{
	public class ListViewSorter : System.Collections.IComparer
	{

		public int Compare(object o1, object o2)
		{
			if (!(o1 is ListViewItem))
				return (0);
			if (!(o2 is ListViewItem))
				return (0);

			ListViewItem lvi1 = (ListViewItem)o2;
			string str1 = lvi1.SubItems[ByColumn].Text;
			ListViewItem lvi2 = (ListViewItem)o1;
			string str2 = lvi2.SubItems[ByColumn].Text;

			int result = 0;
			String regip=@"[0-9][0-9]?[0-9]?.[0-9][0-9]?[0-9]?.[0-9][0-9]?[0-9]?.[0-9][0-9]?[0-9]?";

			if (Regex.IsMatch(str1, regip) && Regex.IsMatch(str2, regip))
			{
				uint s1 = pingJob.ipToInt(IPAddress.Parse(str1));
				uint s2 = pingJob.ipToInt(IPAddress.Parse(str2));
				if (lvi1.ListView.Sorting == SortOrder.Ascending)
					result = s1.CompareTo(s2);
				else
					result = s2.CompareTo(s1);
			
			}
			//test to see if the string is a number - perform an int compare instead of a string compare
			else if (Regex.IsMatch(str1, "^[0-9]+$") && Regex.IsMatch(str2, "^[0-9]+$"))
			{
				int s1 = int.Parse(str1);
				int s2 = int.Parse(str2);
				if (lvi1.ListView.Sorting == SortOrder.Ascending)
					result = s1.CompareTo(s2);
				else
					result = s2.CompareTo(s1);
			}
			else
			{
				if (lvi1.ListView.Sorting == SortOrder.Ascending)
					result = String.Compare(str1, str2);
				else
					result = String.Compare(str2, str1);
			}
			

			LastSort = ByColumn;

			return (result);
		}


		public int ByColumn
		{
			get { return Column; }
			set { Column = value; }
		}
		int Column = 0;

		public int LastSort
		{
			get { return LastColumn; }
			set { LastColumn = value; }
		}
		int LastColumn = 0;

	}
}
