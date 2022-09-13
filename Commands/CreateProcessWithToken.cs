using System;
using System.Security.Principal;

using SharpSploit.Execution;

namespace ExecSploit
{
    public static class CreateProcessWithToken
    {
        public static string Execute(string Command, string Path)
        {
            try
            {
                return Shell.CreateProcessWithToken(Command, Path, WindowsIdentity.GetCurrent().Token);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}