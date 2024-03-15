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
            this.inputBox = new System.Windows.Forms.TextBox();
            this.UserList = new System.Windows.Forms.ListView();
            this.UserListLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.Location = new System.Drawing.Point(595, 412);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(193, 26);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(688, 383);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(100, 23);
            this.portBox.TabIndex = 1;
            // 
            // serverAddressBox
            // 
            this.serverAddressBox.Location = new System.Drawing.Point(688, 354);
            this.serverAddressBox.Name = "serverAddressBox";
            this.serverAddressBox.Size = new System.Drawing.Size(100, 23);
            this.serverAddressBox.TabIndex = 2;
            // 
            // ServerAddressLabel
            // 
            this.ServerAddressLabel.AutoSize = true;
            this.ServerAddressLabel.Location = new System.Drawing.Point(595, 357);
            this.ServerAddressLabel.Name = "ServerAddressLabel";
            this.ServerAddressLabel.Size = new System.Drawing.Size(87, 15);
            this.ServerAddressLabel.TabIndex = 3;
            this.ServerAddressLabel.Text = "Server Address:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(650, 386);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(32, 15);
            this.PortLabel.TabIndex = 4;
            this.PortLabel.Text = "Port:";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(139, 413);
            this.inputBox.MaxLength = 1024;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(450, 23);
            this.inputBox.TabIndex = 5;
            // 
            // UserList
            // 
            this.UserList.Location = new System.Drawing.Point(12, 27);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(121, 409);
            this.UserList.TabIndex = 6;
            this.UserList.UseCompatibleStateImageBehavior = false;
            // 
            // UserListLabel
            // 
            this.UserListLabel.AutoSize = true;
            this.UserListLabel.Location = new System.Drawing.Point(12, 9);
            this.UserListLabel.Name = "UserListLabel";
            this.UserListLabel.Size = new System.Drawing.Size(35, 15);
            this.UserListLabel.TabIndex = 7;
            this.UserListLabel.Text = "Users";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(688, 325);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserListLabel);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.inputBox);
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
        private TextBox inputBox;
        private ListView UserList;
        private Label UserListLabel;
        private Label label1;
        private TextBox textBox1;
    }
}