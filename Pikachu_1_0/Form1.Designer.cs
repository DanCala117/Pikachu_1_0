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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SetBD = new Button();
            PortNum = new TextBox();
            BeltSpeed = new TextBox();
            SetBeltSpeed = new Button();
            StopInMiddleFirstButton = new CheckBox();
            SetTimeToStopButton = new Button();
            TimeToStop = new TextBox();
            label1 = new Label();
            label3 = new Label();
            StopInMiddleFirstForTwoButton = new CheckBox();
            ERRORText = new TextBox();
            label4 = new Label();
            AutomatedTestToolTip = new ToolTip(components);
            tabPage1 = new TabPage();
            EndDistance = new TextBox();
            TimeToStopIncrement = new TextBox();
            IncrementToMove = new TextBox();
            DistanceToMove = new TextBox();
            SetEndDistanceButton = new Button();
            SetTimeToStopIncremenetButton = new Button();
            IncrementStopTimeButton = new CheckBox();
            button2 = new Button();
            ExactButton = new Button();
            label2 = new Label();
            leftButton = new Button();
            RightButton = new Button();
            QuarterButton = new Button();
            ThreeQuarterButon = new Button();
            CenterButton = new Button();
            tab = new TabControl();
            tabPage4 = new TabPage();
            textBox2 = new TextBox();
            label5 = new Label();
            RepetetiveZoomTestZoomCount = new Label();
            RepetetiveZoomtestStopTime = new TextBox();
            label23 = new Label();
            label22 = new Label();
            RepetetiveZoomTestCount = new TextBox();
            button1 = new Button();
            tabPage3 = new TabPage();
            textBox1 = new TextBox();
            label21 = new Label();
            label20 = new Label();
            TestOneAttempts = new TextBox();
            label19 = new Label();
            TestOneStartButton = new Button();
            TestOneWaitTime = new TextBox();
            label18 = new Label();
            TestOneIncrementToAdvanceBy = new TextBox();
            label17 = new Label();
            TestOneStopDistance = new TextBox();
            label16 = new Label();
            TestOneStartDistance = new TextBox();
            label15 = new Label();
            tabPage1.SuspendLayout();
            tab.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // SetBD
            // 
            SetBD.Location = new Point(10, 6);
            SetBD.Margin = new Padding(3, 2, 3, 2);
            SetBD.Name = "SetBD";
            SetBD.Size = new Size(209, 23);
            SetBD.TabIndex = 0;
            SetBD.Text = "Connect to Belt Drive";
            SetBD.UseVisualStyleBackColor = true;
            SetBD.Click += SetBD_Click;
            // 
            // PortNum
            // 
            PortNum.Location = new Point(225, 6);
            PortNum.Margin = new Padding(3, 2, 3, 2);
            PortNum.Name = "PortNum";
            PortNum.Size = new Size(69, 23);
            PortNum.TabIndex = 1;
            PortNum.Text = "COM";
            // 
            // BeltSpeed
            // 
            BeltSpeed.Location = new Point(225, 37);
            BeltSpeed.Margin = new Padding(3, 2, 3, 2);
            BeltSpeed.Name = "BeltSpeed";
            BeltSpeed.Size = new Size(69, 23);
            BeltSpeed.TabIndex = 6;
            BeltSpeed.Text = "10";
            BeltSpeed.TextChanged += BeltSpeed_TextChanged;
            // 
            // SetBeltSpeed
            // 
            SetBeltSpeed.Location = new Point(10, 37);
            SetBeltSpeed.Margin = new Padding(3, 2, 3, 2);
            SetBeltSpeed.Name = "SetBeltSpeed";
            SetBeltSpeed.Size = new Size(209, 23);
            SetBeltSpeed.TabIndex = 7;
            SetBeltSpeed.Text = "Set Belt Drive Speed (ips)";
            SetBeltSpeed.UseVisualStyleBackColor = true;
            SetBeltSpeed.Click += SetBeltSpeed_Click;
            // 
            // StopInMiddleFirstButton
            // 
            StopInMiddleFirstButton.AutoSize = true;
            StopInMiddleFirstButton.Location = new Point(6, 5);
            StopInMiddleFirstButton.Margin = new Padding(3, 2, 3, 2);
            StopInMiddleFirstButton.Name = "StopInMiddleFirstButton";
            StopInMiddleFirstButton.Size = new Size(209, 19);
            StopInMiddleFirstButton.TabIndex = 9;
            StopInMiddleFirstButton.Text = "Stop In Center First For One Device";
            StopInMiddleFirstButton.UseVisualStyleBackColor = true;
            StopInMiddleFirstButton.CheckedChanged += StopInMiddleFirstButton_CheckedChanged;
            // 
            // SetTimeToStopButton
            // 
            SetTimeToStopButton.Location = new Point(3, 28);
            SetTimeToStopButton.Margin = new Padding(3, 2, 3, 2);
            SetTimeToStopButton.Name = "SetTimeToStopButton";
            SetTimeToStopButton.Size = new Size(209, 23);
            SetTimeToStopButton.TabIndex = 10;
            SetTimeToStopButton.Text = "Set Time To Stop In Center (ms)";
            SetTimeToStopButton.UseVisualStyleBackColor = true;
            SetTimeToStopButton.Click += SetTimeToStopButton_Click;
            // 
            // TimeToStop
            // 
            TimeToStop.Location = new Point(239, 28);
            TimeToStop.Margin = new Padding(3, 2, 3, 2);
            TimeToStop.Name = "TimeToStop";
            TimeToStop.Size = new Size(73, 23);
            TimeToStop.TabIndex = 11;
            TimeToStop.Text = "2000";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(9, 551);
            label1.Name = "label1";
            label1.Size = new Size(601, 2);
            label1.TabIndex = 12;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(601, 2);
            label3.TabIndex = 14;
            // 
            // StopInMiddleFirstForTwoButton
            // 
            StopInMiddleFirstForTwoButton.AutoSize = true;
            StopInMiddleFirstForTwoButton.Location = new Point(230, 6);
            StopInMiddleFirstForTwoButton.Name = "StopInMiddleFirstForTwoButton";
            StopInMiddleFirstForTwoButton.Size = new Size(213, 19);
            StopInMiddleFirstForTwoButton.TabIndex = 15;
            StopInMiddleFirstForTwoButton.Text = "Stop In Center First For Two Devices";
            StopInMiddleFirstForTwoButton.UseVisualStyleBackColor = true;
            StopInMiddleFirstForTwoButton.CheckedChanged += StopInMiddleFirstForTwoButton_CheckedChanged;
            // 
            // ERRORText
            // 
            ERRORText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ERRORText.ForeColor = Color.Red;
            ERRORText.Location = new Point(304, 24);
            ERRORText.Multiline = true;
            ERRORText.Name = "ERRORText";
            ERRORText.ReadOnly = true;
            ERRORText.Size = new Size(306, 33);
            ERRORText.TabIndex = 19;
            ERRORText.TextChanged += ERRORText_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(304, 6);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 20;
            label4.Text = "ERROR Message";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(EndDistance);
            tabPage1.Controls.Add(TimeToStopIncrement);
            tabPage1.Controls.Add(IncrementToMove);
            tabPage1.Controls.Add(StopInMiddleFirstForTwoButton);
            tabPage1.Controls.Add(DistanceToMove);
            tabPage1.Controls.Add(TimeToStop);
            tabPage1.Controls.Add(SetEndDistanceButton);
            tabPage1.Controls.Add(SetTimeToStopIncremenetButton);
            tabPage1.Controls.Add(IncrementStopTimeButton);
            tabPage1.Controls.Add(SetTimeToStopButton);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(StopInMiddleFirstButton);
            tabPage1.Controls.Add(ExactButton);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(leftButton);
            tabPage1.Controls.Add(RightButton);
            tabPage1.Controls.Add(QuarterButton);
            tabPage1.Controls.Add(ThreeQuarterButon);
            tabPage1.Controls.Add(CenterButton);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(593, 364);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Manual Controls";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // EndDistance
            // 
            EndDistance.Location = new Point(451, 334);
            EndDistance.Name = "EndDistance";
            EndDistance.Size = new Size(127, 23);
            EndDistance.TabIndex = 28;
            EndDistance.Text = "10";
            EndDistance.TextChanged += textBox1_TextChanged;
            // 
            // TimeToStopIncrement
            // 
            TimeToStopIncrement.Location = new Point(182, 335);
            TimeToStopIncrement.Name = "TimeToStopIncrement";
            TimeToStopIncrement.Size = new Size(130, 23);
            TimeToStopIncrement.TabIndex = 26;
            TimeToStopIncrement.Text = "30000";
            // 
            // IncrementToMove
            // 
            IncrementToMove.Location = new Point(182, 304);
            IncrementToMove.Name = "IncrementToMove";
            IncrementToMove.Size = new Size(130, 23);
            IncrementToMove.TabIndex = 23;
            IncrementToMove.Text = "1";
            // 
            // DistanceToMove
            // 
            DistanceToMove.Location = new Point(182, 275);
            DistanceToMove.Name = "DistanceToMove";
            DistanceToMove.Size = new Size(130, 23);
            DistanceToMove.TabIndex = 22;
            DistanceToMove.Text = "1";
            // 
            // SetEndDistanceButton
            // 
            SetEndDistanceButton.Location = new Point(318, 335);
            SetEndDistanceButton.Name = "SetEndDistanceButton";
            SetEndDistanceButton.Size = new Size(127, 23);
            SetEndDistanceButton.TabIndex = 27;
            SetEndDistanceButton.Text = "End Distance (in)";
            SetEndDistanceButton.UseVisualStyleBackColor = true;
            SetEndDistanceButton.Click += SetEndDistanceButton_Click;
            // 
            // SetTimeToStopIncremenetButton
            // 
            SetTimeToStopIncremenetButton.Location = new Point(16, 333);
            SetTimeToStopIncremenetButton.Name = "SetTimeToStopIncremenetButton";
            SetTimeToStopIncremenetButton.Size = new Size(160, 23);
            SetTimeToStopIncremenetButton.TabIndex = 25;
            SetTimeToStopIncremenetButton.Text = "Increment Stop Time (ms)";
            SetTimeToStopIncremenetButton.UseVisualStyleBackColor = true;
            SetTimeToStopIncremenetButton.Click += SetTimeToStopIncremenetButton_Click;
            // 
            // IncrementStopTimeButton
            // 
            IncrementStopTimeButton.AutoSize = true;
            IncrementStopTimeButton.Location = new Point(318, 307);
            IncrementStopTimeButton.Name = "IncrementStopTimeButton";
            IncrementStopTimeButton.Size = new Size(206, 19);
            IncrementStopTimeButton.TabIndex = 24;
            IncrementStopTimeButton.Text = "Automatically Move By Increment";
            IncrementStopTimeButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(16, 304);
            button2.Name = "button2";
            button2.Size = new Size(160, 23);
            button2.TabIndex = 21;
            button2.Text = "Move By Increment (in)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += IncrementButton_Click;
            // 
            // ExactButton
            // 
            ExactButton.Location = new Point(16, 275);
            ExactButton.Name = "ExactButton";
            ExactButton.Size = new Size(160, 23);
            ExactButton.TabIndex = 20;
            ExactButton.Text = "Move To Exact Distance (in)";
            ExactButton.UseVisualStyleBackColor = true;
            ExactButton.Click += ExactButton_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(3, 261);
            label2.Name = "label2";
            label2.Size = new Size(587, 2);
            label2.TabIndex = 19;
            // 
            // leftButton
            // 
            leftButton.Location = new Point(6, 68);
            leftButton.Margin = new Padding(3, 2, 3, 2);
            leftButton.Name = "leftButton";
            leftButton.Size = new Size(275, 68);
            leftButton.TabIndex = 4;
            leftButton.Text = "Move To Left End";
            leftButton.UseVisualStyleBackColor = true;
            leftButton.Click += leftButton_Click;
            // 
            // RightButton
            // 
            RightButton.Location = new Point(312, 68);
            RightButton.Margin = new Padding(3, 2, 3, 2);
            RightButton.Name = "RightButton";
            RightButton.Size = new Size(275, 68);
            RightButton.TabIndex = 5;
            RightButton.Text = "Move To Right End";
            RightButton.UseVisualStyleBackColor = true;
            RightButton.Click += RightButton_Click;
            // 
            // QuarterButton
            // 
            QuarterButton.Location = new Point(74, 141);
            QuarterButton.Name = "QuarterButton";
            QuarterButton.Size = new Size(132, 68);
            QuarterButton.TabIndex = 18;
            QuarterButton.Text = "Move Quarter Way";
            QuarterButton.UseVisualStyleBackColor = true;
            QuarterButton.Click += QuarterButton_Click;
            // 
            // ThreeQuarterButon
            // 
            ThreeQuarterButon.Location = new Point(391, 141);
            ThreeQuarterButon.Name = "ThreeQuarterButon";
            ThreeQuarterButon.Size = new Size(132, 68);
            ThreeQuarterButon.TabIndex = 17;
            ThreeQuarterButon.Text = "Move Three Quarters Way";
            ThreeQuarterButon.UseVisualStyleBackColor = true;
            ThreeQuarterButon.Click += ThreeQuarterButon_Click;
            // 
            // CenterButton
            // 
            CenterButton.Location = new Point(230, 141);
            CenterButton.Margin = new Padding(3, 2, 3, 2);
            CenterButton.Name = "CenterButton";
            CenterButton.Size = new Size(132, 68);
            CenterButton.TabIndex = 8;
            CenterButton.Text = "Move Halfway";
            CenterButton.UseVisualStyleBackColor = true;
            CenterButton.Click += CenterButton_Click;
            // 
            // tab
            // 
            tab.Controls.Add(tabPage1);
            tab.Controls.Add(tabPage4);
            tab.Controls.Add(tabPage3);
            tab.Location = new Point(9, 141);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(601, 392);
            tab.TabIndex = 21;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(textBox2);
            tabPage4.Controls.Add(label5);
            tabPage4.Controls.Add(RepetetiveZoomTestZoomCount);
            tabPage4.Controls.Add(RepetetiveZoomtestStopTime);
            tabPage4.Controls.Add(label23);
            tabPage4.Controls.Add(label22);
            tabPage4.Controls.Add(RepetetiveZoomTestCount);
            tabPage4.Controls.Add(button1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(593, 364);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Repetetive Zoom Test";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(212, 18);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(375, 92);
            textBox2.TabIndex = 14;
            textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(212, 0);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 6;
            label5.Text = "Test Description";
            // 
            // RepetetiveZoomTestZoomCount
            // 
            RepetetiveZoomTestZoomCount.AutoSize = true;
            RepetetiveZoomTestZoomCount.Location = new Point(546, 113);
            RepetetiveZoomTestZoomCount.Name = "RepetetiveZoomTestZoomCount";
            RepetetiveZoomTestZoomCount.Size = new Size(0, 15);
            RepetetiveZoomTestZoomCount.TabIndex = 5;
            // 
            // RepetetiveZoomtestStopTime
            // 
            RepetetiveZoomtestStopTime.Location = new Point(0, 71);
            RepetetiveZoomtestStopTime.Name = "RepetetiveZoomtestStopTime";
            RepetetiveZoomtestStopTime.Size = new Size(203, 23);
            RepetetiveZoomtestStopTime.TabIndex = 4;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(3, 53);
            label23.Name = "label23";
            label23.Size = new Size(153, 15);
            label23.TabIndex = 3;
            label23.Text = "Wait Time At Each End (ms)";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(3, 9);
            label22.Name = "label22";
            label22.Size = new Size(149, 15);
            label22.TabIndex = 2;
            label22.Text = "How Many Times To Zoom";
            // 
            // RepetetiveZoomTestCount
            // 
            RepetetiveZoomTestCount.Location = new Point(3, 27);
            RepetetiveZoomTestCount.Name = "RepetetiveZoomTestCount";
            RepetetiveZoomTestCount.Size = new Size(203, 23);
            RepetetiveZoomTestCount.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(3, 131);
            button1.Name = "button1";
            button1.Size = new Size(587, 230);
            button1.TabIndex = 0;
            button1.Text = "Start Repetetive Zoom Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartRepetetiveZoomTestButton_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(label21);
            tabPage3.Controls.Add(label20);
            tabPage3.Controls.Add(TestOneAttempts);
            tabPage3.Controls.Add(label19);
            tabPage3.Controls.Add(TestOneStartButton);
            tabPage3.Controls.Add(TestOneWaitTime);
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(TestOneIncrementToAdvanceBy);
            tabPage3.Controls.Add(label17);
            tabPage3.Controls.Add(TestOneStopDistance);
            tabPage3.Controls.Add(label16);
            tabPage3.Controls.Add(TestOneStartDistance);
            tabPage3.Controls.Add(label15);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(593, 364);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Repetetive Zoom Increment Test";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 21);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(375, 129);
            textBox1.TabIndex = 13;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(212, 3);
            label21.Name = "label21";
            label21.Size = new Size(90, 15);
            label21.TabIndex = 12;
            label21.Text = "Test Description";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(270, 21);
            label20.Name = "label20";
            label20.Size = new Size(0, 15);
            label20.TabIndex = 11;
            // 
            // TestOneAttempts
            // 
            TestOneAttempts.Location = new Point(6, 197);
            TestOneAttempts.Name = "TestOneAttempts";
            TestOneAttempts.Size = new Size(200, 23);
            TestOneAttempts.TabIndex = 10;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 179);
            label19.Name = "label19";
            label19.Size = new Size(219, 15);
            label19.TabIndex = 9;
            label19.Text = "How Many Times To Zoom At Each Stop";
            // 
            // TestOneStartButton
            // 
            TestOneStartButton.Location = new Point(6, 226);
            TestOneStartButton.Name = "TestOneStartButton";
            TestOneStartButton.Size = new Size(581, 132);
            TestOneStartButton.TabIndex = 8;
            TestOneStartButton.Text = "Start Repetetive Zoom Increment Test";
            TestOneStartButton.UseVisualStyleBackColor = true;
            TestOneStartButton.Click += TestOneStartButton_Click;
            // 
            // TestOneWaitTime
            // 
            TestOneWaitTime.Location = new Point(6, 153);
            TestOneWaitTime.Name = "TestOneWaitTime";
            TestOneWaitTime.Size = new Size(200, 23);
            TestOneWaitTime.TabIndex = 7;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 135);
            label18.Name = "label18";
            label18.Size = new Size(157, 15);
            label18.TabIndex = 6;
            label18.Text = "Wait Time At Each Stop (ms)";
            // 
            // TestOneIncrementToAdvanceBy
            // 
            TestOneIncrementToAdvanceBy.Location = new Point(6, 109);
            TestOneIncrementToAdvanceBy.Name = "TestOneIncrementToAdvanceBy";
            TestOneIncrementToAdvanceBy.Size = new Size(200, 23);
            TestOneIncrementToAdvanceBy.TabIndex = 5;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 91);
            label17.Name = "label17";
            label17.Size = new Size(162, 15);
            label17.TabIndex = 4;
            label17.Text = "Increment To Advance By (in)";
            // 
            // TestOneStopDistance
            // 
            TestOneStopDistance.Location = new Point(6, 65);
            TestOneStopDistance.Name = "TestOneStopDistance";
            TestOneStopDistance.Size = new Size(200, 23);
            TestOneStopDistance.TabIndex = 3;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 47);
            label16.Name = "label16";
            label16.Size = new Size(123, 15);
            label16.TabIndex = 2;
            label16.Text = "Test Stop Distance (in)";
            // 
            // TestOneStartDistance
            // 
            TestOneStartDistance.Location = new Point(6, 21);
            TestOneStartDistance.Name = "TestOneStartDistance";
            TestOneStartDistance.Size = new Size(200, 23);
            TestOneStartDistance.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 3);
            label15.Name = "label15";
            label15.Size = new Size(123, 15);
            label15.TabIndex = 0;
            label15.Text = "Test Start Distance (in)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 565);
            Controls.Add(tab);
            Controls.Add(label4);
            Controls.Add(ERRORText);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(SetBeltSpeed);
            Controls.Add(BeltSpeed);
            Controls.Add(PortNum);
            Controls.Add(SetBD);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Pikachu 3.0";
            Load += Form1_Load;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tab.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SetBD;
        private TextBox PortNum;
        private TextBox BeltSpeed;
        private Button SetBeltSpeed;
        private CheckBox StopInMiddleFirstButton;
        private Button SetTimeToStopButton;
        private TextBox TimeToStop;
        private Label label1;
        private Label label3;
        private CheckBox StopInMiddleFirstForTwoButton;
        private TextBox ERRORText;
        private Label label4;
        private TextBox DebugBoardData;
        private ToolTip AutomatedTestToolTip;
        private TabPage tabPage1;
        private TextBox EndDistance;
        private TextBox TimeToStopIncrement;
        private TextBox IncrementToMove;
        private TextBox DistanceToMove;
        private Button SetEndDistanceButton;
        private Button SetTimeToStopIncremenetButton;
        private CheckBox IncrementStopTimeButton;
        private Button button2;
        private Button ExactButton;
        private Label label2;
        private Button leftButton;
        private Button RightButton;
        private Button QuarterButton;
        private Button ThreeQuarterButon;
        private Button CenterButton;
        private TabControl tab;
        private TabPage tabPage3;
        private TextBox TestOneStartDistance;
        private Label label15;
        private TextBox TestOneIncrementToAdvanceBy;
        private Label label17;
        private TextBox TestOneStopDistance;
        private Label label16;
        private TextBox TestOneWaitTime;
        private Label label18;
        private Button TestOneStartButton;
        private TextBox TestOneAttempts;
        private Label label19;
        private Label label21;
        private Label label20;
        private TextBox textBox1;
        private TabPage tabPage4;
        private Button button1;
        private TextBox RepetetiveZoomTestCount;
        private TextBox RepetetiveZoomtestStopTime;
        private Label label23;
        private Label label22;
        private Label RepetetiveZoomTestZoomCount;
        private TextBox textBox2;
        private Label label5;
    }
}