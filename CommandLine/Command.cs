using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecSploit.CommandLine
{
    internal class Command
    {
        public string Name;
        public string Description;
        public List<String> Alias = new List<String>();
        
        public List<Option<String>> options = new List<Option<String>>();
        public Action OnExecute0;
        public Action<String> OnExecute1;
        public Action<String, String> OnExecute2;
        public Action<String, String, String> OnExecute3;
        public Action<String, String, String, String> OnExecute4;
        public Action<String, String, String, String, String> OnExecute5;
        public Action<String, String, String, String, String, String> OnExecute6;

        public Command(String name, String description) {
            this.Name = name;
            this.Description = description;
        }

        public void AddAlias(String alias) {
            this.Alias.Add(alias);
        }
        public void AddOption(Option<String> option)
        {
            options.Add(option);
        }

        public void SetHandler(Action action) {
            this.OnExecute0 = action;
        }

        public void SetHandler(Action<String> action)
        {
            this.OnExecute1 = action;
        }
        public void SetHandler(Action<String, String> action)
        {
            this.OnExecute2 = action;
        }
        public void SetHandler(Action<String, String, String> action)
        {
            this.OnExecute3 = action;
        }

        public void SetHandler(Action<String, String, String, String> action)
        {
            this.OnExecute4 = action;
        }

        public void SetHandler(Action<String, String, String, String, String> action)
        {
            this.OnExecute5 = action;
        }
        public void SetHandler(Action<String, String, String, String, String, String> action)
        {
            this.OnExecute6 = action;
        }
        public bool assign(Dictionary<string, string> argumnets) {
            foreach (Option<String> op in options) {
                if (argumnets.ContainsKey(op.name))
                {
                    op.value = argumnets[op.name];
                }
                else if (!argumnets.ContainsKey(op.name) && op.required == false && op.HasDefaultValue() == true)
                {

                    op.value = op.defaultValue;

                }
                else if (argumnets.ContainsKey("/help"))
                {
                    Console.WriteLine("\nDescription:");
                    Console.WriteLine("\t" + Description);
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tExecSploit " + Name + " [options]");
                    Console.WriteLine("Options:");

                    int name_len_h = 0;
                    Dictionary<string, string> map_h = new Dictionary<string, string>();

                    for (int k = 0; k < options.Count; k++)
                    {
                        String name_h = options[k].name;

                        map_h.Add(options[k].name, options[k].description);

                        if (options[k].name.Length > name_len_h)
                        {
                            name_len_h = options[k].name.Length;
                        }

                        //Console.WriteLine("{0} : {1}", String.Join(", ", name_alias).Length, name_len);

                    }

                    foreach (String n in map_h.Keys)
                    {
                        //Console.WriteLine(n);
                        String name_pad = new String(' ', name_len_h - n.Length + 5);
                        string name_print = n + name_pad;

                        String description_pad = new string(' ', name_len_h + 6);
                        Console.WriteLine("{0} {1}", '\t' + name_print, map_h[n].Replace("\n", "\n\t" + description_pad));

                    }
                    return false;
                }
                else
                {
                    Console.WriteLine("[!] Missing parameter\n");
                    Console.WriteLine("\nDescription:");
                    Console.WriteLine("\t" + Description);
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tExecSploit " + Name + " [options]");
                    Console.WriteLine("Options:");

                    int name_len = 0;
                    Dictionary<string, string> map = new Dictionary<string, string>();

                    for (int k = 0; k < options.Count; k++)
                    {
                        String name = options[k].name;

                        map.Add(options[k].name, options[k].description);

                        if (options[k].name.Length > name_len)
                        {
                            name_len = options[k].name.Length;
                        }

                        //Console.WriteLine("{0} : {1}", String.Join(", ", name_alias).Length, name_len);

                    }

                    foreach (String n in map.Keys)
                    {
                        //Console.WriteLine(n);
                        String name_pad = new String(' ', name_len - n.Length + 5);
                        string name_print = n + name_pad;

                        String description_pad = new string(' ', name_len + 6);
                        Console.WriteLine("{0} {1}", '\t' + name_print, map[n].Replace("\n", "\n\t" + description_pad));

                    }
                    return false;

                }
            
            }
            return true;
        }
        
        public void Execute() {


            if (options.Count == 0)
            {
                OnExecute0();
            }
            else if (options.Count == 1)
            {
                OnExecute1(options[0].value);
            }
            else if (options.Count == 2)
            {
                OnExecute2(options[0].value, options[1].value);
            }
            else if (options.Count == 3)
            {
                OnExecute3(options[0].value, options[1].value, options[2].value);
            }
            else if (options.Count == 4) {
                OnExecute4(options[0].value, options[1].value, options[2].value, options[3].value);
            }
            else if (options.Count == 5)
            {
                OnExecute5(options[0].value, options[1].value, options[2].value, options[3].value, options[4].value);
            }
            else if (options.Count == 6)
            {
                OnExecute6(options[0].value, options[1].value, options[2].value, options[3].value, options[4].value, options[5].value);
            }
            else {
                // not implemented yet.
            }
        }
    }
}
