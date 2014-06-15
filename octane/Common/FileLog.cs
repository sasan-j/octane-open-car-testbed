using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenCarTestbed.Common
{
    class FileLog
    {
        public static void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }


        public static void PacketLog(string header,string body)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                bool flag = false;
                if (File.Exists(path+"\\PacketLog.txt"))
                    flag = true;

                using (StreamWriter w = File.AppendText(path+"\\PacketLog.txt"))
                {
                    if (flag)
                        w.WriteLine("{0}", body);
                    else
                        w.WriteLine("{0}", header + body);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.NewLogEntry("Log to file", string.Format("filename not found, {0}", ex.Message));
                FileLog.Log(ex.Message);
            }
        }

    }
}
