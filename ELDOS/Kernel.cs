﻿using Cosmos.System.FileSystem;
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
        CrashScreen crashScreen;
        CosmosVFS vfs;
        FSC fsc;
            
        protected override void BeforeRun() {
            crashScreen = new CrashScreen();
            CrashScreen.CPUHalted = false;
            fsc = new FSC();
            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);
            if (fsc.CheckDirExists(@"0:\Users")) Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\Users");
            if (fsc.CheckDirExists(@"0:\loukoOS")) Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\loukoOS");
            cm = new CommandManager();
            Console.Clear();
            
            if (!fsc.CheckFileExists(@"0:\ELDOS\OOBE.sys")) {
                OOBE.Run();
            } else {
                Console.WriteLine("Starting EL-DOS");
            }
        }

        protected override void Run() {
            if (!CrashScreen.CPUHalted) {
                Console.Write("Input: ");
                Console.WriteLine(this.cm.processInput(Console.ReadLine()));
            } else {

            }
        }
    }
}
