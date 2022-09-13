using System;

using SharpSploit.Execution;

namespace ExecSploit
{
    public static class PowerShell
    {
        public static string Execute(string PowerShellCommand)
        {
            try
            {
                return Shell.PowerShellExecute(PowerShellCommand, true);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}