namespace Cs408_step2_deneme_0._01
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
            this.Console = new System.Windows.Forms.RichTextBox();
            this.OpenServer = new System.Windows.Forms.Button();
            this.textBox_PortNum = new System.Windows.Forms.TextBox();
            this.label_portNumber = new System.Windows.Forms.Label();
            this.CloseServer = new System.Windows.Forms.Button();
            this.button_StartGame = new System.Windows.Forms.Button();
            this.textBox_RoundNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(15, 210);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(336, 449);
            this.Console.TabIndex = 0;
            this.Console.Text = "";
            this.Console.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // OpenServer
            // 
            this.OpenServer.Location = new System.Drawing.Point(25, 72);
            this.OpenServer.Name = "OpenServer";
            this.OpenServer.Size = new System.Drawing.Size(75, 23);
            this.OpenServer.TabIndex = 1;
            this.OpenServer.Text = "Open Server";
            this.OpenServer.UseVisualStyleBackColor = true;
            this.OpenServer.Click += new System.EventHandler(this.OpenServer_Click);
            // 
            // textBox_PortNum
            // 
            this.textBox_PortNum.Location = new System.Drawing.Point(15, 46);
            this.textBox_PortNum.Name = "textBox_PortNum";
            this.textBox_PortNum.Size = new System.Drawing.Size(100, 20);
            this.textBox_PortNum.TabIndex = 2;
            // 
            // label_portNumber
            // 
            this.label_portNumber.AutoSize = true;
            this.label_portNumber.Location = new System.Drawing.Point(31, 30);
            this.label_portNumber.Name = "label_portNumber";
            this.label_portNumber.Size = new System.Drawing.Size(69, 13);
            this.label_portNumber.TabIndex = 3;
            this.label_portNumber.Text = "Port Number:";
            // 
            // CloseServer
            // 
            this.CloseServer.Location = new System.Drawing.Point(25, 101);
            this.CloseServer.Name = "CloseServer";
            this.CloseServer.Size = new System.Drawing.Size(75, 23);
            this.CloseServer.TabIndex = 4;
            this.CloseServer.Text = "Close Server";
            this.CloseServer.UseVisualStyleBackColor = true;
            this.CloseServer.Click += new System.EventHandler(this.CloseServer_Click);
            // 
            // button_StartGame
            // 
            this.button_StartGame.Location = new System.Drawing.Point(208, 72);
            this.button_StartGame.Name = "button_StartGame";
            this.button_StartGame.Size = new System.Drawing.Size(100, 74);
            this.button_StartGame.TabIndex = 5;
            this.button_StartGame.Text = "Start Game";
            this.button_StartGame.UseVisualStyleBackColor = true;
            this.button_StartGame.Click += new System.EventHandler(this.button_StartGame_Click);
            // 
            // textBox_RoundNo
            // 
            this.textBox_RoundNo.Location = new System.Drawing.Point(208, 46);
            this.textBox_RoundNo.Name = "textBox_RoundNo";
            this.textBox_RoundNo.Size = new System.Drawing.Size(100, 20);
            this.textBox_RoundNo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server Activity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Round No:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 671);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_RoundNo);
            this.Controls.Add(this.button_StartGame);
            this.Controls.Add(this.CloseServer);
            this.Controls.Add(this.label_portNumber);
            this.Controls.Add(this.textBox_PortNum);
            this.Controls.Add(this.OpenServer);
            this.Controls.Add(this.Console);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.Button OpenServer;
        private System.Windows.Forms.TextBox textBox_PortNum;
        private System.Windows.Forms.Label label_portNumber;
        private System.Windows.Forms.Button CloseServer;
        private System.Windows.Forms.Button button_StartGame;
        private System.Windows.Forms.TextBox textBox_RoundNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

