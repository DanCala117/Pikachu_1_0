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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SetBD = new Button();
            PortNum = new TextBox();
            HIDText = new TextBox();
            HIDLabel = new Label();
            leftButton = new Button();
            RightButton = new Button();
            BeltSpeed = new TextBox();
            SetBeltSpeed = new Button();
            CenterButton = new Button();
            StopInMiddleFirstButton = new CheckBox();
            SetTimeToStopButton = new Button();
            TimeToStop = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            StopInMiddleFirstForTwoButton = new CheckBox();
            ThreeQuarterButon = new Button();
            QuarterButton = new Button();
            ERRORText = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // SetBD
            // 
            SetBD.Location = new Point(11, 12);
            SetBD.Name = "SetBD";
            SetBD.Size = new Size(239, 29);
            SetBD.TabIndex = 0;
            SetBD.Text = "Connect to Belt Drive";
            SetBD.UseVisualStyleBackColor = true;
            SetBD.Click += SetBD_Click;
            // 
            // PortNum
            // 
            PortNum.Location = new Point(257, 8);
            PortNum.Name = "PortNum";
            PortNum.Size = new Size(78, 27);
            PortNum.TabIndex = 1;
            PortNum.Text = "COM";
            PortNum.TextChanged += PortNum_TextChanged;
            // 
            // HIDText
            // 
            HIDText.Location = new Point(347, 148);
            HIDText.Multiline = true;
            HIDText.Name = "HIDText";
            HIDText.ScrollBars = ScrollBars.Both;
            HIDText.Size = new Size(349, 561);
            HIDText.TabIndex = 2;
            // 
            // HIDLabel
            // 
            HIDLabel.AutoSize = true;
            HIDLabel.Location = new Point(347, 119);
            HIDLabel.Name = "HIDLabel";
            HIDLabel.Size = new Size(71, 20);
            HIDLabel.TabIndex = 3;
            HIDLabel.Text = "HID Data";
            HIDLabel.Click += label1_Click;
            // 
            // leftButton
            // 
            leftButton.Location = new Point(10, 232);
            leftButton.Name = "leftButton";
            leftButton.Size = new Size(323, 91);
            leftButton.TabIndex = 4;
            leftButton.Text = "Move To Left End";
            leftButton.UseVisualStyleBackColor = true;
            leftButton.Click += leftButton_Click;
            // 
            // RightButton
            // 
            RightButton.Location = new Point(10, 328);
            RightButton.Name = "RightButton";
            RightButton.Size = new Size(323, 91);
            RightButton.TabIndex = 5;
            RightButton.Text = "Move To Right End";
            RightButton.UseVisualStyleBackColor = true;
            RightButton.Click += RightButton_Click;
            // 
            // BeltSpeed
            // 
            BeltSpeed.Location = new Point(257, 45);
            BeltSpeed.Name = "BeltSpeed";
            BeltSpeed.Size = new Size(78, 27);
            BeltSpeed.TabIndex = 6;
            BeltSpeed.Text = "10";
            BeltSpeed.TextChanged += BeltSpeed_TextChanged;
            // 
            // SetBeltSpeed
            // 
            SetBeltSpeed.Location = new Point(11, 47);
            SetBeltSpeed.Name = "SetBeltSpeed";
            SetBeltSpeed.Size = new Size(239, 29);
            SetBeltSpeed.TabIndex = 7;
            SetBeltSpeed.Text = "Set Belt Drive Speed (ips)";
            SetBeltSpeed.UseVisualStyleBackColor = true;
            SetBeltSpeed.Click += SetBeltSpeed_Click;
            // 
            // CenterButton
            // 
            CenterButton.Location = new Point(10, 523);
            CenterButton.Name = "CenterButton";
            CenterButton.Size = new Size(323, 91);
            CenterButton.TabIndex = 8;
            CenterButton.Text = "Move Halfway";
            CenterButton.UseVisualStyleBackColor = true;
            CenterButton.Click += CenterButton_Click;
            // 
            // StopInMiddleFirstButton
            // 
            StopInMiddleFirstButton.AutoSize = true;
            StopInMiddleFirstButton.Location = new Point(14, 119);
            StopInMiddleFirstButton.Name = "StopInMiddleFirstButton";
            StopInMiddleFirstButton.Size = new Size(261, 24);
            StopInMiddleFirstButton.TabIndex = 9;
            StopInMiddleFirstButton.Text = "Stop In Center First For One Device";
            StopInMiddleFirstButton.UseVisualStyleBackColor = true;
            StopInMiddleFirstButton.CheckedChanged += StopInMiddleFirstButton_CheckedChanged;
            // 
            // SetTimeToStopButton
            // 
            SetTimeToStopButton.Location = new Point(11, 183);
            SetTimeToStopButton.Name = "SetTimeToStopButton";
            SetTimeToStopButton.Size = new Size(239, 29);
            SetTimeToStopButton.TabIndex = 10;
            SetTimeToStopButton.Text = "Set Time To Stop In Center (ms)";
            SetTimeToStopButton.UseVisualStyleBackColor = true;
            SetTimeToStopButton.Click += SetTimeToStopButton_Click;
            // 
            // TimeToStop
            // 
            TimeToStop.Location = new Point(253, 181);
            TimeToStop.Name = "TimeToStop";
            TimeToStop.Size = new Size(78, 27);
            TimeToStop.TabIndex = 11;
            TimeToStop.Text = "2000";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(10, 735);
            label1.Name = "label1";
            label1.Size = new Size(687, 3);
            label1.TabIndex = 12;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(338, 100);
            label2.Name = "label2";
            label2.Size = new Size(2, 635);
            label2.TabIndex = 13;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(14, 99);
            label3.Name = "label3";
            label3.Size = new Size(687, 3);
            label3.TabIndex = 14;
            // 
            // StopInMiddleFirstForTwoButton
            // 
            StopInMiddleFirstForTwoButton.AutoSize = true;
            StopInMiddleFirstForTwoButton.Location = new Point(14, 151);
            StopInMiddleFirstForTwoButton.Margin = new Padding(3, 4, 3, 4);
            StopInMiddleFirstForTwoButton.Name = "StopInMiddleFirstForTwoButton";
            StopInMiddleFirstForTwoButton.Size = new Size(267, 24);
            StopInMiddleFirstForTwoButton.TabIndex = 15;
            StopInMiddleFirstForTwoButton.Text = "Stop In Center First For Two Devices";
            StopInMiddleFirstForTwoButton.UseVisualStyleBackColor = true;
            StopInMiddleFirstForTwoButton.CheckedChanged += StopInMiddleFirstForTwoButton_CheckedChanged;
            // 
            // ThreeQuarterButon
            // 
            ThreeQuarterButon.Location = new Point(10, 620);
            ThreeQuarterButon.Margin = new Padding(3, 4, 3, 4);
            ThreeQuarterButon.Name = "ThreeQuarterButon";
            ThreeQuarterButon.Size = new Size(323, 91);
            ThreeQuarterButon.TabIndex = 17;
            ThreeQuarterButon.Text = "Move Three Quarters Way";
            ThreeQuarterButon.UseVisualStyleBackColor = true;
            ThreeQuarterButon.Click += ThreeQuarterButon_Click;
            // 
            // QuarterButton
            // 
            QuarterButton.Location = new Point(10, 425);
            QuarterButton.Margin = new Padding(3, 4, 3, 4);
            QuarterButton.Name = "QuarterButton";
            QuarterButton.Size = new Size(321, 91);
            QuarterButton.TabIndex = 18;
            QuarterButton.Text = "Move Quarter Way";
            QuarterButton.UseVisualStyleBackColor = true;
            QuarterButton.Click += QuarterButton_Click;
            // 
            // ERRORText
            // 
            ERRORText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ERRORText.ForeColor = Color.Red;
            ERRORText.Location = new Point(347, 32);
            ERRORText.Margin = new Padding(3, 4, 3, 4);
            ERRORText.Multiline = true;
            ERRORText.Name = "ERRORText";
            ERRORText.ReadOnly = true;
            ERRORText.Size = new Size(349, 43);
            ERRORText.TabIndex = 19;
            ERRORText.TextChanged += ERRORText_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(347, 8);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 20;
            label4.Text = "ERROR Message";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 753);
            Controls.Add(label4);
            Controls.Add(ERRORText);
            Controls.Add(QuarterButton);
            Controls.Add(ThreeQuarterButon);
            Controls.Add(StopInMiddleFirstForTwoButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TimeToStop);
            Controls.Add(SetTimeToStopButton);
            Controls.Add(StopInMiddleFirstButton);
            Controls.Add(CenterButton);
            Controls.Add(SetBeltSpeed);
            Controls.Add(BeltSpeed);
            Controls.Add(RightButton);
            Controls.Add(leftButton);
            Controls.Add(HIDLabel);
            Controls.Add(HIDText);
            Controls.Add(PortNum);
            Controls.Add(SetBD);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Pikachu 2.0";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox StopInMiddleFirstForTwoButton;
        private Button ThreeQuarterButon;
        private Button QuarterButton;
        private TextBox ERRORText;
        private Label label4;
    }
}