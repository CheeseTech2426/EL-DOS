using Cosmos.HAL.BlockDevice;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using EL_DOS.Commands;
using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
                        /*    if (args.Length < 2 || args.Length > 3) {
                                return "Invalid arguments. Usage: format <drive letter> [-quick]";
                            }

                            var driveLetter = args[1];
                            var quickFormat = args.Length == 3 && args[2] == "-quick";

                            // Check if the specified drive exists
                            var driveInfo = Cosmos.System.FileSystem.VFS.VFSManager.GetVolume(driveLetter);
                            if (driveInfo == null) {
                                return $"Drive {driveLetter} does not exist.";
                            }

                            // Prompt user to confirm formatting
                            System.Console.WriteLine($"Are you sure you want to format drive {driveLetter}? (Y/N)");
                            var response = System.Console.ReadKey();
                            System.Console.WriteLine();

                            if (response.Key == ConsoleKey.Y) {
                                // Format the drive
                                Kernel.vfs.F(driveLetter, "FAT32", quickFormat);
                                return $"Drive {driveLetter} was formatted successfully.";
                            } else {
                                return "Format cancelled.";
                            }*/
                        Panic.panic("Format is broken");
                    } catch {
                        System.Console.WriteLine($"Could not format drive");
                    }
                    break;
                case "disks":
                    try {
                        System.Console.WriteLine("Available disks:");
                        foreach (var disk in Cosmos.System.FileSystem.VFS.VFSManager.GetDisks()) {
                            System.Console.WriteLine("- " + string.Format("{0} ({1})", disk.Host, disk.GetType().Name));
                        }
                    } catch (Exception e) {
                        Panic.panic(e.Message);
                    }
                    break;
            }
            return res;
        }

        



    }
}
