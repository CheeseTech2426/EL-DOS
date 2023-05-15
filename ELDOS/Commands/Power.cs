using EL_DOS.Commands;
using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS.Commands {
    internal class Power : Command {
        public Power(String name) : base(name) { }
        public override string execute(string[] args) {
            string res = "";
            ConsoleKey ck;
            switch (args[0]) {
                case "shutdown":
                    Console.Write("Shutdown? (y/n) ");
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.KeyChar == 'Y' || input.KeyChar == 'y')
                        Cosmos.System.Power.Shutdown();
                    else if (input.KeyChar == 'N' || input.KeyChar == 'n')
                        Console.WriteLine("Shutdown cancelled");
                    else
                        Console.WriteLine("Shutdown cancelled");
                    break;
                case "restart":
                    Console.Write("Restart? (y/n) ");
                    ConsoleKeyInfo input2 = Console.ReadKey();
                    if (input2.KeyChar == 'Y' || input2.KeyChar == 'y')
                        Cosmos.System.Power.Reboot();
                    else if (input2.KeyChar == 'N' || input2.KeyChar == 'n')
                        Console.WriteLine("Restart cancelled");
                    else
                        Console.WriteLine("Restart cancelled");
                    break;
            }
            return res;
        }
    }
}
