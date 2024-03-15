namespace NetworkingChatApp
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.serverAddressBox = new System.Windows.Forms.TextBox();
            this.ServerAddressLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.Location = new System.Drawing.Point(240, 242);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(294, 52);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(339, 213);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(100, 23);
            this.portBox.TabIndex = 1;
            // 
            // serverAddressBox
            // 
            this.serverAddressBox.Location = new System.Drawing.Point(339, 184);
            this.serverAddressBox.Name = "serverAddressBox";
            this.serverAddressBox.Size = new System.Drawing.Size(100, 23);
            this.serverAddressBox.TabIndex = 2;
            // 
            // ServerAddressLabel
            // 
            this.ServerAddressLabel.AutoSize = true;
            this.ServerAddressLabel.Location = new System.Drawing.Point(246, 187);
            this.ServerAddressLabel.Name = "ServerAddressLabel";
            this.ServerAddressLabel.Size = new System.Drawing.Size(87, 15);
            this.ServerAddressLabel.TabIndex = 3;
            this.ServerAddressLabel.Text = "Server Address:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(301, 216);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(32, 15);
            this.PortLabel.TabIndex = 4;
            this.PortLabel.Text = "Port:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ServerAddressLabel);
            this.Controls.Add(this.serverAddressBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ConnectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ConnectButton;
        private TextBox portBox;
        private TextBox serverAddressBox;
        private Label ServerAddressLabel;
        private Label PortLabel;
    }
}