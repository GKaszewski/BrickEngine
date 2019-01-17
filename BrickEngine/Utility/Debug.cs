using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickEngine.Utility
{
    public class Debug
    {
        public const string logsPath = "Logs/";

        private static void GenerateLog(string log)
        {
            using (var stream = new FileStream(logsPath + "log.log", FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
                writer.WriteLine($"[{DateTime.Now}]" + log);
        }

        public static void Log(string log)
        {
            if (!File.Exists(logsPath + "log.log"))
            {
                Directory.CreateDirectory("Logs");
                GenerateLog(log);
            }
            else
                GenerateLog(log);
        }

    }
}
