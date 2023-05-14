using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.HAL;
using System.Threading.Tasks;
using Cosmos.System;
using s = System;
using ELDOS;

namespace EL_DOS.ELDOS
{
    internal class CrashScreen
    {

        public static bool CPUHalted = false;

        public static void Run(string errorcode, string errormessage)
        {
            Cosmos.System.Kernel kernel;
            s.Console.BackgroundColor = ConsoleColor.Blue;
            s.Console.Clear();
            s.Console.ForegroundColor = ConsoleColor.White;

            s.Console.WriteLine("");
            s.Console.WriteLine("");
            s.Console.WriteLine("");
            s.Console.WriteLine("   System error :(");
            s.Console.WriteLine($"   {errormessage}! Error code: {errorcode}");
            s.Console.WriteLine("   CPU halted. Please restart your machine");
            s.Console.WriteLine("        ,--.!,");
            s.Console.WriteLine("     __/   -*-");
            s.Console.WriteLine("   ,d08b.  '|`");
            s.Console.WriteLine("   0088MM     ");
            s.Console.WriteLine("   `9MMP'     ");
            CPUHalted = true;
            CPU.Halt();
        }
    }
}
