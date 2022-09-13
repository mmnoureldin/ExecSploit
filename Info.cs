using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExecSploit.CommandLine;

namespace ExecSploit
{
    internal class Info
    {
        public static void ShowLogo()
        {
            Console.WriteLine("___________                      _________      .__         .__  __   ");
            Console.WriteLine("\\_   _____/__  ___ ____   ____  /   _____/_____ |  |   ____ |__|/  |_ ");
            Console.WriteLine(" |    __)_\\  \\/  // __ \\_/ ___\\ \\_____  \\\\____ \\|  |  /  _ \\|  \\   __\\");
            Console.WriteLine(" |        \\>    <\\  ___/\\  \\___ /        \\  |_> >  |_(  <_> )  ||  |  ");
            Console.WriteLine("/_______  /__/\\_ \\\\___  >\\___  >_______  /   __/|____/\\____/|__||__|  ");
            Console.WriteLine("        \\/      \\/    \\/     \\/        \\/|__|                         ");
            Console.WriteLine("  v1.0.0 \r\n\r\n");
        }

        public static void ShowUsage(List<Command> commands)
        {
            Console.WriteLine("Required command was not provided.\n\n"+ "Description:\n" + "\tSharpSploit Porting to CommandLine.\n\n" + "Usage:\n" + "\texecsploit [command] [options]\r\n\r\n" + "Options:\r\n" +  "\t/version              Show version information\r\n" + "\t/help                 Show help and usage information\r\n" + "\t/consoleoutfile       Save output to user file.\r\n\r\n" + "Commands:\r\n");
            Dictionary<String, String> map = new Dictionary<String, String>();

            int name_len = 0;

            for (int k = 0; k < commands.Count; k++)
            {
                String name = commands[k].Name;

                List<String> name_alias = new List<String>();
                name_alias.Add(name);

                //Console.WriteLine(name);
                for (int i = 0; i < commands[k].Alias.Count; i++)
                {
                    name_alias.Add((String)commands[k].Alias[i]);
                }

                map.Add(String.Join(", ", name_alias), commands[k].Description);

                if (String.Join(", ", name_alias).Length > name_len)
                {
                    name_len = String.Join(", ", name_alias).Length;
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
        }

    }
}
