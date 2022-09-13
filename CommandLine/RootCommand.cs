using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ExecSploit.CommandLine
{
    internal class RootCommand
    {
        public List<Command> commands = new List<Command>();
        public String description;
        public RootCommand(String description = "") {
            this.description = description;
        }

        public void AddCommand(Command command) {
            commands.Add(command);
        }

        public void Invoke(String[] args) {
            if (!(args.Length > 0)){
                Info.ShowLogo();
                Info.ShowUsage(commands);
                return;
            }
            String command = args[0];
            List<bool> valid = new List<bool> { true };

            var arguments = new Dictionary<string, string>();

            if (args.Length > 1) {

                foreach (var argument in args)
                {
                    //var idx_do = argument.IndexOf("::");

                    var idx = argument.IndexOf(':');


                    if (idx > 0)// && idx_do <= 0)
                    {
                        arguments[argument.Substring(0, idx)] = argument.Substring(idx + 1);
                    }
                    else
                    {
                        idx = argument.IndexOf('=');
                        if (idx > 0)
                        {
                            arguments[argument.Substring(0, idx)] = argument.Substring(idx + 1);
                        }
                        else
                        {
                            arguments[argument] = string.Empty;
                        }
                    }
                }
            }

            

            List<String> names = new List<string>();

            List<String> aliases = new List<string>();

            for (int i = 0; i < commands.Count; i++)
            {
                names.Add(commands[i].Name.ToLower());

                foreach (String al in commands[i].Alias) {
                    aliases.Add(al.ToLower()) ;
                }
                    

            }

            
            if (names.Contains(command.ToLower()) || aliases.Contains(command.ToLower()))
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    if (commands[i].Name.ToLower() == command.ToLower() || commands[i].Alias.Contains(command))
                    {

                        if (arguments.ContainsKey("/consoleoutfile") && arguments["/consoleoutfile"] != "")
                        {
                            Program.fileOut = true;
                            Program.outPath = arguments["/consoleoutfile"];

                        }

                        if (arguments.ContainsKey("/consoleoutfile") && arguments["/consoleoutfile"] == "")
                        {
                            Console.WriteLine("[!] Missing argument value");

                        }

                        if (commands[i].options.Count > 0)
                        {
                            bool result = commands[i].assign(arguments);
                            if (result) {
                                commands[i].Execute();
                                Console.WriteLine("[+] Execution Done.");
                                return;
                            }
                            
                        }
                        else
                        {
                            commands[i].Execute();
                            Console.WriteLine("[+] Execution Done.");
                            return;
                        }
                    }
                }

            }
            else if (command == "/help") {
                Info.ShowLogo();
                Info.ShowUsage(commands);
                return;
            }
            else if (command == "")
            {
                Info.ShowLogo();
                Info.ShowUsage(commands);
                return;
            }

            else if (command == "/version")
            {
                Info.ShowLogo();
                return;
            }
            else
            {

                Console.WriteLine("[!] Unkown Command.");
                Info.ShowLogo();
                Info.ShowUsage(commands);
                return;

            }
        }
            
        }
}
