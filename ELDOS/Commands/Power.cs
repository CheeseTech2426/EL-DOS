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
            /*switch (args[0]) {
                case "shutdown":
                    Cosmos.System.Power.Shutdown();
                    break;
                case "restart":
                    Cosmos.System.Power.Reboot();
                    break;
            }*/
            return res;
        }
    }
}
