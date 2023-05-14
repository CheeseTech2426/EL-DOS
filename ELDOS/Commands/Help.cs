using EL_DOS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS.Commands {
    public class Help : Command {
        public Help(String name) : base(name) { }
        public override string execute(string[] args) {
            return "Test";
        }
    }
}
