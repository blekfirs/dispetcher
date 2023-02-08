using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Menu
    {
        private static bool isShowDetail = false;
        public static MenuActionTupe MenuAction()
        {
            while (true)
            {
                if (!isShowDetail)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow: return MenuActionTupe.Up;
                        case ConsoleKey.DownArrow: return MenuActionTupe.Down;
                        case ConsoleKey.Enter: isShowDetail = true; return MenuActionTupe.ShowDetails;
                    }

                }
                else
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D: return MenuActionTupe.DeleteOne;
                        case ConsoleKey.Delete: return MenuActionTupe.DeleteAll;
                        case ConsoleKey.Backspace: return MenuActionTupe.Back;
                    }
                    isShowDetail = false;
                }
            }
        }


    }
}
