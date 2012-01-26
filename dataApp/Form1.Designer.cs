namespace app
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addressText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ageText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sexText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numberText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calenderTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.allCostText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selfPayText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.compensatePayText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.diagnosisText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.NextRecord = new System.Windows.Forms.Button();
            this.PreviousRecord = new System.Windows.Forms.Button();
            this.indicatorLable = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recentOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // nameText
            // 
            this.nameText.Enabled = false;
            this.nameText.Location = new System.Drawing.Point(93, 35);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(100, 20);
            this.nameText.TabIndex = 1;
            this.nameText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nameText_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "地址";
            // 
            // addressText
            // 
            this.addressText.Enabled = false;
            this.addressText.Location = new System.Drawing.Point(91, 111);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(102, 20);
            this.addressText.TabIndex = 3;
            this.addressText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.addressText_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "年龄";
            // 
            // ageText
            // 
            this.ageText.Enabled = false;
            this.ageText.Location = new System.Drawing.Point(93, 157);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(100, 20);
            this.ageText.TabIndex = 4;
            this.ageText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ageText_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "性别";
            // 
            // sexText
            // 
            this.sexText.Enabled = false;
            this.sexText.Location = new System.Drawing.Point(93, 207);
            this.sexText.Name = "sexText";
            this.sexText.Size = new System.Drawing.Size(100, 20);
            this.sexText.TabIndex = 5;
            this.sexText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sexText_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "合疗卡号";
            // 
            // numberText
            // 
            this.numberText.Enabled = false;
            this.numberText.Location = new System.Drawing.Point(93, 69);
            this.numberText.Name = "numberText";
            this.numberText.Size = new System.Drawing.Size(100, 20);
            this.numberText.TabIndex = 2;
            this.numberText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numberText_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "日期";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sexText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ageText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.addressText);
            this.groupBox1.Controls.Add(this.numberText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nameText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(29, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 320);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // calenderTimePicker
            // 
            this.calenderTimePicker.AllowDrop = true;
            this.calenderTimePicker.Enabled = false;
            this.calenderTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.calenderTimePicker.Location = new System.Drawing.Point(497, 2);
            this.calenderTimePicker.Name = "calenderTimePicker";
            this.calenderTimePicker.Size = new System.Drawing.Size(100, 20);
            this.calenderTimePicker.TabIndex = 6;
            this.calenderTimePicker.Value = new System.DateTime(2012, 1, 24, 18, 45, 57, 0);
            this.calenderTimePicker.ValueChanged += new System.EventHandler(this.calenderTimePicker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "总费用";
            // 
            // allCostText
            // 
            this.allCostText.Enabled = false;
            this.allCostText.Location = new System.Drawing.Point(79, 75);
            this.allCostText.Name = "allCostText";
            this.allCostText.Size = new System.Drawing.Size(87, 20);
            this.allCostText.TabIndex = 8;
            this.allCostText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.allCostText_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "自付";
            // 
            // selfPayText
            // 
            this.selfPayText.Enabled = false;
            this.selfPayText.Location = new System.Drawing.Point(79, 159);
            this.selfPayText.Name = "selfPayText";
            this.selfPayText.Size = new System.Drawing.Size(85, 20);
            this.selfPayText.TabIndex = 9;
            this.selfPayText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.selfPayText_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "补偿";
            // 
            // compensatePayText
            // 
            this.compensatePayText.Enabled = false;
            this.compensatePayText.Location = new System.Drawing.Point(79, 117);
            this.compensatePayText.Name = "compensatePayText";
            this.compensatePayText.Size = new System.Drawing.Size(84, 20);
            this.compensatePayText.TabIndex = 10;
            this.compensatePayText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.compensatePayText_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.diagnosisText);
            this.groupBox2.Controls.Add(this.compensatePayText);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.selfPayText);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.allCostText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(328, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 226);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // diagnosisText
            // 
            this.diagnosisText.Enabled = false;
            this.diagnosisText.Location = new System.Drawing.Point(79, 34);
            this.diagnosisText.Name = "diagnosisText";
            this.diagnosisText.Size = new System.Drawing.Size(87, 20);
            this.diagnosisText.TabIndex = 7;
            this.diagnosisText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.diagnosisText_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "诊断";
            // 
            // NextRecord
            // 
            this.NextRecord.Enabled = false;
            this.NextRecord.Location = new System.Drawing.Point(356, 411);
            this.NextRecord.Name = "NextRecord";
            this.NextRecord.Size = new System.Drawing.Size(246, 84);
            this.NextRecord.TabIndex = 20;
            this.NextRecord.Text = "下一个";
            this.NextRecord.UseVisualStyleBackColor = true;
            this.NextRecord.Click += new System.EventHandler(this.NextRecord_Click);
            // 
            // PreviousRecord
            // 
            this.PreviousRecord.Enabled = false;
            this.PreviousRecord.Location = new System.Drawing.Point(2, 412);
            this.PreviousRecord.Name = "PreviousRecord";
            this.PreviousRecord.Size = new System.Drawing.Size(270, 83);
            this.PreviousRecord.TabIndex = 11;
            this.PreviousRecord.Text = "上一个";
            this.PreviousRecord.UseVisualStyleBackColor = true;
            this.PreviousRecord.Click += new System.EventHandler(this.PreviousRecord_Click);
            // 
            // indicatorLable
            // 
            this.indicatorLable.AutoSize = true;
            this.indicatorLable.Location = new System.Drawing.Point(288, 447);
            this.indicatorLable.Name = "indicatorLable";
            this.indicatorLable.Size = new System.Drawing.Size(24, 13);
            this.indicatorLable.TabIndex = 22;
            this.indicatorLable.Text = "0/0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openToolStripMenuItem.Text = "创建新文件";
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.nextToolStripMenuItem.Text = "打开";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.SaveToolStripMenuItem.Text = "保存";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(609, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.recentOpenToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.NewToolStripMenuItem.Text = "新建";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.openToolStripMenuItem1.Text = "打开";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "保存";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // recentOpenToolStripMenuItem
            // 
            this.recentOpenToolStripMenuItem.Name = "recentOpenToolStripMenuItem";
            this.recentOpenToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.recentOpenToolStripMenuItem.Text = "最近打开";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.exitToolStripMenuItem1.Text = "退出";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsPageToolStripMenuItem,
            this.SettingToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.statisticsToolStripMenuItem.Text = "统计";
            // 
            // statisticsPageToolStripMenuItem
            // 
            this.statisticsPageToolStripMenuItem.Name = "statisticsPageToolStripMenuItem";
            this.statisticsPageToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.statisticsPageToolStripMenuItem.Text = "统计页";
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.SettingToolStripMenuItem.Text = "设置";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aboutToolStripMenuItem.Text = "关于";
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.InfoToolStripMenuItem.Text = "作者及版权";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 496);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.indicatorLable);
            this.Controls.Add(this.PreviousRecord);
            this.Controls.Add(this.NextRecord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.calenderTimePicker);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "农村医疗合作信息录入助手";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sexText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numberText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker calenderTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox allCostText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox selfPayText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox compensatePayText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button NextRecord;
        private System.Windows.Forms.Button PreviousRecord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox diagnosisText;
        private System.Windows.Forms.Label indicatorLable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recentOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

