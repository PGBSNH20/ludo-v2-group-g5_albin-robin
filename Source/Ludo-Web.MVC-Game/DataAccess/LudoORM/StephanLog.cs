using System;
using System.IO;
using Ludo_Web.MVC_Game.GameEngine.Interfaces;
using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.DataAccess.LudoORM
{
    public class StephanLog : ILog
    {
        private StreamWriter _logger;
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
            _logger = new StreamWriter($@"{Environment.CurrentDirectory}\StephanLogs\stephan_{color.ToString()}{number.ToString()}.log");
        }
        public void Log(string input)
        {
            _logger.Write(input);
            _logger.WriteLine("");
            _logger.Flush();
        }
    }
}