using EL_DOS.Commands;
using EL_DOS.ELDOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace loukoOS.Commands {
    public class FileCommand : Command {
        public FileCommand(String name) : base(name) { }

        public FSC fsc;

        public override string execute(string[] args) {
            fsc = new FSC();
            String response = "";

            switch (args[0]) {

                case "create":
                    try {
                        if (!fsc.CheckFileExists(args[1])) {
                            Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\" + args[1]);
                            response = "File " + args[1] + " was created successfully";
                        }
                        
                    } catch (Exception ex) {
                        response = "";
                        CrashScreen.Run("", ex.Message);
                        break;
                    }
                    break;

                case "delete":

                    try {
                        if (fsc.CheckFileExists(args[1])) {
                            Sys.FileSystem.VFS.VFSManager.DeleteFile(@"0:\" + args[1]);
                            response = "File " + args[1] + " was deleted successfully";
                        } else {
                            response = "The file '" + args[1] + "' doesn't exist";
                            break;
                        }
                      
                    } catch (Exception ex) {

                        response = ex.ToString();
                        CrashScreen.Run("", response);
                        break;

                    }
                    break;


                case "mkdir":
                    try {
                        if (!fsc.CheckDirExists(args[1])) {
                            Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\" + args[1]);
                            response = "Folder " + args[1] + " was created successfully";
                        } else {
                            response = "Folder " + args[1] + " wasn't created successfully";
                            break;
                        }
                    } catch (Exception ex) {
                        response = ex.ToString();
                        CrashScreen.Run("", response);
                        break;
                    }
                    break;

                case "rmdir":
                    try {
                        if (fsc.CheckDirExists(args[1])) {
                            Sys.FileSystem.VFS.VFSManager.DeleteDirectory(@"0:\" + args[1], true);
                            response = "Folder " + args[1] + " was deleted successfully";
                        } else {
                            response = "Access Denied";
                            break;

                        }
                    } catch (Exception ex) {
                        response = ex.ToString();
                        CrashScreen.Run("", response);
                        break;
                    }
                    break;




                case "write":
                    try {
                       
                        if (fsc.CheckFileExists(args[1])) {
                            FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + args[1]).GetFileStream();
                            if (fs.CanWrite) {
                                int ctr = 0;
                                StringBuilder sb = new StringBuilder();
                                foreach (String s in args) {
                                    if (ctr > 1)
                                        sb.Append(s + ' ');
                                    ++ctr;
                                }

                                Byte[] data = Encoding.ASCII.GetBytes(sb.ToString());
                                fs.Write(data, 0, data.Length);
                                fs.Close();

                                response = "Successfully wrote to file";

                            } else {
                                response = "Unable to write to file! Not open for writing!";
                                break;
                            }
                        } else {
                            response = "File " + args[1] + " doesn't exist!";
                            break;
                        }
                    } catch (Exception ex) {

                        response = ex.ToString();
                        CrashScreen.Run("", response);
                        break;

                    }
                    break;

                case "read":
                    try {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + args[1]).GetFileStream();
                        
                        if (fsc.CheckFileExists(args[1])) {
                            if (fs.CanRead) {
                                Byte[] data = new Byte[256];
                                fs.Read(data, 0, data.Length);
                                response = Encoding.ASCII.GetString(data);


                            } else {
                                response = "Unable to read file! Not open for reading!";
                                break;
                            }
                            break;
                        } else {
                            response = "File " + args[1] + " doesn't exist!";
                            break;
                        }
                    } catch (Exception ex) {
                        response = ex.ToString();
                        break;
                    }
                    break;
                case "help":
                    response = "File command arguments are create, delete, mkdir, rmdir, write, list and read";
                    break;

                default:
                    response = "Unexpected argument: " + args[0];
                    break;
            }
            return response;

        }
    }

}
