using System;

using SharpSploit.Execution;

namespace ExecSploit
{
    public static class ShellCode
    {
        public static string Execute(string payload)
        {
            try
            {
                if (SharpSploit.Execution.ShellCode.ShellCodeExecute(Convert.FromBase64String(payload)))
                {
                    return "ShellCode execution succeeded.";
                }
                else
                {
                    return "ShellCode execution failed.";
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}