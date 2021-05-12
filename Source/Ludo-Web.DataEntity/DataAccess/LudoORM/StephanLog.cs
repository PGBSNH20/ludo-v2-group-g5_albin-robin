using System;
using System.IO;
using Ludo_Web.DataEntity.Models;
using Ludo_Web.Engine.Interfaces;

namespace Ludo_Web.DataEntity.DataAccess.LudoORM
{
    public class StephanLog : ILog
    {
        private StreamWriter Logger;
        public StephanLog(ModelEnum.TeamColor color)
        {
            int number = 0;
            if (!Directory.Exists(Environment.CurrentDirectory + @"\StephanLogs")) Directory.CreateDirectory(Environment.CurrentDirectory + @"\StephanLogs");
            foreach (FileInfo finf in new DirectoryInfo(Environment.CurrentDirectory + @"\StephanLogs").GetFiles())
            {
                if (finf.Name.StartsWith($"stephan_{color.ToString()}") && finf.Extension == ".log")
                {
                    number++;
                }
            }
            Logger = new StreamWriter($@"{Environment.CurrentDirectory}\StephanLogs\stephan_{color.ToString()}{number.ToString()}.log");
        }
        public void Log(string input)
        {
            Logger.Write(input);
            Logger.WriteLine("");
            Logger.Flush();
        }
    }
}