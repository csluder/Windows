namespace bus_pirate
{
    partial class busPirate
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
            this.comPort = new System.Windows.Forms.ComboBox();
            this.baudRate = new System.Windows.Forms.ComboBox();
            this.connect = new System.Windows.Forms.Button();
            this.serialBox = new System.Windows.Forms.GroupBox();
            this.rescan = new System.Windows.Forms.Button();
            this.baudLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.clock = new System.Windows.Forms.Button();
            this.serialBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // comPort
            // 
            this.comPort.FormattingEnabled = true;
            this.comPort.Location = new System.Drawing.Point(8, 50);
            this.comPort.Margin = new System.Windows.Forms.Padding(4);
            this.comPort.Name = "comPort";
            this.comPort.Size = new System.Drawing.Size(160, 28);
            this.comPort.TabIndex = 0;
            this.comPort.SelectedIndexChanged += new System.EventHandler(this.comPort_SelectedIndexChanged);
            // 
            // baudRate
            // 
            this.baudRate.FormattingEnabled = true;
            this.baudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.baudRate.Location = new System.Drawing.Point(200, 50);
            this.baudRate.Margin = new System.Windows.Forms.Padding(4);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(160, 28);
            this.baudRate.TabIndex = 1;
            this.baudRate.SelectedIndexChanged += new System.EventHandler(this.baudRate_SelectedIndexChanged);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(261, 103);
            this.connect.Margin = new System.Windows.Forms.Padding(4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(100, 28);
            this.connect.TabIndex = 2;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // serialBox
            // 
            this.serialBox.Controls.Add(this.rescan);
            this.serialBox.Controls.Add(this.baudLabel);
            this.serialBox.Controls.Add(this.portLabel);
            this.serialBox.Controls.Add(this.connect);
            this.serialBox.Controls.Add(this.comPort);
            this.serialBox.Controls.Add(this.baudRate);
            this.serialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialBox.Location = new System.Drawing.Point(57, 38);
            this.serialBox.Margin = new System.Windows.Forms.Padding(4);
            this.serialBox.Name = "serialBox";
            this.serialBox.Padding = new System.Windows.Forms.Padding(4);
            this.serialBox.Size = new System.Drawing.Size(388, 148);
            this.serialBox.TabIndex = 3;
            this.serialBox.TabStop = false;
            this.serialBox.Text = "Serial Port";
            // 
            // rescan
            // 
            this.rescan.Location = new System.Drawing.Point(74, 103);
            this.rescan.Name = "rescan";
            this.rescan.Size = new System.Drawing.Size(94, 28);
            this.rescan.TabIndex = 5;
            this.rescan.Text = "Rescan";
            this.rescan.UseVisualStyleBackColor = true;
            this.rescan.Click += new System.EventHandler(this.rescan_Click);
            // 
            // baudLabel
            // 
            this.baudLabel.AutoSize = true;
            this.baudLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baudLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.baudLabel.Location = new System.Drawing.Point(196, 26);
            this.baudLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.baudLabel.Name = "baudLabel";
            this.baudLabel.Size = new System.Drawing.Size(47, 20);
            this.baudLabel.TabIndex = 4;
            this.baudLabel.Text = "Baud";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.portLabel.Location = new System.Drawing.Point(8, 26);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(38, 20);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "Port";
            // 
            // serialPort1
            // 
            this.serialPort1.RtsEnable = true;
            // 
            // clock
            // 
            this.clock.Location = new System.Drawing.Point(57, 230);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(99, 32);
            this.clock.TabIndex = 4;
            this.clock.Text = "Clock Demo";
            this.clock.UseVisualStyleBackColor = true;
            this.clock.Click += new System.EventHandler(this.clock_Click);
            // 
            // busPirate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 318);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.serialBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "busPirate";
            this.Text = "Bus Pirate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.serialBox.ResumeLayout(false);
            this.serialBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comPort;
        private System.Windows.Forms.ComboBox baudRate;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.GroupBox serialBox;
        private System.Windows.Forms.Label baudLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button rescan;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button clock;

    }
}

