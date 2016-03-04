namespace TaskAllocator
{
    partial class frmMain
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainerTask = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbMaxSrcPerDay = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.txtTaskFile = new System.Windows.Forms.ToolStripTextBox();
            this.btnBrouse = new System.Windows.Forms.ToolStripButton();
            this.btnAnalyze = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer20 = new System.Windows.Forms.SplitContainer();
            this.splitContainer21 = new System.Windows.Forms.SplitContainer();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.splitContainer22 = new System.Windows.Forms.SplitContainer();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTask)).BeginInit();
            this.splitContainerTask.Panel1.SuspendLayout();
            this.splitContainerTask.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer20)).BeginInit();
            this.splitContainer20.Panel1.SuspendLayout();
            this.splitContainer20.Panel2.SuspendLayout();
            this.splitContainer20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer21)).BeginInit();
            this.splitContainer21.Panel1.SuspendLayout();
            this.splitContainer21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer22)).BeginInit();
            this.splitContainer22.Panel1.SuspendLayout();
            this.splitContainer22.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.splitContainer2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1346, 534);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "任务及资源调度分析器";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 17);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainerTask);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer20);
            this.splitContainer2.Size = new System.Drawing.Size(1340, 514);
            this.splitContainer2.SplitterDistance = 627;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainerTask
            // 
            this.splitContainerTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTask.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTask.Name = "splitContainerTask";
            this.splitContainerTask.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTask.Panel1
            // 
            this.splitContainerTask.Panel1.Controls.Add(this.groupBox1);
            this.splitContainerTask.Panel1.Controls.Add(this.toolStrip);
            this.splitContainerTask.Panel1.Controls.Add(this.label9);
            // 
            // splitContainerTask.Panel2
            // 
            this.splitContainerTask.Panel2.SizeChanged += new System.EventHandler(this.splitContainerTask_Panel2_SizeChanged);
            this.splitContainerTask.Size = new System.Drawing.Size(627, 514);
            this.splitContainerTask.SplitterDistance = 87;
            this.splitContainerTask.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(77, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 62);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务基本信息";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(400, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "最晚结束时间：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 38;
            this.label10.Text = "最具性价比任务：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "平均每个任务的收益：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "总任务数vs总工作量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "最早结束时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "最早开始时间：";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cbMaxSrcPerDay,
            this.toolStripLabel4,
            this.txtTaskFile,
            this.btnBrouse,
            this.btnAnalyze,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(77, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(550, 25);
            this.toolStrip.TabIndex = 32;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(140, 22);
            this.toolStripLabel2.Text = "请输入每天最多工作量：";
            // 
            // cbMaxSrcPerDay
            // 
            this.cbMaxSrcPerDay.Items.AddRange(new object[] {
            "20",
            "30",
            "40"});
            this.cbMaxSrcPerDay.Name = "cbMaxSrcPerDay";
            this.cbMaxSrcPerDay.Size = new System.Drawing.Size(75, 25);
            this.cbMaxSrcPerDay.Text = "30";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel4.Text = "请输入任务文件:";
            // 
            // txtTaskFile
            // 
            this.txtTaskFile.Name = "txtTaskFile";
            this.txtTaskFile.Size = new System.Drawing.Size(80, 25);
            this.txtTaskFile.ToolTipText = "输入完整的文件路径";
            // 
            // btnBrouse
            // 
            this.btnBrouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrouse.Name = "btnBrouse";
            this.btnBrouse.Size = new System.Drawing.Size(60, 22);
            this.btnBrouse.Text = "浏览文件";
            this.btnBrouse.ToolTipText = "浏览文件，通过点击此按钮查找待上传的报表文件";
            this.btnBrouse.Click += new System.EventHandler(this.btnBrouse_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(36, 22);
            this.btnAnalyze.Text = "分析";
            this.btnAnalyze.ToolTipText = "上传";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "资源及任务：";
            // 
            // splitContainer20
            // 
            this.splitContainer20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer20.Location = new System.Drawing.Point(0, 0);
            this.splitContainer20.Name = "splitContainer20";
            this.splitContainer20.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer20.Panel1
            // 
            this.splitContainer20.Panel1.Controls.Add(this.splitContainer21);
            // 
            // splitContainer20.Panel2
            // 
            this.splitContainer20.Panel2.Controls.Add(this.splitContainer22);
            this.splitContainer20.Size = new System.Drawing.Size(709, 514);
            this.splitContainer20.SplitterDistance = 222;
            this.splitContainer20.TabIndex = 0;
            // 
            // splitContainer21
            // 
            this.splitContainer21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer21.Location = new System.Drawing.Point(0, 0);
            this.splitContainer21.Name = "splitContainer21";
            this.splitContainer21.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer21.Panel1
            // 
            this.splitContainer21.Panel1.Controls.Add(this.label14);
            this.splitContainer21.Panel1.Controls.Add(this.label15);
            this.splitContainer21.Panel1.Controls.Add(this.label2);
            this.splitContainer21.Panel1.Controls.Add(this.label1);
            this.splitContainer21.Panel1.Controls.Add(this.label11);
            // 
            // splitContainer21.Panel2
            // 
            this.splitContainer21.Panel2.SizeChanged += new System.EventHandler(this.splitContainer21_Panel2_SizeChanged);
            this.splitContainer21.Size = new System.Drawing.Size(709, 222);
            this.splitContainer21.SplitterDistance = 60;
            this.splitContainer21.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 12);
            this.label14.TabIndex = 35;
            this.label14.Text = "本方案结束时间为：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "本方案开始时间为：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "本方案收益率为：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "本方案绝对收益为：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "最大绝对收益方案：";
            // 
            // splitContainer22
            // 
            this.splitContainer22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer22.Location = new System.Drawing.Point(0, 0);
            this.splitContainer22.Name = "splitContainer22";
            this.splitContainer22.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer22.Panel1
            // 
            this.splitContainer22.Panel1.Controls.Add(this.label16);
            this.splitContainer22.Panel1.Controls.Add(this.label17);
            this.splitContainer22.Panel1.Controls.Add(this.label3);
            this.splitContainer22.Panel1.Controls.Add(this.label4);
            this.splitContainer22.Panel1.Controls.Add(this.label12);
            // 
            // splitContainer22.Panel2
            // 
            this.splitContainer22.Panel2.SizeChanged += new System.EventHandler(this.splitContainer22_Panel2_SizeChanged);
            this.splitContainer22.Size = new System.Drawing.Size(709, 288);
            this.splitContainer22.SplitterDistance = 68;
            this.splitContainer22.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(224, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "本方案结束时间为：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 12);
            this.label17.TabIndex = 36;
            this.label17.Text = "本方案开始时间为：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "本方案收益率为：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "本方案绝对收益为：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "最大收益率方案：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1346, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(196, 17);
            this.toolStripStatusLabel1.Text = "总计方案数：（1，n）C（N，i）=";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 534);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Name = "frmMain";
            this.Text = "TaskAllocator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.groupBox5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainerTask.Panel1.ResumeLayout(false);
            this.splitContainerTask.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTask)).EndInit();
            this.splitContainerTask.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer20.Panel1.ResumeLayout(false);
            this.splitContainer20.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer20)).EndInit();
            this.splitContainer20.ResumeLayout(false);
            this.splitContainer21.Panel1.ResumeLayout(false);
            this.splitContainer21.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer21)).EndInit();
            this.splitContainer21.ResumeLayout(false);
            this.splitContainer22.Panel1.ResumeLayout(false);
            this.splitContainer22.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer22)).EndInit();
            this.splitContainer22.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainerTask;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SplitContainer splitContainer20;
        private System.Windows.Forms.SplitContainer splitContainer21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer22;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbMaxSrcPerDay;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox txtTaskFile;
        private System.Windows.Forms.ToolStripButton btnBrouse;
        private System.Windows.Forms.ToolStripButton btnAnalyze;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

