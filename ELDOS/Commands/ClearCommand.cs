using EL_DOS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS.Commands {
    internal class ClearCommand : Command {
        public ClearCommand(String name) : base(name) { }
        public override string execute(string[] args) {
            Console.Clear();
            return "";
        }
    }
}
