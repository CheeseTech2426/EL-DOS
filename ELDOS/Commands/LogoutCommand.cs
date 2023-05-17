using EL_DOS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS.Commands {
    internal class LogoutCommand : Command {
        public LogoutCommand(String name) : base(name) { }

        readonly Kernel k;

        public override string execute(string[] args) {
            Console.WriteLine("Logging out...");
            k.UserMgr();
            return "";
        }
    }
}
