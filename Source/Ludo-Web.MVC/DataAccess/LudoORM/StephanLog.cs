using System;
using System.Collections.Generic;
using System.IO;

using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.GameEngine.Interfaces;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.GameEngine
{
    public class StephanLog : ILog
    {
        private StreamWriter Logger;
        public StephanLog(TeamColor color)
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