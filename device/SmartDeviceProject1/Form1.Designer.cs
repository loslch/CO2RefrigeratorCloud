namespace SmartDeviceProject1
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
            this.smartTimer1 = new SmartX.SmartTimer(this.components);
            this.Fan_one_timer = new SmartX.SmartTimer(this.components);
            this.smartTrackBar1 = new SmartX.SmartTrackBar();
            this.Co2Text = new SmartX.SmartLabel();
            this.O2Text = new SmartX.SmartLabel();
            this.TempText = new SmartX.SmartLabel();
            this.HumText = new SmartX.SmartLabel();
            this.Carbon = new SmartX.SmartLabel();
            this.Oxy = new SmartX.SmartLabel();
            this.Temp = new SmartX.SmartLabel();
            this.Humi = new SmartX.SmartLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btnopen = new SmartX.SmartButton();
            this.BtnClose = new SmartX.SmartButton();
            this.DoorStatus = new SmartX.SmartLabel();
            this.LogText = new SmartX.SmartLabel();
            this.Req = new SmartX.SmartTimer(this.components);
            this.refreshLog = new SmartX.SmartTimer(this.components);
            this.SuspendLayout();
            // 
            // smartTimer1
            // 
            this.smartTimer1.EndTime = ((long)(100000000000));
            this.smartTimer1.Interval = 100;
            this.smartTimer1.IntervalSeries = null;
            this.smartTimer1.NowMillisecond = ((long)(0));
            this.smartTimer1.StartTime = ((long)(0));
            this.smartTimer1.Tick += new System.EventHandler(this.smartTimer1_Tick);
            // 
            // Fan_one_timer
            // 
            this.Fan_one_timer.EndTime = ((long)(100000000000));
            this.Fan_one_timer.Interval = 100;
            this.Fan_one_timer.IntervalSeries = null;
            this.Fan_one_timer.NowMillisecond = ((long)(0));
            this.Fan_one_timer.StartTime = ((long)(0));
            this.Fan_one_timer.Tick += new System.EventHandler(this.Fan_one_timer_Tick);
            // 
            // smartTrackBar1
            // 
            this.smartTrackBar1.BackPictureBox = null;
            this.smartTrackBar1.BackPictureBox1 = null;
            this.smartTrackBar1.BackPictureBox2 = null;
            this.smartTrackBar1.BarButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.smartTrackBar1.BarButtonLineColor = System.Drawing.Color.White;
            this.smartTrackBar1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.smartTrackBar1.BarFillColor = System.Drawing.Color.Red;
            this.smartTrackBar1.BarOutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.smartTrackBar1.ButWidth = 30;
            this.smartTrackBar1.LargeChangeStep = 0;
            this.smartTrackBar1.Location = new System.Drawing.Point(0, 0);
            this.smartTrackBar1.Name = "smartTrackBar1";
            this.smartTrackBar1.Orientation = SmartX.SmartTrackBar.ORIENTATIONTYPE.Horizontal;
            this.smartTrackBar1.Size = new System.Drawing.Size(200, 200);
            this.smartTrackBar1.SmallChangeStep = 0;
            this.smartTrackBar1.Step = 0;
            this.smartTrackBar1.TabIndex = 0;
            this.smartTrackBar1.Text = "smartTrackBar1";
            this.smartTrackBar1.Value = 0;
            // 
            // Co2Text
            // 
            this.Co2Text.BackPictureBox = null;
            this.Co2Text.BackPictureBox1 = null;
            this.Co2Text.BackPictureBox2 = null;
            this.Co2Text.BorderColor = System.Drawing.Color.Black;
            this.Co2Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Co2Text.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.Co2Text.InitVisible = true;
            this.Co2Text.Location = new System.Drawing.Point(3, 33);
            this.Co2Text.Name = "Co2Text";
            this.Co2Text.Size = new System.Drawing.Size(200, 40);
            this.Co2Text.TabIndex = 0;
            this.Co2Text.Text = "CO2";
            this.Co2Text.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.Co2Text.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // O2Text
            // 
            this.O2Text.BackPictureBox = null;
            this.O2Text.BackPictureBox1 = null;
            this.O2Text.BackPictureBox2 = null;
            this.O2Text.BorderColor = System.Drawing.Color.Black;
            this.O2Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.O2Text.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.O2Text.InitVisible = true;
            this.O2Text.Location = new System.Drawing.Point(3, 79);
            this.O2Text.Name = "O2Text";
            this.O2Text.Size = new System.Drawing.Size(200, 40);
            this.O2Text.TabIndex = 1;
            this.O2Text.Text = "O2";
            this.O2Text.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.O2Text.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // TempText
            // 
            this.TempText.BackPictureBox = null;
            this.TempText.BackPictureBox1 = null;
            this.TempText.BackPictureBox2 = null;
            this.TempText.BorderColor = System.Drawing.Color.Black;
            this.TempText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TempText.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.TempText.InitVisible = true;
            this.TempText.Location = new System.Drawing.Point(3, 125);
            this.TempText.Name = "TempText";
            this.TempText.Size = new System.Drawing.Size(200, 40);
            this.TempText.TabIndex = 2;
            this.TempText.Text = "Temperature";
            this.TempText.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.TempText.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // HumText
            // 
            this.HumText.BackPictureBox = null;
            this.HumText.BackPictureBox1 = null;
            this.HumText.BackPictureBox2 = null;
            this.HumText.BorderColor = System.Drawing.Color.Black;
            this.HumText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HumText.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.HumText.InitVisible = true;
            this.HumText.Location = new System.Drawing.Point(3, 171);
            this.HumText.Name = "HumText";
            this.HumText.Size = new System.Drawing.Size(200, 40);
            this.HumText.TabIndex = 3;
            this.HumText.Text = "Humidity";
            this.HumText.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.HumText.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // Carbon
            // 
            this.Carbon.BackPictureBox = null;
            this.Carbon.BackPictureBox1 = null;
            this.Carbon.BackPictureBox2 = null;
            this.Carbon.BorderColor = System.Drawing.Color.Black;
            this.Carbon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Carbon.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.Carbon.InitVisible = true;
            this.Carbon.Location = new System.Drawing.Point(209, 33);
            this.Carbon.Name = "Carbon";
            this.Carbon.Size = new System.Drawing.Size(200, 40);
            this.Carbon.TabIndex = 4;
            this.Carbon.Text = "--";
            this.Carbon.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.Carbon.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // Oxy
            // 
            this.Oxy.BackPictureBox = null;
            this.Oxy.BackPictureBox1 = null;
            this.Oxy.BackPictureBox2 = null;
            this.Oxy.BorderColor = System.Drawing.Color.Black;
            this.Oxy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Oxy.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.Oxy.InitVisible = true;
            this.Oxy.Location = new System.Drawing.Point(209, 79);
            this.Oxy.Name = "Oxy";
            this.Oxy.Size = new System.Drawing.Size(200, 40);
            this.Oxy.TabIndex = 5;
            this.Oxy.Text = "--";
            this.Oxy.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.Oxy.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // Temp
            // 
            this.Temp.BackPictureBox = null;
            this.Temp.BackPictureBox1 = null;
            this.Temp.BackPictureBox2 = null;
            this.Temp.BorderColor = System.Drawing.Color.Black;
            this.Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Temp.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.Temp.InitVisible = true;
            this.Temp.Location = new System.Drawing.Point(209, 125);
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(200, 40);
            this.Temp.TabIndex = 6;
            this.Temp.Text = "--";
            this.Temp.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.Temp.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // Humi
            // 
            this.Humi.BackPictureBox = null;
            this.Humi.BackPictureBox1 = null;
            this.Humi.BackPictureBox2 = null;
            this.Humi.BorderColor = System.Drawing.Color.Black;
            this.Humi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Humi.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.Humi.InitVisible = true;
            this.Humi.Location = new System.Drawing.Point(209, 171);
            this.Humi.Name = "Humi";
            this.Humi.Size = new System.Drawing.Size(200, 40);
            this.Humi.TabIndex = 7;
            this.Humi.Text = "--";
            this.Humi.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.Humi.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(495, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // Btnopen
            // 
            this.Btnopen.BackPictureBox = null;
            this.Btnopen.BackPictureBox1 = null;
            this.Btnopen.BackPictureBox2 = null;
            this.Btnopen.ButtonColor = System.Drawing.Color.Gray;
            this.Btnopen.ButtonImageAutoSize = true;
            this.Btnopen.ColorKeySamplePosition = new System.Drawing.Point(0, 0);
            this.Btnopen.DisableImage = null;
            this.Btnopen.DownImage = null;
            this.Btnopen.GroupID = 0;
            this.Btnopen.InitVisible = true;
            this.Btnopen.Location = new System.Drawing.Point(495, 33);
            this.Btnopen.Mode = SmartX.SmartButton.BUTTONMODE.NORMAL;
            this.Btnopen.Name = "Btnopen";
            this.Btnopen.NestedClickEventPrevent = false;
            this.Btnopen.RepeatInterval = 200;
            this.Btnopen.SafeInterval = 200;
            this.Btnopen.Size = new System.Drawing.Size(127, 60);
            this.Btnopen.SpecialFunction = SmartX.SmartButton.SPECIALFUNC.NONE;
            this.Btnopen.TabIndex = 9;
            this.Btnopen.Text = "Door Open";
            this.Btnopen.TextColor = System.Drawing.Color.Black;
            this.Btnopen.TextDownColor = System.Drawing.Color.White;
            this.Btnopen.TextHAlign = SmartX.SmartButton.TextHorAlign.Middle;
            this.Btnopen.TextLocation = new System.Drawing.Point(0, 0);
            this.Btnopen.TextVAlign = SmartX.SmartButton.TextVerAlign.Middle;
            this.Btnopen.UpImage = null;
            this.Btnopen.Click += new System.EventHandler(this.Btnopen_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackPictureBox = null;
            this.BtnClose.BackPictureBox1 = null;
            this.BtnClose.BackPictureBox2 = null;
            this.BtnClose.ButtonColor = System.Drawing.Color.Gray;
            this.BtnClose.ButtonImageAutoSize = true;
            this.BtnClose.ColorKeySamplePosition = new System.Drawing.Point(0, 0);
            this.BtnClose.DisableImage = null;
            this.BtnClose.DownImage = null;
            this.BtnClose.Enabled = false;
            this.BtnClose.GroupID = 0;
            this.BtnClose.InitVisible = true;
            this.BtnClose.Location = new System.Drawing.Point(628, 33);
            this.BtnClose.Mode = SmartX.SmartButton.BUTTONMODE.NORMAL;
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.NestedClickEventPrevent = false;
            this.BtnClose.RepeatInterval = 200;
            this.BtnClose.SafeInterval = 200;
            this.BtnClose.Size = new System.Drawing.Size(127, 60);
            this.BtnClose.SpecialFunction = SmartX.SmartButton.SPECIALFUNC.NONE;
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "Door Close";
            this.BtnClose.TextColor = System.Drawing.Color.Black;
            this.BtnClose.TextDownColor = System.Drawing.Color.White;
            this.BtnClose.TextHAlign = SmartX.SmartButton.TextHorAlign.Middle;
            this.BtnClose.TextLocation = new System.Drawing.Point(0, 0);
            this.BtnClose.TextVAlign = SmartX.SmartButton.TextVerAlign.Middle;
            this.BtnClose.UpImage = null;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DoorStatus
            // 
            this.DoorStatus.BackPictureBox = null;
            this.DoorStatus.BackPictureBox1 = null;
            this.DoorStatus.BackPictureBox2 = null;
            this.DoorStatus.BorderColor = System.Drawing.Color.Black;
            this.DoorStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DoorStatus.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular);
            this.DoorStatus.InitVisible = true;
            this.DoorStatus.Location = new System.Drawing.Point(495, 100);
            this.DoorStatus.Name = "DoorStatus";
            this.DoorStatus.Size = new System.Drawing.Size(206, 46);
            this.DoorStatus.TabIndex = 12;
            this.DoorStatus.Text = "smartLabel1";
            this.DoorStatus.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.DoorStatus.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // LogText
            // 
            this.LogText.BackPictureBox = null;
            this.LogText.BackPictureBox1 = null;
            this.LogText.BackPictureBox2 = null;
            this.LogText.BorderColor = System.Drawing.Color.Black;
            this.LogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogText.InitVisible = true;
            this.LogText.Location = new System.Drawing.Point(3, 217);
            this.LogText.Name = "LogText";
            this.LogText.Size = new System.Drawing.Size(406, 125);
            this.LogText.TabIndex = 14;
            this.LogText.Text = "smartLabel1";
            this.LogText.TextHAlign = SmartX.SmartLabel.TextHorAlign.Left;
            this.LogText.TextVAlign = SmartX.SmartLabel.TextVerAlign.Top;
            // 
            // Req
            // 
            this.Req.EndTime = ((long)(100000000000));
            this.Req.Interval = 100;
            this.Req.IntervalSeries = null;
            this.Req.NowMillisecond = ((long)(0));
            this.Req.StartTime = ((long)(0));
            this.Req.Tick += new System.EventHandler(this.Req_Tick);
            // 
            // refreshLog
            // 
            this.refreshLog.EndTime = ((long)(100000000000));
            this.refreshLog.Interval = 100;
            this.refreshLog.IntervalSeries = null;
            this.refreshLog.NowMillisecond = ((long)(0));
            this.refreshLog.StartTime = ((long)(0));
            this.refreshLog.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.DoorStatus);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.Btnopen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Humi);
            this.Controls.Add(this.Temp);
            this.Controls.Add(this.Oxy);
            this.Controls.Add(this.Carbon);
            this.Controls.Add(this.HumText);
            this.Controls.Add(this.TempText);
            this.Controls.Add(this.O2Text);
            this.Controls.Add(this.Co2Text);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SmartX.SmartTimer smartTimer1;
        private SmartX.SmartTimer Fan_one_timer;
        private SmartX.SmartTrackBar smartTrackBar1;
        private SmartX.SmartLabel Co2Text;
        private SmartX.SmartLabel O2Text;
        private SmartX.SmartLabel TempText;
        private SmartX.SmartLabel HumText;
        private SmartX.SmartLabel Carbon;
        private SmartX.SmartLabel Oxy;
        private SmartX.SmartLabel Temp;
        private SmartX.SmartLabel Humi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private SmartX.SmartButton Btnopen;
        private SmartX.SmartButton BtnClose;
        private SmartX.SmartLabel DoorStatus;
        private SmartX.SmartLabel LogText;
        private SmartX.SmartTimer Req;
        private SmartX.SmartTimer refreshLog;
    }
}

