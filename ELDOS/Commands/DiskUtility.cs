using Cosmos.System.FileSystem;
using EL_DOS.Commands;
using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS.Commands {
    internal class DiskUtility : Command {
        public DiskUtility(String name) : base(name) { }

        public FSC fsc;
        string disk = @"0:\";
        Disk d;

        public override string execute(string[] args) {
            fsc = new FSC();
            string res = "";
            switch (args[0]) {
                case "freeram":
                    try {
                        res = fsc.GetRAM().ToString();
                        break;
                    } catch (Exception ex) {
                        res = "";
                        Panic.panic("", ex.Message);
                        break;
                    }
                case "fstype":
                    try {
                        res = fsc.GetFsType(disk).ToString();
                        break;
                    } catch (Exception ex) {
                        res = "";
                        Panic.panic("", ex.Message);
                        break;
                    }
                case "totalspace":
                    try {
                        res = fsc.GetDiskSize(disk).ToString();
                        break;
                    } catch (Exception ex) {
                        res = "";
                        Panic.panic("", ex.Message);
                        break;
                    }
                case "format":
                    try {
                        
                       
                    } catch {
                        Console.WriteLine($"Could not format drive");
                    }
                    break;
            }
            return res;
        }

    }
}
