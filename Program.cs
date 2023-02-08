using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static Process[] proc;
        private static int c = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                PrintProc();
                switch (Menu.MenuAction())
                {
                    case MenuActionTupe.Up:
                        c--;
                        if (c < 0)
                            c = proc.Length-1;
                        PrintProc();
                        break;

                    case MenuActionTupe.Down:
                        c++;
                        if (c == proc.Length - 1)
                            c = 0;
                        PrintProc();
                        break;
                    case MenuActionTupe.ShowDetails:
                        PrintDedal(proc[c]);
                        break;
                }
                while (Console.KeyAvailable)
                    Console.ReadKey(false);
            }
        }


        private static void PrintProc()
        {
            Console.WriteLine("Диспетчер задач");
            Console.WriteLine("   Название                    Занято памяти(байт)             Кол-во потоков");
            proc = Process.GetProcesses();
            for (int i = 0; i < proc.Length; i++)
            {
                if (i == c)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("-> ");
                    Console.Write($"{proc[i].ProcessName.PadRight(30)} {proc[i].PagedMemorySize64.ToString().PadRight(36)}{proc[i].Threads.Count}\n");

                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                    Console.Write($"{proc[i].ProcessName.PadRight(30)} {proc[i].PagedMemorySize64.ToString().PadRight(36)}{proc[i].Threads.Count}\n");
                }
            }
        }

        private static void PrintDedal(Process process)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"Имя:                 {process.ProcessName}");
                    Console.WriteLine($"Ид:                  {process.Id}");
                    Console.WriteLine($"Занято памяти (байт) {process.PagedSystemMemorySize64}");
                    Console.WriteLine($"временный буст:      {process.PriorityBoostEnabled}");
                    Console.WriteLine($"Время запуска:       {process.StartTime}");
                    Console.WriteLine($"Кол-во потоков:      {process.Threads.Count}");
                    Console.WriteLine($"Аргументы запуска:   {process.StartInfo.Arguments}");
                    switch (Menu.MenuAction())
                    {
                        case MenuActionTupe.Back:
                            Console.Clear();
                            PrintProc();
                            return;
                        case MenuActionTupe.DeleteOne:
                            process.Kill();
                            break;
                        case MenuActionTupe.DeleteAll:
                            foreach (Process p in proc)
                                if (p.ProcessName == process.ProcessName)
                                    p.Kill();
                            proc = Process.GetProcesses();
                            break;
                    }
                }
                catch
                {
                    
                    Console.WriteLine("Отказонно в доступе");
                }
                finally
                {

                }
            }

        }
    }
}
