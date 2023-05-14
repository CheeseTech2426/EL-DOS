using EL_DOS.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDOS.Commands {
    internal class ListCommand : Command{
        public ListCommand(String name) : base(name) { }
        public override string execute(string[] args) {
            string path = args.Length > 0 ? args[0] : @"0:\";

            try {
                Console.WriteLine("Files in " + path);
                string[] files = Directory.GetFiles(path);
                foreach (var file in files) {
                    Console.WriteLine($"{file}");
                }
                string[] directories = Directory.GetDirectories(path);
                foreach (var directory in directories) {
                    Console.WriteLine($"[{directory}]");
                }
            } catch (Exception e) {
                Console.WriteLine($"Error: {e.ToString()}");
            }
            return "";
        }
    }
}

