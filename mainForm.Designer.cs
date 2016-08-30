namespace Console
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mainForm_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentID = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip_notify.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.ForeColor = System.Drawing.SystemColors.Info;
            this.txtLog.Location = new System.Drawing.Point(0, 90);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(391, 148);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip_notify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Console";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip_notify
            // 
            this.contextMenuStrip_notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainForm_ToolStripMenuItem,
            this.exit_ToolStripMenuItem});
            this.contextMenuStrip_notify.Name = "contextMenuStrip1";
            this.contextMenuStrip_notify.Size = new System.Drawing.Size(113, 48);
            this.contextMenuStrip_notify.Click += new System.EventHandler(this.contextMenuStrip_notify_Click);
            // 
            // mainForm_ToolStripMenuItem
            // 
            this.mainForm_ToolStripMenuItem.Name = "mainForm_ToolStripMenuItem";
            this.mainForm_ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.mainForm_ToolStripMenuItem.Text = "主窗口";
            this.mainForm_ToolStripMenuItem.Click += new System.EventHandler(this.mainForm_ToolStripMenuItem_Click);
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exit_ToolStripMenuItem.Text = "退出";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(391, 84);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentID});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(391, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentID
            // 
            this.lblCurrentID.Name = "lblCurrentID";
            this.lblCurrentID.Size = new System.Drawing.Size(33, 17);
            this.lblCurrentID.Text = "ID: *";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 261);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtLog);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.main_Load);
            this.contextMenuStrip_notify.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_notify;
        private System.Windows.Forms.ToolStripMenuItem mainForm_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentID;
    }
}

