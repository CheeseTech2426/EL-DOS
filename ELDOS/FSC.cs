using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;
using EL_DOS;
using s = System;

namespace EL_DOS.ELDOS
{
    public class FSC
    {


        public void WriteToFile(string file, string data)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);
                sw.Write(data);
                sw.Close();
            }
            catch
            {
                CrashScreen.Run("0x01", "StreamWriter performed an illegal operation");
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
            }
            catch
            {
                CrashScreen.Run("0x02", "StreamReader performed an illegal operation");
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
            }
            catch
            {
                CrashScreen.Run("0x03", "Could not create dir " + path.Substring(path.LastIndexOf(@"\" + 1)));
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
            }
            catch
            {
                CrashScreen.Run("0x04", "Could not delete dir " + path.Substring(path.LastIndexOf(@"\" + 1)));
            }
        }

        public void RmFile(string path)
        {

            try
            {
                if (File.Exists(path))
                    File.Delete(path);
                else s.Console.WriteLine("File doesn't exist!");
            }
            catch
            {
                CrashScreen.Run("0x05", "Could not delete file " + path.Substring(path.LastIndexOf(@"\" + 1)));
            }
        }

        public void CreateFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                    File.Create(path);
                else s.Console.WriteLine("File already exists!");
            }
            catch
            {
                CrashScreen.Run("0x06", "Could not create file " + path.Substring(path.LastIndexOf(@"\" + 1)));
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
            catch
            {
                CrashScreen.Run("0x06", "Could not check if file exists!");
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
            }
            catch
            {
                CrashScreen.Run("0x06", "Could not check if dir exists!");
                return false;
            }
        }
    }
}
