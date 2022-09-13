using System;

using SharpSploit.Execution;

namespace ExecSploit
{
    public static class ShellCmd
    {
        public static string Execute(string ShellCommand)
        {
            try
            {
                return Shell.CreateCmdProcess(ShellCommand);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}