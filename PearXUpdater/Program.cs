using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PearXUpdater
{
    class Program
    {
        static void Main()
        {
            /*
            Example pearxupdaterinfo file:
            game.exe - Process name
            game.exe - Main exe name
            C:\lib.dll         \
            C:\cfg.txt         |
            D:\info.db         | - File names for update. New files must be in "new.{filename}" format.
            E:\langs\main.lang |
            ...                /
            */
            List<string> info =
                File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/pearxupdaterinfo").ToList();
            Console.WriteLine("Waiting for closing application...");
            Process[] pl = Process.GetProcessesByName(info[0]);
            while (pl.Length != 0)
            {
                pl = Process.GetProcessesByName(info[0]);
            }
            Console.WriteLine("Updating...");
            foreach (string str in info.Skip(2))
            {
                File.Delete(str);
                File.Move(Path.GetDirectoryName(str) + "/new." + Path.GetFileName(str), str);
            }
            Process.Start(info[1]);
        }
    }
}
