namespace Pikachu_1_0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SetBD = new System.Windows.Forms.Button();
            this.PortNum = new System.Windows.Forms.TextBox();
            this.HIDText = new System.Windows.Forms.TextBox();
            this.HIDLabel = new System.Windows.Forms.Label();
            this.leftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.BeltSpeed = new System.Windows.Forms.TextBox();
            this.SetBeltSpeed = new System.Windows.Forms.Button();
            this.CenterButton = new System.Windows.Forms.Button();
            this.StopInMiddleFirstButton = new System.Windows.Forms.CheckBox();
            this.SetTimeToStopButton = new System.Windows.Forms.Button();
            this.TimeToStop = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SetBD
            // 
            this.SetBD.Location = new System.Drawing.Point(12, 12);
            this.SetBD.Name = "SetBD";
            this.SetBD.Size = new System.Drawing.Size(239, 29);
            this.SetBD.TabIndex = 0;
            this.SetBD.Text = "Connect to Belt Drive";
            this.SetBD.UseVisualStyleBackColor = true;
            this.SetBD.Click += new System.EventHandler(this.SetBD_Click);
            // 
            // PortNum
            // 
            this.PortNum.Location = new System.Drawing.Point(257, 13);
            this.PortNum.Name = "PortNum";
            this.PortNum.Size = new System.Drawing.Size(78, 27);
            this.PortNum.TabIndex = 1;
            this.PortNum.Text = "COM";
            this.PortNum.TextChanged += new System.EventHandler(this.PortNum_TextChanged);
            // 
            // HIDText
            // 
            this.HIDText.Location = new System.Drawing.Point(341, 35);
            this.HIDText.Multiline = true;
            this.HIDText.Name = "HIDText";
            this.HIDText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.HIDText.Size = new System.Drawing.Size(447, 403);
            this.HIDText.TabIndex = 2;
            // 
            // HIDLabel
            // 
            this.HIDLabel.AutoSize = true;
            this.HIDLabel.Location = new System.Drawing.Point(341, 12);
            this.HIDLabel.Name = "HIDLabel";
            this.HIDLabel.Size = new System.Drawing.Size(71, 20);
            this.HIDLabel.TabIndex = 3;
            this.HIDLabel.Text = "HID Data";
            this.HIDLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(12, 156);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(323, 90);
            this.leftButton.TabIndex = 4;
            this.leftButton.Text = "Move Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(12, 252);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(323, 90);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "Move Right";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // BeltSpeed
            // 
            this.BeltSpeed.Location = new System.Drawing.Point(257, 45);
            this.BeltSpeed.Name = "BeltSpeed";
            this.BeltSpeed.Size = new System.Drawing.Size(78, 27);
            this.BeltSpeed.TabIndex = 6;
            this.BeltSpeed.Text = "10";
            this.BeltSpeed.TextChanged += new System.EventHandler(this.BeltSpeed_TextChanged);
            // 
            // SetBeltSpeed
            // 
            this.SetBeltSpeed.Location = new System.Drawing.Point(12, 44);
            this.SetBeltSpeed.Name = "SetBeltSpeed";
            this.SetBeltSpeed.Size = new System.Drawing.Size(239, 29);
            this.SetBeltSpeed.TabIndex = 7;
            this.SetBeltSpeed.Text = "Set Belt Drive Speed (ips)";
            this.SetBeltSpeed.UseVisualStyleBackColor = true;
            this.SetBeltSpeed.Click += new System.EventHandler(this.SetBeltSpeed_Click);
            // 
            // CenterButton
            // 
            this.CenterButton.Location = new System.Drawing.Point(12, 348);
            this.CenterButton.Name = "CenterButton";
            this.CenterButton.Size = new System.Drawing.Size(323, 90);
            this.CenterButton.TabIndex = 8;
            this.CenterButton.Text = "Move Center";
            this.CenterButton.UseVisualStyleBackColor = true;
            this.CenterButton.Click += new System.EventHandler(this.CenterButton_Click);
            // 
            // StopInMiddleFirstButton
            // 
            this.StopInMiddleFirstButton.AutoSize = true;
            this.StopInMiddleFirstButton.Location = new System.Drawing.Point(12, 79);
            this.StopInMiddleFirstButton.Name = "StopInMiddleFirstButton";
            this.StopInMiddleFirstButton.Size = new System.Drawing.Size(156, 24);
            this.StopInMiddleFirstButton.TabIndex = 9;
            this.StopInMiddleFirstButton.Text = "Stop In Center First";
            this.StopInMiddleFirstButton.UseVisualStyleBackColor = true;
            this.StopInMiddleFirstButton.CheckedChanged += new System.EventHandler(this.StopInMiddleFirstButton_CheckedChanged);
            // 
            // SetTimeToStopButton
            // 
            this.SetTimeToStopButton.Location = new System.Drawing.Point(12, 109);
            this.SetTimeToStopButton.Name = "SetTimeToStopButton";
            this.SetTimeToStopButton.Size = new System.Drawing.Size(239, 29);
            this.SetTimeToStopButton.TabIndex = 10;
            this.SetTimeToStopButton.Text = "Set Time To Stop In Center (ms)";
            this.SetTimeToStopButton.UseVisualStyleBackColor = true;
            this.SetTimeToStopButton.Click += new System.EventHandler(this.SetTimeToStopButton_Click);
            // 
            // TimeToStop
            // 
            this.TimeToStop.Location = new System.Drawing.Point(257, 110);
            this.TimeToStop.Name = "TimeToStop";
            this.TimeToStop.Size = new System.Drawing.Size(78, 27);
            this.TimeToStop.TabIndex = 11;
            this.TimeToStop.Text = "2000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TimeToStop);
            this.Controls.Add(this.SetTimeToStopButton);
            this.Controls.Add(this.StopInMiddleFirstButton);
            this.Controls.Add(this.CenterButton);
            this.Controls.Add(this.SetBeltSpeed);
            this.Controls.Add(this.BeltSpeed);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.HIDLabel);
            this.Controls.Add(this.HIDText);
            this.Controls.Add(this.PortNum);
            this.Controls.Add(this.SetBD);
            this.Name = "Form1";
            this.Text = "Pikachu 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SetBD;
        private TextBox PortNum;
        private TextBox HIDText;
        private Label HIDLabel;
        private Button leftButton;
        private Button RightButton;
        private TextBox BeltSpeed;
        private Button SetBeltSpeed;
        private Button CenterButton;
        private CheckBox StopInMiddleFirstButton;
        private Button SetTimeToStopButton;
        private TextBox TimeToStop;
    }
}