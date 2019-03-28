namespace ChatClient
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_sent = new System.Windows.Forms.TextBox();
            this.textBox_receive = new System.Windows.Forms.TextBox();
            this.listBox_user = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_setting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send.Location = new System.Drawing.Point(660, 256);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(128, 30);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            this.button_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_send_KeyDown);
            // 
            // textBox_sent
            // 
            this.textBox_sent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_sent.Location = new System.Drawing.Point(229, 292);
            this.textBox_sent.Multiline = true;
            this.textBox_sent.Name = "textBox_sent";
            this.textBox_sent.Size = new System.Drawing.Size(559, 144);
            this.textBox_sent.TabIndex = 1;
            this.textBox_sent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_sent_KeyPress);
            // 
            // textBox_receive
            // 
            this.textBox_receive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_receive.Location = new System.Drawing.Point(229, 36);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.ReadOnly = true;
            this.textBox_receive.Size = new System.Drawing.Size(558, 214);
            this.textBox_receive.TabIndex = 2;
            // 
            // listBox_user
            // 
            this.listBox_user.FormattingEnabled = true;
            this.listBox_user.ItemHeight = 12;
            this.listBox_user.Location = new System.Drawing.Point(12, 36);
            this.listBox_user.Name = "listBox_user";
            this.listBox_user.Size = new System.Drawing.Size(211, 400);
            this.listBox_user.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "在线用户：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_setting
            // 
            this.button_setting.Location = new System.Drawing.Point(660, 8);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(127, 22);
            this.button_setting.TabIndex = 6;
            this.button_setting.Text = "个人设置";
            this.button_setting.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_setting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_user);
            this.Controls.Add(this.textBox_receive);
            this.Controls.Add(this.textBox_sent);
            this.Controls.Add(this.button_send);
            this.Name = "MainWindow";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_sent;
        private System.Windows.Forms.TextBox textBox_receive;
        private System.Windows.Forms.ListBox listBox_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_setting;
    }
}

