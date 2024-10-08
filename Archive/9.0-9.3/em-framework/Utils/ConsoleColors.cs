﻿using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Framework.Utils
{
    public static class ConsoleColors
    {
        public static void PrintConsoleColored(string input, ConsoleColor color)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write(Localizer.DoStr($"[{DateTime.Now:hh:mm:ss}] "));

            System.Console.ForegroundColor = color;
            System.Console.Write(Localizer.DoStr(string.Format("{0}\n", input)));

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.ResetColor();
        }

        public static void PrintConsoleMultiColored(string input, ConsoleColor color, string input2, ConsoleColor color2)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write(Localizer.DoStr($"[{DateTime.Now:hh:mm:ss}] "));

            System.Console.ForegroundColor = color;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", input)));

            System.Console.ForegroundColor = color2;
            System.Console.Write(Localizer.DoStr(string.Format("{0}\n", input2)));

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.ResetColor();
        }

        public static void PrintConsoleMultiColored(string input, ConsoleColor color, string input2, ConsoleColor color2, string input3, ConsoleColor color3)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write(Localizer.DoStr($"[{DateTime.Now:hh:mm:ss}] "));

            System.Console.ForegroundColor = color;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", input)));

            System.Console.ForegroundColor = color2;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", input2)));

            System.Console.ForegroundColor = color3;
            System.Console.Write(Localizer.DoStr(string.Format("{0}\n", input3)));

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.ResetColor();
        }

        public static void PrintConsoleMultiColored(string input, ConsoleColor color, string input2, ConsoleColor color2, string input3, ConsoleColor color3, string input4, ConsoleColor color4)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write(Localizer.DoStr($"[{DateTime.Now:hh:mm:ss}] "));

            System.Console.ForegroundColor = color;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", input)));

            System.Console.ForegroundColor = color2;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", input2)));

            System.Console.ForegroundColor = color3;
            System.Console.Write(Localizer.DoStr(string.Format("{0}", input3)));

            System.Console.ForegroundColor = color4;
            System.Console.Write(Localizer.DoStr(string.Format("{0}\n", input4)));

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.ResetColor();
        }

    }
}
