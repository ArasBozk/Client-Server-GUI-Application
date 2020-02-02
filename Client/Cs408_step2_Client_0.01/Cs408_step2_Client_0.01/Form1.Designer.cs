namespace Cs408_step2_Client_0._01
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_IPAddress = new System.Windows.Forms.TextBox();
            this.textBox_PortNum = new System.Windows.Forms.TextBox();
            this.inputConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Address:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(193, 29);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(34, 185);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(218, 379);
            this.Console.TabIndex = 3;
            this.Console.Text = "";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(72, 31);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(100, 20);
            this.textBox_UserName.TabIndex = 4;
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(193, 71);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_Disconnect.TabIndex = 5;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(206, 570);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(46, 46);
            this.button_Send.TabIndex = 6;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port Number:";
            // 
            // textBox_IPAddress
            // 
            this.textBox_IPAddress.Location = new System.Drawing.Point(72, 73);
            this.textBox_IPAddress.Name = "textBox_IPAddress";
            this.textBox_IPAddress.Size = new System.Drawing.Size(100, 20);
            this.textBox_IPAddress.TabIndex = 8;
            this.textBox_IPAddress.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox_PortNum
            // 
            this.textBox_PortNum.Location = new System.Drawing.Point(72, 111);
            this.textBox_PortNum.Name = "textBox_PortNum";
            this.textBox_PortNum.Size = new System.Drawing.Size(100, 20);
            this.textBox_PortNum.TabIndex = 9;
            // 
            // inputConsole
            // 
            this.inputConsole.Location = new System.Drawing.Point(34, 570);
            this.inputConsole.Name = "inputConsole";
            this.inputConsole.Size = new System.Drawing.Size(166, 46);
            this.inputConsole.TabIndex = 10;
            this.inputConsole.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 628);
            this.Controls.Add(this.inputConsole);
            this.Controls.Add(this.textBox_PortNum);
            this.Controls.Add(this.textBox_IPAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_IPAddress;
        private System.Windows.Forms.TextBox textBox_PortNum;
        private System.Windows.Forms.RichTextBox inputConsole;
    }
}

