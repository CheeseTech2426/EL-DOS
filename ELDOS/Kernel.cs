using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using EL_DOS.Commands;
using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace ELDOS {
    public class Kernel : Sys.Kernel {

        CommandManager cm;
        Panic panic;
        public static CosmosVFS vfs;
        public static FSC fsc;
        public static bool inRM;
        public bool isUserCorrect;
        

        public static readonly string UserFolder = @"0:\Users";
        public static readonly string SystemFolder = @"0:\ELDOS\";
        public static readonly string UserMgrPath = @"0:\ELDOS\Usermgr.sys";
        public static readonly string TrashPath = @"0:\Trash\";
        public static readonly string OOBEPath = @"0:\ELDOS\OOBE.sys";

        protected override void BeforeRun() {
            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);
            OOBE.Run();
            panic = new Panic();
            fsc = new FSC();
            cm = new CommandManager();
            
            
            Boot();    // OS Startup processes
            OOBE.loadUserdata();
            UserMgr(); // Login screen
        }

        protected override void Run() {
            if (!Panic.CPUHalted) {
                if (isUserCorrect) {
                    if (!inRM) {
                        Console.Write(">> ");
                        Console.WriteLine(this.cm.processInput(Console.ReadLine()));
                    } else {
                        Console.Write(">> ");
                        Console.WriteLine(this.cm.processRecoveryInput(Console.ReadLine()));
                        OOBE.loadUserdata();
                    }
                } else {
                    Console.Write(">> ");
                    Console.WriteLine(this.cm.processInput(Console.ReadLine()));
                }
            } else {}
        }
        public void UserMgr() {
            if (!Sys.KeyboardManager.AltPressed) {
                Console.WriteLine("Running Usermgr.sys.....");
                Console.WriteLine("Done");
               // Console.Clear();
                isUserCorrect = false;
                Console.WriteLine("Userdata[0]: " + OOBE.userdata[0]);
                var correctUserName = fsc.ReadFromFile(OOBE.userdata[0]);
                Console.WriteLine("Correct username: " + correctUserName.ToString());
                Console.Write("Username: ");
                var username = Console.ReadLine();
                if (username != correctUserName) {
                    Console.WriteLine("Incorrect username!");
                    UserMgr();
                } else if (username == "" || username == null) {
                    Console.WriteLine("Username cannot be empty!");
                    UserMgr();
                } else if (username == correctUserName) {
                    Console.WriteLine("Welcome, " + username + "!");
                    Console.WriteLine("Writing info...");
                    try {
                        fsc.WriteToFile(UserMgrPath, "");
                        fsc.WriteToFile(UserMgrPath, username + "|" + isUserCorrect.ToString());
                    } catch (Exception e) {
                        Panic.panic("Usermgr cannot be found!");
                    }
                    Console.WriteLine("Loading command interface...");

                    isUserCorrect = true;

                }
            } else { inRM = true; return; }
        }

        void Boot() {
            Console.Clear();

            isUserCorrect = false;
            inRM = false;

            // Start the recovery mode if alt is pressed
            if (Sys.KeyboardManager.AltPressed) {
                Console.WriteLine("Starting EL-DOS Recovery Mode...");
                inRM = true;
            }

            if (fsc.CheckFileExists(OOBEPath)) {
                OOBE.storeUserdata();
            }
        }

    }
}
