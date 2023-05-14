using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS {
    internal class OOBE {

        public FSC fsc;

        public static void Run() {
            var fsc = new FSC();
            Console.Clear();
            Console.WriteLine("Welcome to EL-DOS");
            Console.Write("What is your name? ");
            var username = Console.ReadLine();
            HandleOOBEIO(username, fsc);
        }

        public static void HandleOOBEIO(string user, FSC fsc) {
            if (user == null || user == "" || user == " ") { Console.WriteLine("Your name cannot be empty!"); OOBE.Run(); } else {
                if (fsc.CheckDirExists(@"0:\ELDOS\")) {
                    if (fsc.CheckFileExists(@"0:\ELDOS\OOBE.sys")) { } else {
                        fsc.CreateFile(@"0:\ELDOS\OOBE.sys");
                        fsc.WriteToFile(@"0:\ELDOS\OOBE.sys", user);
                    }
                } else {
                    fsc.CreateDir(@"0:\ELDOS\");
                    if (fsc.CheckFileExists(@"0:\ELDOS\OOBE.sys")) { } else {
                        fsc.CreateFile(@"0:\ELDOS\OOBE.sys");
                        fsc.WriteToFile(@"0:\ELDOS\OOBE.sys", user);
                    }
                }
            }
        }
    }
}
