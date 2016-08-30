using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Console {
    public class CmdInvoke {
        //public class CmdResult {
        //    public int id { get; set; }
        //    public string result { get; set; }

        //    CmdResult(int id, string result) {
        //        this.id = id;
        //        this.result = result;
        //    }

        //    public static implicit operator string(CmdResult _result) {
        //        return _result.result;
        //    }

        //    public static implicit operator CmdResult(string _result) {
        //        return new CmdResult(1, _result);
        //    }
        //}

        public delegate void CmdStdOutHandler(string result,  int id);
        public delegate void CmdErrOutHandler(string result, int id);

        public delegate object InvokeHandler(Delegate method, params object[] args);

        public delegate void ExitCallbackHandler(int id);

        private event CmdStdOutHandler stdOut;
        private event CmdErrOutHandler errOut;
        private event InvokeHandler invoke;
        private event ExitCallbackHandler exitCb;

        private string file { get; set; }
        private string args { get; set; }

        public int id { get; set; }


        public CmdInvoke(InvokeHandler cb, CmdStdOutHandler std, CmdErrOutHandler err, ExitCallbackHandler exit) {
            invoke += new InvokeHandler(cb);
            stdOut += new CmdStdOutHandler(std);
            errOut += new CmdErrOutHandler(err);
            exitCb += new ExitCallbackHandler(exit);
        }

        public CmdInvoke(int id, string file,string args, InvokeHandler cb, CmdStdOutHandler std, CmdErrOutHandler err, ExitCallbackHandler exit) {
            this.id = id;
            this.file = file;
            this.args = args;
            invoke += new InvokeHandler(cb);
            stdOut += new CmdStdOutHandler(std);
            errOut += new CmdErrOutHandler(err);
            exitCb += new ExitCallbackHandler(exit);
        }

        public void start() {
            start(file, args);
        }

        public void start(string StartFileName, string StartFileArg) {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = StartFileName;      // 命令  
            CmdProcess.StartInfo.Arguments = StartFileArg;      // 参数  

            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
                                                                //CmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  

            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            CmdProcess.EnableRaisingEvents = true;                      // 启用Exited事件  
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);   // 注册进程结束事件  

            CmdProcess.Start();
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();

            // 如果打开注释，则以同步方式执行命令，此例子中用Exited事件异步执行。  
            // CmdProcess.WaitForExit();       
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data != null) {
                // 4. 异步调用，需要invoke  
                invoke(stdOut, e.Data, this.id);
            }
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data != null) {
                invoke(errOut, e.Data, this.id);
            }
        }

        private void CmdProcess_Exited(object sender, EventArgs e) {
            exitCb(this.id);
        }

    }
}
