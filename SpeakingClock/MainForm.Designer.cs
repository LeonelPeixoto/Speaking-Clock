namespace VoiceClock
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_MinimizeToTray = new System.Windows.Forms.CheckBox();
            this.checkBox_StartMinimized = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.comboBox_SayPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxTime = new System.Windows.Forms.GroupBox();
            this.lastSayed2Lbel = new System.Windows.Forms.Label();
            this.lastSayed1Lbel = new System.Windows.Forms.Label();
            this.nextVoiceRequestLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.voiceStatusLabel = new System.Windows.Forms.Label();
            this.voiceUpdateButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox5.SuspendLayout();
            this.groupBoxTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox_MinimizeToTray);
            this.groupBox5.Controls.Add(this.checkBox_StartMinimized);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.comboBox_Language);
            this.groupBox5.Controls.Add(this.comboBox_SayPeriod);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(254, 73);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Configs";
            // 
            // checkBox_MinimizeToTray
            // 
            this.checkBox_MinimizeToTray.AutoSize = true;
            this.checkBox_MinimizeToTray.Location = new System.Drawing.Point(149, 46);
            this.checkBox_MinimizeToTray.Name = "checkBox_MinimizeToTray";
            this.checkBox_MinimizeToTray.Size = new System.Drawing.Size(98, 17);
            this.checkBox_MinimizeToTray.TabIndex = 18;
            this.checkBox_MinimizeToTray.Text = "Minimize to tray";
            this.checkBox_MinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // checkBox_StartMinimized
            // 
            this.checkBox_StartMinimized.AutoSize = true;
            this.checkBox_StartMinimized.Location = new System.Drawing.Point(7, 46);
            this.checkBox_StartMinimized.Name = "checkBox_StartMinimized";
            this.checkBox_StartMinimized.Size = new System.Drawing.Size(96, 17);
            this.checkBox_StartMinimized.TabIndex = 17;
            this.checkBox_StartMinimized.Text = "Start minimized";
            this.checkBox_StartMinimized.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "mins";
            // 
            // comboBox_Language
            // 
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Items.AddRange(new object[] {
            "EN",
            "FR",
            "PT"});
            this.comboBox_Language.Location = new System.Drawing.Point(7, 19);
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.Size = new System.Drawing.Size(49, 21);
            this.comboBox_Language.TabIndex = 7;
            // 
            // comboBox_SayPeriod
            // 
            this.comboBox_SayPeriod.FormattingEnabled = true;
            this.comboBox_SayPeriod.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "60"});
            this.comboBox_SayPeriod.Location = new System.Drawing.Point(166, 19);
            this.comboBox_SayPeriod.Name = "comboBox_SayPeriod";
            this.comboBox_SayPeriod.Size = new System.Drawing.Size(49, 21);
            this.comboBox_SayPeriod.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Say time every:";
            // 
            // groupBoxTime
            // 
            this.groupBoxTime.Controls.Add(this.lastSayed2Lbel);
            this.groupBoxTime.Controls.Add(this.lastSayed1Lbel);
            this.groupBoxTime.Controls.Add(this.nextVoiceRequestLabel);
            this.groupBoxTime.Controls.Add(this.secondsLabel);
            this.groupBoxTime.Controls.Add(this.minutesLabel);
            this.groupBoxTime.Controls.Add(this.timeLabel);
            this.groupBoxTime.Controls.Add(this.hoursLabel);
            this.groupBoxTime.Location = new System.Drawing.Point(12, 91);
            this.groupBoxTime.Name = "groupBoxTime";
            this.groupBoxTime.Size = new System.Drawing.Size(173, 139);
            this.groupBoxTime.TabIndex = 13;
            this.groupBoxTime.TabStop = false;
            this.groupBoxTime.Text = "Time";
            // 
            // lastSayed2Lbel
            // 
            this.lastSayed2Lbel.Location = new System.Drawing.Point(52, 97);
            this.lastSayed2Lbel.Name = "lastSayed2Lbel";
            this.lastSayed2Lbel.Size = new System.Drawing.Size(62, 13);
            this.lastSayed2Lbel.TabIndex = 18;
            this.lastSayed2Lbel.Text = "...";
            this.lastSayed2Lbel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastSayed1Lbel
            // 
            this.lastSayed1Lbel.Location = new System.Drawing.Point(52, 73);
            this.lastSayed1Lbel.Name = "lastSayed1Lbel";
            this.lastSayed1Lbel.Size = new System.Drawing.Size(62, 13);
            this.lastSayed1Lbel.TabIndex = 17;
            this.lastSayed1Lbel.Text = "...";
            this.lastSayed1Lbel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextVoiceRequestLabel
            // 
            this.nextVoiceRequestLabel.AutoSize = true;
            this.nextVoiceRequestLabel.Location = new System.Drawing.Point(15, 113);
            this.nextVoiceRequestLabel.Name = "nextVoiceRequestLabel";
            this.nextVoiceRequestLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nextVoiceRequestLabel.Size = new System.Drawing.Size(115, 13);
            this.nextVoiceRequestLabel.TabIndex = 8;
            this.nextVoiceRequestLabel.Text = "Next Request in XXX s";
            // 
            // secondsLabel
            // 
            this.secondsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(93, 49);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(21, 13);
            this.secondsLabel.TabIndex = 2;
            this.secondsLabel.Text = "SS";
            this.secondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minutesLabel
            // 
            this.minutesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(70, 49);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(25, 13);
            this.minutesLabel.TabIndex = 1;
            this.minutesLabel.Text = "MM";
            this.minutesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TimeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(4, 26);
            this.timeLabel.Name = "TimeLabel";
            this.timeLabel.Size = new System.Drawing.Size(30, 13);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time";
            // 
            // hoursLabel
            // 
            this.hoursLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(49, 49);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(23, 13);
            this.hoursLabel.TabIndex = 0;
            this.hoursLabel.Text = "HH";
            this.hoursLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // voiceStatusLabel
            // 
            this.voiceStatusLabel.Location = new System.Drawing.Point(191, 188);
            this.voiceStatusLabel.Name = "voiceStatusLabel";
            this.voiceStatusLabel.Size = new System.Drawing.Size(75, 13);
            this.voiceStatusLabel.TabIndex = 5;
            this.voiceStatusLabel.Text = "Status";
            this.voiceStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // voiceUpdateButton
            // 
            this.voiceUpdateButton.Location = new System.Drawing.Point(191, 145);
            this.voiceUpdateButton.Name = "voiceUpdateButton";
            this.voiceUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.voiceUpdateButton.TabIndex = 12;
            this.voiceUpdateButton.Text = "Say Time";
            this.voiceUpdateButton.UseVisualStyleBackColor = true;
            this.voiceUpdateButton.Click += new System.EventHandler(this.SayTimeButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Minimized to system tray";
            this.notifyIcon.BalloonTipTitle = "-";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(214, 107);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 242);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBoxTime);
            this.Controls.Add(this.voiceUpdateButton);
            this.Controls.Add(this.voiceStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Speaking Clock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxTime.ResumeLayout(false);
            this.groupBoxTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label nextVoiceRequestLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label voiceStatusLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxTime;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Button voiceUpdateButton;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.Label lastSayed2Lbel;
        private System.Windows.Forms.Label lastSayed1Lbel;
        private System.Windows.Forms.ComboBox comboBox_SayPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Language;
        private System.Windows.Forms.CheckBox checkBox_MinimizeToTray;
        private System.Windows.Forms.CheckBox checkBox_StartMinimized;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

