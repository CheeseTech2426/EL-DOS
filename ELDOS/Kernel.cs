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
        Panic crashScreen;
        public static CosmosVFS vfs;
        FSC fsc;
        public static bool inRM;

        protected override void BeforeRun() {
            crashScreen = new Panic();
            Panic.CPUHalted = false;
            fsc = new FSC();
            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);
            if (fsc.CheckDirExists(@"0:\Users")) Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\Users");
            if (fsc.CheckDirExists(@"0:\loukoOS")) Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\loukoOS");
            cm = new CommandManager();
            Console.Clear();
            inRM = false;
            if (Sys.KeyboardManager.AltPressed) {
                FSC.StartRM(); // If alt is pressed, start recovery mode (RM)
            }
            if (!fsc.CheckFileExists(@"0:\ELDOS\OOBE.sys")) {
                OOBE.Run();
            } else {
                Console.WriteLine("Starting EL-DOS");
            }
        }

        protected override void Run() {
            if (!Panic.CPUHalted) {
                if (!inRM) {
                    Console.Write("DOS> ");
                    Console.WriteLine(this.cm.processInput(Console.ReadLine()));
                } else {
                    Console.Write("RecoveryMode> ");
                    Console.WriteLine(this.cm.processRecoveryInput(Console.ReadLine()));
                }
            } else {

            }
        }
    }
}
