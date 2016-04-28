namespace WindowsFormsApplication1
{
    partial class comPort
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
            this.Rescan = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Rescan
            // 
            this.Rescan.Location = new System.Drawing.Point(197, 227);
            this.Rescan.Name = "Rescan";
            this.Rescan.Size = new System.Drawing.Size(75, 23);
            this.Rescan.TabIndex = 0;
            this.Rescan.Text = "Rescan";
            this.Rescan.UseVisualStyleBackColor = true;
            this.Rescan.Click += new System.EventHandler(this.Rescan_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 199);
            this.listBox1.TabIndex = 1;
            // 
            // comPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Rescan);
            this.Name = "comPort";
            this.Text = "Chuck\'s Port Scanner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Rescan;
        private System.Windows.Forms.ListBox listBox1;
    }
}

