using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS {
    internal class OOBE {

        public static List<string> userdata = new List<string>();

        public static void Run() {
            Console.WriteLine("Welcome to EL-DOS");
            
            Console.Write("What is your name? ");
            var username = Console.ReadLine();

            Console.Write("Password? ");
            var password = Console.ReadLine();
            OOBE.handle(username, password, Kernel.fsc);
        }

        private static void handle(string username, string password, FSC fsc) {
            try {

                string passwordFilePath = $@"0:\ELDOS\{username}pw.user";
                string userFilePath = $@"0:\ELDOS\{username}us.user";
                    
                userdata.Add(userFilePath);
                userdata.Add(passwordFilePath);

                OOBE.storeUserdata();

                if (fsc.CheckFileExists(passwordFilePath)) {
                    fsc.WriteToFile(passwordFilePath, "");
                    fsc.RmFile(passwordFilePath);
                }

                if (fsc.CheckFileExists(userFilePath)) {
                    fsc.WriteToFile(userFilePath, "");
                    fsc.RmFile(userFilePath);
                }

                fsc.CreateFile(passwordFilePath);
                fsc.CreateFile(userFilePath);

                fsc.WriteToFile(userFilePath, username);
                fsc.WriteToFile(passwordFilePath, password);
                Console.WriteLine("Files created successfully.");
            } catch { }
        }

        public static void storeUserdata() {
            Console.WriteLine("Writing userdata......");
            try {
                System.IO.File.WriteAllText(Kernel.OOBEPath, "");
                System.IO.File.WriteAllLines(Kernel.OOBEPath, userdata);
                Console.WriteLine("Successfully wrote userdata.");
                return;
            } catch {
                Console.WriteLine("Failed to write userdata!");
                return;
            }
        }

        public static void loadUserdata() {
            Console.WriteLine("Reading userdata......");
            try {
                string data = System.IO.File.ReadAllText(Kernel.OOBEPath);
                Console.WriteLine(data);
                Console.WriteLine("Successfully read userdata.");
                return;
            } catch {
                Console.WriteLine("Failed to read userdata!");
                return;
            }
        }
    }
}
