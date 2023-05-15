using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Cosmos.System;
using EL_DOS;
using ELDOS;
using s = System;

namespace EL_DOS.ELDOS
{
    public class FSC
    {
        public Kernel k;

        public void WriteToFile(string file, string data)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);
                sw.Write(data);
                sw.Close();
                return;
            } catch (Exception e) {
                Panic.panic(e.Message);
                return;
            }
        }

        public string ReadFromFile(string file)
        {
            try
            {
                StreamReader sw = new StreamReader(file);
                var data = sw.ReadToEnd();
                sw.Close();
                return data;
            } catch (Exception e) {
                Panic.panic(e.Message);
                return null;
            }
        }

        public void CreateDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                   Directory.CreateDirectory(path);
                else
                    s.Console.WriteLine("Directory already exist!");
            } catch (Exception e) {
                Panic.panic(e.Message);
            }
        }

        public void RmDir(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    Directory.Delete(path);
                else
                    s.Console.WriteLine("Directory doesn't exist!");
            } catch (Exception e) {
                Panic.panic(e.Message);
            }
        }

        public void RmFile(string path)
        {

            try
            {
                if (File.Exists(path))
                    File.Delete(path);
                else s.Console.WriteLine("File doesn't exist!");
            } catch (Exception e) {
                Panic.panic(e.Message);
            }
        }

        public void CreateFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                    File.Create(path);
                else s.Console.WriteLine("File already exists!");
            } catch (Exception e) {
                Panic.panic(e.Message);
            }
        }

        public bool CheckFileExists(string path)
        {
            try
            {
                if (File.Exists(path))
                    return true;
                else return false;
            }
            catch(Exception e)
            {
                Panic.panic(e.Message);
                return false;
            }
        }

      

        public bool CheckDirExists(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    return true;
                else return false;
            } catch (Exception e) {
                Panic.panic(e.Message);
                return false;
            }
        }

        public uint GetRAM() {
            uint ram = Cosmos.Core.CPU.GetAmountOfRAM();
            return ram;
        }

        public uint GetFsType(string disk) {
            uint free = Convert.ToUInt32(Kernel.vfs.GetTotalFreeSpace(disk));
            return free;
        }

        public uint GetDiskSize(string disk) {
            uint size = Convert.ToUInt32(Kernel.vfs.GetTotalSize(disk));
            return size;
        }

        public static void StartRM() {
           
        }

    }
}
