namespace UdpFSX
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.tmrConnected = new System.Windows.Forms.Timer(this.components);
            this.lblXlabel = new System.Windows.Forms.Label();
            this.lblYlabel = new System.Windows.Forms.Label();
            this.lblAltlabel = new System.Windows.Forms.Label();
            this.lblUlabel = new System.Windows.Forms.Label();
            this.lblVlabel = new System.Windows.Forms.Label();
            this.lblWlbl = new System.Windows.Forms.Label();
            this.lblW = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblU = new System.Windows.Forms.Label();
            this.lblAlt = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblQ = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblRlabel = new System.Windows.Forms.Label();
            this.lblQlabel = new System.Windows.Forms.Label();
            this.lblPlabel = new System.Windows.Forms.Label();
            this.lblRollLabel = new System.Windows.Forms.Label();
            this.lblPitchLabel = new System.Windows.Forms.Label();
            this.lblYawLabel = new System.Windows.Forms.Label();
            this.grpLongitudinal = new System.Windows.Forms.GroupBox();
            this.grpLateral = new System.Windows.Forms.GroupBox();
            this.grpOther = new System.Windows.Forms.GroupBox();
            this.lblBeta = new System.Windows.Forms.Label();
            this.lblBetaLbl = new System.Windows.Forms.Label();
            this.lblMach = new System.Windows.Forms.Label();
            this.lblMachLabel = new System.Windows.Forms.Label();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.lblGear = new System.Windows.Forms.Label();
            this.lblGearLbl = new System.Windows.Forms.Label();
            this.lblFlaps = new System.Windows.Forms.Label();
            this.lblFlapsLbl = new System.Windows.Forms.Label();
            this.lblRudder = new System.Windows.Forms.Label();
            this.lblRudderLbl = new System.Windows.Forms.Label();
            this.lblAileron = new System.Windows.Forms.Label();
            this.lblAileronLbl = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.lblThrottleLbl = new System.Windows.Forms.Label();
            this.lblElevator = new System.Windows.Forms.Label();
            this.lblElevatorLabel = new System.Windows.Forms.Label();
            this.grpLongitudinal.SuspendLayout();
            this.grpLateral.SuspendLayout();
            this.grpOther.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(94, 13);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtHistory
            // 
            this.txtHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistory.Location = new System.Drawing.Point(13, 177);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.Size = new System.Drawing.Size(720, 104);
            this.txtHistory.TabIndex = 2;
            // 
            // tmrConnected
            // 
            this.tmrConnected.Interval = 25;
            this.tmrConnected.Tick += new System.EventHandler(this.tmrConnected_Tick);
            // 
            // lblXlabel
            // 
            this.lblXlabel.AutoSize = true;
            this.lblXlabel.Location = new System.Drawing.Point(6, 17);
            this.lblXlabel.Name = "lblXlabel";
            this.lblXlabel.Size = new System.Drawing.Size(17, 13);
            this.lblXlabel.TabIndex = 3;
            this.lblXlabel.Text = "X:";
            // 
            // lblYlabel
            // 
            this.lblYlabel.AutoSize = true;
            this.lblYlabel.Location = new System.Drawing.Point(6, 34);
            this.lblYlabel.Name = "lblYlabel";
            this.lblYlabel.Size = new System.Drawing.Size(17, 13);
            this.lblYlabel.TabIndex = 4;
            this.lblYlabel.Text = "Y:";
            // 
            // lblAltlabel
            // 
            this.lblAltlabel.AutoSize = true;
            this.lblAltlabel.Location = new System.Drawing.Point(6, 51);
            this.lblAltlabel.Name = "lblAltlabel";
            this.lblAltlabel.Size = new System.Drawing.Size(22, 13);
            this.lblAltlabel.TabIndex = 5;
            this.lblAltlabel.Text = "Alt:";
            // 
            // lblUlabel
            // 
            this.lblUlabel.AutoSize = true;
            this.lblUlabel.Location = new System.Drawing.Point(6, 68);
            this.lblUlabel.Name = "lblUlabel";
            this.lblUlabel.Size = new System.Drawing.Size(16, 13);
            this.lblUlabel.TabIndex = 6;
            this.lblUlabel.Text = "u:";
            // 
            // lblVlabel
            // 
            this.lblVlabel.AutoSize = true;
            this.lblVlabel.Location = new System.Drawing.Point(6, 85);
            this.lblVlabel.Name = "lblVlabel";
            this.lblVlabel.Size = new System.Drawing.Size(16, 13);
            this.lblVlabel.TabIndex = 7;
            this.lblVlabel.Text = "v:";
            // 
            // lblWlbl
            // 
            this.lblWlbl.AutoSize = true;
            this.lblWlbl.Location = new System.Drawing.Point(6, 102);
            this.lblWlbl.Name = "lblWlbl";
            this.lblWlbl.Size = new System.Drawing.Size(18, 13);
            this.lblWlbl.TabIndex = 8;
            this.lblWlbl.Text = "w:";
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Location = new System.Drawing.Point(29, 101);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(39, 13);
            this.lblW.TabIndex = 14;
            this.lblW.Text = "<<w>>";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(29, 84);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(37, 13);
            this.lblV.TabIndex = 13;
            this.lblV.Text = "<<v>>";
            // 
            // lblU
            // 
            this.lblU.AutoSize = true;
            this.lblU.Location = new System.Drawing.Point(29, 67);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(37, 13);
            this.lblU.TabIndex = 12;
            this.lblU.Text = "<<u>>";
            // 
            // lblAlt
            // 
            this.lblAlt.AutoSize = true;
            this.lblAlt.Location = new System.Drawing.Point(29, 50);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(51, 13);
            this.lblAlt.TabIndex = 11;
            this.lblAlt.Text = "<<ALT>>";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(29, 33);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(38, 13);
            this.lblY.TabIndex = 10;
            this.lblY.Text = "<<Y>>";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(29, 16);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(38, 13);
            this.lblX.TabIndex = 9;
            this.lblX.Text = "<<X>>";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(43, 102);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(34, 13);
            this.lblR.TabIndex = 26;
            this.lblR.Text = "<<r>>";
            // 
            // lblQ
            // 
            this.lblQ.AutoSize = true;
            this.lblQ.Location = new System.Drawing.Point(43, 85);
            this.lblQ.Name = "lblQ";
            this.lblQ.Size = new System.Drawing.Size(37, 13);
            this.lblQ.TabIndex = 25;
            this.lblQ.Text = "<<q>>";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(43, 68);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(37, 13);
            this.lblP.TabIndex = 24;
            this.lblP.Text = "<<p>>";
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.Location = new System.Drawing.Point(43, 51);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(59, 13);
            this.lblRoll.TabIndex = 23;
            this.lblRoll.Text = "<<ROLL>>";
            // 
            // lblPitch
            // 
            this.lblPitch.AutoSize = true;
            this.lblPitch.Location = new System.Drawing.Point(43, 34);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(63, 13);
            this.lblPitch.TabIndex = 22;
            this.lblPitch.Text = "<<PITCH>>";
            // 
            // lblYaw
            // 
            this.lblYaw.AutoSize = true;
            this.lblYaw.Location = new System.Drawing.Point(43, 17);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(56, 13);
            this.lblYaw.TabIndex = 21;
            this.lblYaw.Text = "<<YAW>>";
            // 
            // lblRlabel
            // 
            this.lblRlabel.AutoSize = true;
            this.lblRlabel.Location = new System.Drawing.Point(6, 102);
            this.lblRlabel.Name = "lblRlabel";
            this.lblRlabel.Size = new System.Drawing.Size(13, 13);
            this.lblRlabel.TabIndex = 20;
            this.lblRlabel.Text = "r:";
            // 
            // lblQlabel
            // 
            this.lblQlabel.AutoSize = true;
            this.lblQlabel.Location = new System.Drawing.Point(6, 85);
            this.lblQlabel.Name = "lblQlabel";
            this.lblQlabel.Size = new System.Drawing.Size(16, 13);
            this.lblQlabel.TabIndex = 19;
            this.lblQlabel.Text = "q:";
            // 
            // lblPlabel
            // 
            this.lblPlabel.AutoSize = true;
            this.lblPlabel.Location = new System.Drawing.Point(6, 68);
            this.lblPlabel.Name = "lblPlabel";
            this.lblPlabel.Size = new System.Drawing.Size(16, 13);
            this.lblPlabel.TabIndex = 18;
            this.lblPlabel.Text = "p:";
            // 
            // lblRollLabel
            // 
            this.lblRollLabel.AutoSize = true;
            this.lblRollLabel.Location = new System.Drawing.Point(6, 51);
            this.lblRollLabel.Name = "lblRollLabel";
            this.lblRollLabel.Size = new System.Drawing.Size(28, 13);
            this.lblRollLabel.TabIndex = 17;
            this.lblRollLabel.Text = "Roll:";
            // 
            // lblPitchLabel
            // 
            this.lblPitchLabel.AutoSize = true;
            this.lblPitchLabel.Location = new System.Drawing.Point(6, 34);
            this.lblPitchLabel.Name = "lblPitchLabel";
            this.lblPitchLabel.Size = new System.Drawing.Size(34, 13);
            this.lblPitchLabel.TabIndex = 16;
            this.lblPitchLabel.Text = "Pitch:";
            // 
            // lblYawLabel
            // 
            this.lblYawLabel.AutoSize = true;
            this.lblYawLabel.Location = new System.Drawing.Point(6, 17);
            this.lblYawLabel.Name = "lblYawLabel";
            this.lblYawLabel.Size = new System.Drawing.Size(31, 13);
            this.lblYawLabel.TabIndex = 15;
            this.lblYawLabel.Text = "Yaw:";
            // 
            // grpLongitudinal
            // 
            this.grpLongitudinal.Controls.Add(this.lblXlabel);
            this.grpLongitudinal.Controls.Add(this.lblYlabel);
            this.grpLongitudinal.Controls.Add(this.lblAltlabel);
            this.grpLongitudinal.Controls.Add(this.lblUlabel);
            this.grpLongitudinal.Controls.Add(this.lblVlabel);
            this.grpLongitudinal.Controls.Add(this.lblWlbl);
            this.grpLongitudinal.Controls.Add(this.lblX);
            this.grpLongitudinal.Controls.Add(this.lblY);
            this.grpLongitudinal.Controls.Add(this.lblAlt);
            this.grpLongitudinal.Controls.Add(this.lblU);
            this.grpLongitudinal.Controls.Add(this.lblV);
            this.grpLongitudinal.Controls.Add(this.lblW);
            this.grpLongitudinal.Location = new System.Drawing.Point(13, 43);
            this.grpLongitudinal.Name = "grpLongitudinal";
            this.grpLongitudinal.Size = new System.Drawing.Size(176, 128);
            this.grpLongitudinal.TabIndex = 27;
            this.grpLongitudinal.TabStop = false;
            this.grpLongitudinal.Text = "Longitudinal";
            // 
            // grpLateral
            // 
            this.grpLateral.Controls.Add(this.lblYawLabel);
            this.grpLateral.Controls.Add(this.lblPitchLabel);
            this.grpLateral.Controls.Add(this.lblR);
            this.grpLateral.Controls.Add(this.lblRollLabel);
            this.grpLateral.Controls.Add(this.lblQ);
            this.grpLateral.Controls.Add(this.lblPlabel);
            this.grpLateral.Controls.Add(this.lblP);
            this.grpLateral.Controls.Add(this.lblQlabel);
            this.grpLateral.Controls.Add(this.lblRoll);
            this.grpLateral.Controls.Add(this.lblRlabel);
            this.grpLateral.Controls.Add(this.lblPitch);
            this.grpLateral.Controls.Add(this.lblYaw);
            this.grpLateral.Location = new System.Drawing.Point(195, 43);
            this.grpLateral.Name = "grpLateral";
            this.grpLateral.Size = new System.Drawing.Size(183, 128);
            this.grpLateral.TabIndex = 28;
            this.grpLateral.TabStop = false;
            this.grpLateral.Text = "Lateral";
            // 
            // grpOther
            // 
            this.grpOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOther.Controls.Add(this.lblBeta);
            this.grpOther.Controls.Add(this.lblBetaLbl);
            this.grpOther.Controls.Add(this.lblMach);
            this.grpOther.Controls.Add(this.lblMachLabel);
            this.grpOther.Location = new System.Drawing.Point(546, 43);
            this.grpOther.Name = "grpOther";
            this.grpOther.Size = new System.Drawing.Size(187, 128);
            this.grpOther.TabIndex = 29;
            this.grpOther.TabStop = false;
            this.grpOther.Text = "Other";
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Location = new System.Drawing.Point(50, 34);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(59, 13);
            this.lblBeta.TabIndex = 3;
            this.lblBeta.Text = "<<BETA>>";
            // 
            // lblBetaLbl
            // 
            this.lblBetaLbl.AutoSize = true;
            this.lblBetaLbl.Location = new System.Drawing.Point(7, 34);
            this.lblBetaLbl.Name = "lblBetaLbl";
            this.lblBetaLbl.Size = new System.Drawing.Size(32, 13);
            this.lblBetaLbl.TabIndex = 2;
            this.lblBetaLbl.Text = "Beta:";
            // 
            // lblMach
            // 
            this.lblMach.AutoSize = true;
            this.lblMach.Location = new System.Drawing.Point(50, 20);
            this.lblMach.Name = "lblMach";
            this.lblMach.Size = new System.Drawing.Size(62, 13);
            this.lblMach.TabIndex = 1;
            this.lblMach.Text = "<<MACH>>";
            // 
            // lblMachLabel
            // 
            this.lblMachLabel.AutoSize = true;
            this.lblMachLabel.Location = new System.Drawing.Point(7, 20);
            this.lblMachLabel.Name = "lblMachLabel";
            this.lblMachLabel.Size = new System.Drawing.Size(37, 13);
            this.lblMachLabel.TabIndex = 0;
            this.lblMachLabel.Text = "Mach:";
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.lblGear);
            this.grpControls.Controls.Add(this.lblGearLbl);
            this.grpControls.Controls.Add(this.lblFlaps);
            this.grpControls.Controls.Add(this.lblFlapsLbl);
            this.grpControls.Controls.Add(this.lblRudder);
            this.grpControls.Controls.Add(this.lblRudderLbl);
            this.grpControls.Controls.Add(this.lblAileron);
            this.grpControls.Controls.Add(this.lblAileronLbl);
            this.grpControls.Controls.Add(this.lblThrottle);
            this.grpControls.Controls.Add(this.lblThrottleLbl);
            this.grpControls.Controls.Add(this.lblElevator);
            this.grpControls.Controls.Add(this.lblElevatorLabel);
            this.grpControls.Location = new System.Drawing.Point(384, 43);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(156, 128);
            this.grpControls.TabIndex = 30;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            // 
            // lblGear
            // 
            this.lblGear.AutoSize = true;
            this.lblGear.Location = new System.Drawing.Point(83, 82);
            this.lblGear.Name = "lblGear";
            this.lblGear.Size = new System.Drawing.Size(61, 13);
            this.lblGear.TabIndex = 11;
            this.lblGear.Text = "<<GEAR>>";
            // 
            // lblGearLbl
            // 
            this.lblGearLbl.AutoSize = true;
            this.lblGearLbl.Location = new System.Drawing.Point(6, 82);
            this.lblGearLbl.Name = "lblGearLbl";
            this.lblGearLbl.Size = new System.Drawing.Size(71, 13);
            this.lblGearLbl.TabIndex = 10;
            this.lblGearLbl.Text = "Landing Gear";
            // 
            // lblFlaps
            // 
            this.lblFlaps.AutoSize = true;
            this.lblFlaps.Location = new System.Drawing.Point(58, 69);
            this.lblFlaps.Name = "lblFlaps";
            this.lblFlaps.Size = new System.Drawing.Size(64, 13);
            this.lblFlaps.TabIndex = 9;
            this.lblFlaps.Text = "<<FLAPS>>";
            // 
            // lblFlapsLbl
            // 
            this.lblFlapsLbl.AutoSize = true;
            this.lblFlapsLbl.Location = new System.Drawing.Point(6, 69);
            this.lblFlapsLbl.Name = "lblFlapsLbl";
            this.lblFlapsLbl.Size = new System.Drawing.Size(32, 13);
            this.lblFlapsLbl.TabIndex = 8;
            this.lblFlapsLbl.Text = "Flaps";
            // 
            // lblRudder
            // 
            this.lblRudder.AutoSize = true;
            this.lblRudder.Location = new System.Drawing.Point(58, 56);
            this.lblRudder.Name = "lblRudder";
            this.lblRudder.Size = new System.Drawing.Size(78, 13);
            this.lblRudder.TabIndex = 7;
            this.lblRudder.Text = "<<RUDDER>>";
            // 
            // lblRudderLbl
            // 
            this.lblRudderLbl.AutoSize = true;
            this.lblRudderLbl.Location = new System.Drawing.Point(6, 56);
            this.lblRudderLbl.Name = "lblRudderLbl";
            this.lblRudderLbl.Size = new System.Drawing.Size(42, 13);
            this.lblRudderLbl.TabIndex = 6;
            this.lblRudderLbl.Text = "Rudder";
            // 
            // lblAileron
            // 
            this.lblAileron.AutoSize = true;
            this.lblAileron.Location = new System.Drawing.Point(58, 43);
            this.lblAileron.Name = "lblAileron";
            this.lblAileron.Size = new System.Drawing.Size(78, 13);
            this.lblAileron.TabIndex = 5;
            this.lblAileron.Text = "<<AILERON>>";
            // 
            // lblAileronLbl
            // 
            this.lblAileronLbl.AutoSize = true;
            this.lblAileronLbl.Location = new System.Drawing.Point(6, 43);
            this.lblAileronLbl.Name = "lblAileronLbl";
            this.lblAileronLbl.Size = new System.Drawing.Size(39, 13);
            this.lblAileronLbl.TabIndex = 4;
            this.lblAileronLbl.Text = "Aileron";
            // 
            // lblThrottle
            // 
            this.lblThrottle.AutoSize = true;
            this.lblThrottle.Location = new System.Drawing.Point(58, 30);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(89, 13);
            this.lblThrottle.TabIndex = 3;
            this.lblThrottle.Text = "<<THROTTLE>>";
            // 
            // lblThrottleLbl
            // 
            this.lblThrottleLbl.AutoSize = true;
            this.lblThrottleLbl.Location = new System.Drawing.Point(6, 30);
            this.lblThrottleLbl.Name = "lblThrottleLbl";
            this.lblThrottleLbl.Size = new System.Drawing.Size(43, 13);
            this.lblThrottleLbl.TabIndex = 2;
            this.lblThrottleLbl.Text = "Throttle";
            // 
            // lblElevator
            // 
            this.lblElevator.AutoSize = true;
            this.lblElevator.Location = new System.Drawing.Point(58, 16);
            this.lblElevator.Name = "lblElevator";
            this.lblElevator.Size = new System.Drawing.Size(88, 13);
            this.lblElevator.TabIndex = 1;
            this.lblElevator.Text = "<<ELEVATOR>>";
            // 
            // lblElevatorLabel
            // 
            this.lblElevatorLabel.AutoSize = true;
            this.lblElevatorLabel.Location = new System.Drawing.Point(6, 16);
            this.lblElevatorLabel.Name = "lblElevatorLabel";
            this.lblElevatorLabel.Size = new System.Drawing.Size(46, 13);
            this.lblElevatorLabel.TabIndex = 0;
            this.lblElevatorLabel.Text = "Elevator";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 293);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.grpOther);
            this.Controls.Add(this.grpLateral);
            this.Controls.Add(this.grpLongitudinal);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainForm";
            this.Text = "FSX Udp Connector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpLongitudinal.ResumeLayout(false);
            this.grpLongitudinal.PerformLayout();
            this.grpLateral.ResumeLayout(false);
            this.grpLateral.PerformLayout();
            this.grpOther.ResumeLayout(false);
            this.grpOther.PerformLayout();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.Timer tmrConnected;
        private System.Windows.Forms.Label lblXlabel;
        private System.Windows.Forms.Label lblYlabel;
        private System.Windows.Forms.Label lblAltlabel;
        private System.Windows.Forms.Label lblUlabel;
        private System.Windows.Forms.Label lblVlabel;
        private System.Windows.Forms.Label lblWlbl;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblU;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblRlabel;
        private System.Windows.Forms.Label lblQlabel;
        private System.Windows.Forms.Label lblPlabel;
        private System.Windows.Forms.Label lblRollLabel;
        private System.Windows.Forms.Label lblPitchLabel;
        private System.Windows.Forms.Label lblYawLabel;
        private System.Windows.Forms.GroupBox grpLongitudinal;
        private System.Windows.Forms.GroupBox grpLateral;
        private System.Windows.Forms.GroupBox grpOther;
        private System.Windows.Forms.Label lblMach;
        private System.Windows.Forms.Label lblMachLabel;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Label lblGear;
        private System.Windows.Forms.Label lblGearLbl;
        private System.Windows.Forms.Label lblFlaps;
        private System.Windows.Forms.Label lblFlapsLbl;
        private System.Windows.Forms.Label lblRudder;
        private System.Windows.Forms.Label lblRudderLbl;
        private System.Windows.Forms.Label lblAileron;
        private System.Windows.Forms.Label lblAileronLbl;
        private System.Windows.Forms.Label lblThrottle;
        private System.Windows.Forms.Label lblThrottleLbl;
        private System.Windows.Forms.Label lblElevator;
        private System.Windows.Forms.Label lblElevatorLabel;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Label lblBetaLbl;
    }
}

