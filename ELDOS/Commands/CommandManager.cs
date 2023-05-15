using EL_DOS.Commands;
using ELDOS.Commands;
using loukoOS.Commands;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;

namespace EL_DOS.Commands {
    public class CommandManager {

        public List<Command> commands;
        public List<Command> recoveryUtils;

        public CommandManager() {
            // Add the commands
            commands = new List<Command>(5);
            commands.Add(new Help("help"));
            commands.Add(new FileCommand("file"));
            commands.Add(new ListCommand("list"));
            commands.Add(new ClearCommand("clear"));
            commands.Add(new DiskUtility("disk"));
            commands.Add(new Power("power"));

            recoveryUtils = new List<Command>(2);
            recoveryUtils.Add(new FileCommand("file"));
            recoveryUtils.Add(new Power("power"));
        }

        public string processInput(string input) {
            string[] spilt = input.Split(' ');
            string label = spilt[0];
            List<string> args = new List<string>();

            int ctr = 0;
            foreach (string s in spilt) {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }

            foreach (Command cmd in commands) {
                if (cmd.name == label)
                    return cmd.execute(args.ToArray());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid command: {label}!");
            Console.ForegroundColor = ConsoleColor.White;
            return "";
        }

        public string processRecoveryInput(string input) {
            string[] spilt = input.Split(' ');
            string label = spilt[0];
            List<string> args = new List<string>();

            int ctr = 0;
            foreach (string s in spilt) {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }

            foreach (Command cmd in recoveryUtils) {
                if (cmd.name == label)
                    return cmd.execute(args.ToArray());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid command: {label}!");
            Console.ForegroundColor = ConsoleColor.White;
            return "";
        }
    }
}

