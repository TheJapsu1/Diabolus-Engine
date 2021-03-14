using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Diabolus_Engine
{
    class DebugConsole
    {
        [DllImport("kernel32")] static extern bool AllocConsole();
        [DllImport("user32.dll")] public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")] [return: MarshalAs(UnmanagedType.Bool)] static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)] static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);
        public const int SW_RESTORE = 9;

        public static void Create()
        {
            AllocConsole();
            Console.Title = "Diabolus debugger";
            Console.WriteLine("Debugging started");
        }

        public static void Log(string text)
        {
            Console.WriteLine(text);
        }

        public static void ConfirmLeave(Game game)
        {
            Focus();
            Console.Beep(300, 200);
            Console.Beep(200, 400);
            Console.WriteLine("Are you sure you want to leave? (y / n)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                game.Exit();
            else
            {
                Console.Write("\b");
                Console.WriteLine("Closing cancelled");
            }
        }

        public static void Focus()
        {
            string originalTitle = Console.Title;
            string title = "Diabolus Debugger";
            Console.Title = title;
            Thread.Sleep(50);
            IntPtr handle = FindWindowByCaption(IntPtr.Zero, title);

            Console.Title = originalTitle;

            ShowWindowAsync(new HandleRef(null, handle), SW_RESTORE);
            SetForegroundWindow(handle);
        }
    }
}
