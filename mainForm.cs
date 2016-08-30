using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Console {
    public partial class mainForm : Form {

        private string jsonFile { get; set; }

        private delegate void ChangedCallBackHandler(string result, int id);

        private event ChangedCallBackHandler changed = (string result, int id) => { };

        public List<CmdInvoke> cmdList;
        public List<StringBuilder> cmdResult;

        public mainForm(string[] args = null) {
            InitializeComponent();

            this.FormClosing += form_closing;
            this.Resize += form_resize;

            this.notifyIcon1.Click += NotifyIcon1_Click;

            if (args.Length > 0) {
                jsonFile = args[0];
            } else {
                jsonFile = "config.json";
            }
        }

        private void NotifyIcon1_Click(object sender, EventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            
        }

        private void main_Load(object sender, EventArgs e) {
            var json = Json.get(jsonFile);
            //var json = Json.get("config.json");
            if (json == null) {
                notifyIcon1.ShowBalloonTip(1000, notifyIcon1.Text, "Invalid config.json", ToolTipIcon.Error);
                notifyIcon1.Dispose();
                System.Environment.Exit(1);
            }

            var count = json.Count;
            cmdList = new List<CmdInvoke>(count);
            cmdResult = new List<StringBuilder>(count);
            for (var i = 0; i < count; i++) {
                var item = json[i];
                listBox1.Items.Add("[" + i + "] " + item.cmd + " " + item.args);
                cmdResult.Add(new StringBuilder());
                cmdList.Add(cmd(i, item.cmd, item.args,
                    (string result, int id) => {
                        cmdResult[id].AppendLine(result);
                        changed.Invoke(result, id);
                        //lblProcessing.Text = "[" + id + "] " + result;
                    }));
                cmdList[i].start();
            }
        }

        private void form_closing(object sender, FormClosingEventArgs e) {
            var mbox = MessageBox.Show("Exit? Cancel for minimize the app to tray.", "Tip",MessageBoxButtons.OKCancel);
            if (mbox == DialogResult.Cancel) {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, notifyIcon1.Text, "The app is running here.", ToolTipIcon.Info);
            } else {
                notifyIcon1.Dispose();
            }
        }

        private void form_closed(object sender, FormClosedEventArgs e) {
            notifyIcon1.Dispose();
        }

        private void form_resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            txtLog.Clear();
            var index = listBox1.SelectedIndex;

            if (index > -1) {
                txtLog.Text = cmdResult[index].ToString();
            }

            lblCurrentID.Text = "ID: " + index;

            changed = (string result, int id) => {
                if (id == index) {
                    txtLog.Text = cmdResult[id].ToString();
                }
            };
        }


        #region 封装的CmdInvoke

        public CmdInvoke cmd(int id, string file, string args, CmdInvoke.CmdStdOutHandler stdout) {
            return new CmdInvoke(id, file, args, this.Invoke, stdout,
                (string result, int _id) => {
                    //MessageBox.Show(result);
                    notifyIcon1.ShowBalloonTip(1000, notifyIcon1.Text, result, ToolTipIcon.Error);
                },
                (int _id) => {
                    //MessageBox.Show("Exit the cmd.");
                    notifyIcon1.ShowBalloonTip(1000, notifyIcon1.Text,
                        "The cmd [" + _id + "][" + file + " " + args + "] has exited.", ToolTipIcon.Info);
                });
        }


        #endregion

        private void mainForm_ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Environment.Exit(0);
        }

        private void txtLog_TextChanged(object sender, EventArgs e) {
            txtLog.SelectionStart = txtLog.Text.Length; //Set the current caret position at the end
            txtLog.ScrollToCaret(); //Now scroll it automatically
        }

        private void contextMenuStrip_notify_Click(object sender, EventArgs e) {
            this.Show();
        }
    }
}
