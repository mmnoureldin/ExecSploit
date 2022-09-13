using System;

using SharpSploit.Execution;

namespace ExecSploit
{
    public static class ShellCmdRunAs
    {
        public static string Execute(string ShellCommand, string Username, string Domain, string Password)
        {
            try
            {
                return Shell.CreateCmdProcess(ShellCommand, Username, Domain, Password);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}