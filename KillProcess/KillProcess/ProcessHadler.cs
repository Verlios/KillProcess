using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KillProcess
{
    class ProcessHadler
    {
        public static void FindProcess(string name, int timeLive)
        {
            Console.WriteLine($"Try find process {name}");
            foreach (Process process in Process.GetProcessesByName(name))
            {
                if (process.StartTime.AddMilliseconds(timeLive) < DateTime.Now)
                {
                    process.Kill();
                    Console.WriteLine($"Process {name} completed");
                }
            }

        }
    }
}
