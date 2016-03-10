namespace Scanrar
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromiptextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toiptextbox = new System.Windows.Forms.TextBox();
            this.scanbutton = new System.Windows.Forms.Button();
            this.hostnametextbox = new System.Windows.Forms.TextBox();
            this.extractip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toclassA = new System.Windows.Forms.Button();
            this.toclassB = new System.Windows.Forms.Button();
            this.toclassC = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sortfinish = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.indepthtime = new System.Windows.Forms.ComboBox();
            this.indepthcheck = new System.Windows.Forms.CheckBox();
            this.successonly = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timeoutz = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.threadsbox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clearbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pingreturn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Latency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.results = new System.Windows.Forms.ListView();
            this.hostnamecolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipresultsrightclick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToIPRangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.scanstatustext = new System.Windows.Forms.ToolStripStatusLabel();
            this.ipprogress = new System.Windows.Forms.ToolStripProgressBar();
            this.ipnum = new System.Windows.Forms.ToolStripStatusLabel();
            this.indepthlist = new System.Windows.Forms.ListView();
            this.keycol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valcol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ipresultsrightclick.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fromiptextbox
            // 
            this.fromiptextbox.Location = new System.Drawing.Point(64, 11);
            this.fromiptextbox.MaxLength = 15;
            this.fromiptextbox.Name = "fromiptextbox";
            this.fromiptextbox.Size = new System.Drawing.Size(93, 20);
            this.fromiptextbox.TabIndex = 1;
            this.fromiptextbox.Text = "127.0.0.1";
            this.fromiptextbox.TextChanged += new System.EventHandler(this.fromiptextbox_TextChanged);
            this.fromiptextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromiptextbox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP Range:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "to";
            // 
            // toiptextbox
            // 
            this.toiptextbox.Location = new System.Drawing.Point(185, 11);
            this.toiptextbox.MaxLength = 15;
            this.toiptextbox.Name = "toiptextbox";
            this.toiptextbox.Size = new System.Drawing.Size(93, 20);
            this.toiptextbox.TabIndex = 5;
            this.toiptextbox.Text = "127.0.0.2";
            this.toiptextbox.TextChanged += new System.EventHandler(this.toiptextbox_TextChanged);
            this.toiptextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toiptextbox_KeyPress);
            // 
            // scanbutton
            // 
            this.scanbutton.Location = new System.Drawing.Point(6, 285);
            this.scanbutton.Name = "scanbutton";
            this.scanbutton.Size = new System.Drawing.Size(184, 23);
            this.scanbutton.TabIndex = 7;
            this.scanbutton.Text = "x";
            this.scanbutton.UseVisualStyleBackColor = true;
            this.scanbutton.Click += new System.EventHandler(this.scanbutton_Click);
            // 
            // hostnametextbox
            // 
            this.hostnametextbox.Location = new System.Drawing.Point(64, 64);
            this.hostnametextbox.Name = "hostnametextbox";
            this.hostnametextbox.Size = new System.Drawing.Size(100, 20);
            this.hostnametextbox.TabIndex = 7;
            this.hostnametextbox.TextChanged += new System.EventHandler(this.hostnametextbox_TextChanged);
            // 
            // extractip
            // 
            this.extractip.Location = new System.Drawing.Point(170, 64);
            this.extractip.Name = "extractip";
            this.extractip.Size = new System.Drawing.Size(108, 20);
            this.extractip.TabIndex = 8;
            this.extractip.Text = "Copy IP To Range";
            this.extractip.UseVisualStyleBackColor = true;
            this.extractip.Click += new System.EventHandler(this.extractip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hostname:";
            // 
            // toclassA
            // 
            this.toclassA.Location = new System.Drawing.Point(6, 38);
            this.toclassA.Name = "toclassA";
            this.toclassA.Size = new System.Drawing.Size(60, 20);
            this.toclassA.TabIndex = 11;
            this.toclassA.Text = "Class A";
            this.toclassA.UseVisualStyleBackColor = true;
            this.toclassA.Click += new System.EventHandler(this.toclassA_Click);
            // 
            // toclassB
            // 
            this.toclassB.Location = new System.Drawing.Point(72, 38);
            this.toclassB.Name = "toclassB";
            this.toclassB.Size = new System.Drawing.Size(55, 20);
            this.toclassB.TabIndex = 13;
            this.toclassB.Text = "Class B";
            this.toclassB.UseVisualStyleBackColor = true;
            this.toclassB.Click += new System.EventHandler(this.toclassB_Click);
            // 
            // toclassC
            // 
            this.toclassC.Location = new System.Drawing.Point(133, 38);
            this.toclassC.Name = "toclassC";
            this.toclassC.Size = new System.Drawing.Size(56, 20);
            this.toclassC.TabIndex = 14;
            this.toclassC.Text = "Class C";
            this.toclassC.UseVisualStyleBackColor = true;
            this.toclassC.Click += new System.EventHandler(this.toclassC_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sortfinish);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.indepthtime);
            this.groupBox1.Controls.Add(this.indepthcheck);
            this.groupBox1.Controls.Add(this.successonly);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.timeoutz);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.threadsbox);
            this.groupBox1.Location = new System.Drawing.Point(6, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 189);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // sortfinish
            // 
            this.sortfinish.AutoSize = true;
            this.sortfinish.Checked = true;
            this.sortfinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortfinish.Location = new System.Drawing.Point(10, 99);
            this.sortfinish.Name = "sortfinish";
            this.sortfinish.Size = new System.Drawing.Size(119, 17);
            this.sortfinish.TabIndex = 30;
            this.sortfinish.Text = "Sort When Finished";
            this.sortfinish.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "In-Depth Timeout(S):";
            // 
            // indepthtime
            // 
            this.indepthtime.FormattingEnabled = true;
            this.indepthtime.Items.AddRange(new object[] {
            "10",
            "60",
            "600",
            "3600"});
            this.indepthtime.Location = new System.Drawing.Point(160, 144);
            this.indepthtime.Name = "indepthtime";
            this.indepthtime.Size = new System.Drawing.Size(69, 21);
            this.indepthtime.TabIndex = 28;
            // 
            // indepthcheck
            // 
            this.indepthcheck.AutoSize = true;
            this.indepthcheck.Location = new System.Drawing.Point(10, 122);
            this.indepthcheck.Name = "indepthcheck";
            this.indepthcheck.Size = new System.Drawing.Size(186, 17);
            this.indepthcheck.TabIndex = 27;
            this.indepthcheck.Text = "Get In-Depth Information About IP";
            this.indepthcheck.UseVisualStyleBackColor = true;
            // 
            // successonly
            // 
            this.successonly.AutoSize = true;
            this.successonly.Location = new System.Drawing.Point(10, 76);
            this.successonly.Name = "successonly";
            this.successonly.Size = new System.Drawing.Size(194, 17);
            this.successonly.TabIndex = 25;
            this.successonly.Text = "Only Show Successful Connections";
            this.successonly.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Timeout(MS):";
            // 
            // timeoutz
            // 
            this.timeoutz.FormattingEnabled = true;
            this.timeoutz.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000"});
            this.timeoutz.Location = new System.Drawing.Point(82, 49);
            this.timeoutz.Name = "timeoutz";
            this.timeoutz.Size = new System.Drawing.Size(69, 21);
            this.timeoutz.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Threads:";
            // 
            // threadsbox
            // 
            this.threadsbox.FormattingEnabled = true;
            this.threadsbox.Items.AddRange(new object[] {
            "1",
            "10",
            "50",
            "100"});
            this.threadsbox.Location = new System.Drawing.Point(82, 22);
            this.threadsbox.Name = "threadsbox";
            this.threadsbox.Size = new System.Drawing.Size(69, 21);
            this.threadsbox.TabIndex = 0;
            this.threadsbox.TextChanged += new System.EventHandler(this.threadsbox_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clearbutton
            // 
            this.clearbutton.Location = new System.Drawing.Point(196, 285);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(82, 23);
            this.clearbutton.TabIndex = 18;
            this.clearbutton.Text = "Clear Results";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.clearbutton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.clearbutton);
            this.panel1.Controls.Add(this.hostnametextbox);
            this.panel1.Controls.Add(this.extractip);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.toiptextbox);
            this.panel1.Controls.Add(this.toclassA);
            this.panel1.Controls.Add(this.toclassB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.toclassC);
            this.panel1.Controls.Add(this.fromiptextbox);
            this.panel1.Controls.Add(this.scanbutton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 454);
            this.panel1.TabIndex = 20;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 133;
            // 
            // pingreturn
            // 
            this.pingreturn.Text = "Ping Status";
            this.pingreturn.Width = 76;
            // 
            // Latency
            // 
            this.Latency.Text = "Latency";
            // 
            // results
            // 
            this.results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.hostnamecolumn,
            this.pingreturn,
            this.Latency});
            this.results.ContextMenuStrip = this.ipresultsrightclick;
            this.results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.results.FullRowSelect = true;
            this.results.Location = new System.Drawing.Point(291, 24);
            this.results.MultiSelect = false;
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(374, 454);
            this.results.TabIndex = 15;
            this.results.UseCompatibleStateImageBehavior = false;
            this.results.View = System.Windows.Forms.View.Details;
            this.results.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.results_ColumnClick);
            this.results.SelectedIndexChanged += new System.EventHandler(this.results_SelectedIndexChanged);
            // 
            // hostnamecolumn
            // 
            this.hostnamecolumn.Text = "Hostname";
            this.hostnamecolumn.Width = 100;
            // 
            // ipresultsrightclick
            // 
            this.ipresultsrightclick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToIPRangesToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.ipresultsrightclick.Name = "ipresultsrightclick";
            this.ipresultsrightclick.Size = new System.Drawing.Size(174, 48);
            this.ipresultsrightclick.Opening += new System.ComponentModel.CancelEventHandler(this.ipresultsrightclick_Opening);
            // 
            // copyToIPRangesToolStripMenuItem
            // 
            this.copyToIPRangesToolStripMenuItem.Name = "copyToIPRangesToolStripMenuItem";
            this.copyToIPRangesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyToIPRangesToolStripMenuItem.Text = "Copy To IP Ranges";
            this.copyToIPRangesToolStripMenuItem.Click += new System.EventHandler(this.copyToIPRangesToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Silver;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanstatustext,
            this.ipprogress,
            this.ipnum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(965, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // scanstatustext
            // 
            this.scanstatustext.Name = "scanstatustext";
            this.scanstatustext.Size = new System.Drawing.Size(62, 17);
            this.scanstatustext.Text = "scanstatus";
            // 
            // ipprogress
            // 
            this.ipprogress.Name = "ipprogress";
            this.ipprogress.Size = new System.Drawing.Size(100, 16);
            // 
            // ipnum
            // 
            this.ipnum.Name = "ipnum";
            this.ipnum.Size = new System.Drawing.Size(0, 17);
            // 
            // indepthlist
            // 
            this.indepthlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.keycol,
            this.valcol});
            this.indepthlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indepthlist.FullRowSelect = true;
            this.indepthlist.Location = new System.Drawing.Point(0, 24);
            this.indepthlist.MultiSelect = false;
            this.indepthlist.Name = "indepthlist";
            this.indepthlist.Size = new System.Drawing.Size(300, 430);
            this.indepthlist.TabIndex = 2;
            this.indepthlist.UseCompatibleStateImageBehavior = false;
            this.indepthlist.View = System.Windows.Forms.View.Details;
            this.indepthlist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.indepthlist_ColumnClick);
            // 
            // keycol
            // 
            this.keycol.Text = "Key";
            this.keycol.Width = 100;
            // 
            // valcol
            // 
            this.valcol.Text = "Value";
            this.valcol.Width = 300;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 24);
            this.panel3.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "In Depth IP Selection Information";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Silver;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(660, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 454);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.indepthlist);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(665, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 454);
            this.panel4.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 500);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.results);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IP Scanrar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ipresultsrightclick.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TextBox fromiptextbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox toiptextbox;
		private System.Windows.Forms.Button scanbutton;
		private System.Windows.Forms.TextBox hostnametextbox;
		private System.Windows.Forms.Button extractip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button toclassA;
		private System.Windows.Forms.Button toclassB;
		private System.Windows.Forms.Button toclassC;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox threadsbox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox timeoutz;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button clearbutton;
        private System.Windows.Forms.CheckBox successonly;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ColumnHeader IP;
		private System.Windows.Forms.ColumnHeader pingreturn;
		private System.Windows.Forms.ColumnHeader Latency;
		private System.Windows.Forms.ListView results;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar ipprogress;
		private System.Windows.Forms.ToolStripStatusLabel scanstatustext;
		private System.Windows.Forms.ColumnHeader hostnamecolumn;
		private System.Windows.Forms.CheckBox indepthcheck;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox indepthtime;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListView indepthlist;
		private System.Windows.Forms.ColumnHeader keycol;
		private System.Windows.Forms.ColumnHeader valcol;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ContextMenuStrip ipresultsrightclick;
		private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToIPRangesToolStripMenuItem;
		private System.Windows.Forms.CheckBox sortfinish;
		private System.Windows.Forms.ToolStripStatusLabel ipnum;
	}
}

