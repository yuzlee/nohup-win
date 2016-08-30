using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Console {
    /// <summary>
    /// 解析JSON配置文件
    /// </summary>
    public static class Json {
        //[DataContract]
        public class CmdItem {
            //[DataMember(Order = 0, IsRequired = true)]
            public string cmd { get; set; }
            //[DataMember(Order = 1)]
            public string args { get; set; }
        }

        public static List<CmdItem> get(string file) {
            try {
                var jsonContent = File.ReadAllText(file);
                List<CmdItem> json;
                json = JsonConvert.DeserializeObject<List<CmdItem>>(jsonContent);
                return json;
            } catch (Exception) {
                return null;
            }
        }
    }
}




