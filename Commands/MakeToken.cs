using System;

using SharpSploit.Credentials;
using SharpSploit.Execution;

namespace ExecSploit
{
    public static class MakeToken
    {
        public static string Execute(string Username, string Domain, string Password, string LogonType = "LOGON32_LOGON_NEW_CREDENTIALS")
        {
            try
            {
                using (Tokens t = new Tokens())
                {
                    Win32.Advapi32.LOGON_TYPE lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_NEW_CREDENTIALS;
                    if (LogonType.ToUpper() == "LOGON32_LOGON_INTERACTIVE") { lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_INTERACTIVE; }
                    else if (LogonType.ToUpper() == "LOGON32_LOGON_NETWORK") { lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_NETWORK; }
                    else if (LogonType.ToUpper() == "LOGON32_LOGON_BATCH") { lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_BATCH; }
                    else if (LogonType.ToUpper() == "LOGON32_LOGON_SERVICE") { lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_SERVICE; }
                    else if (LogonType.ToUpper() == "LOGON32_LOGON_UNLOCK") { lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_UNLOCK; }
                    else if (LogonType.ToUpper() == "LOGON32_LOGON_NETWORK_CLEARTEXT") { lt = Win32.Advapi32.LOGON_TYPE.LOGON32_LOGON_NETWORK_CLEARTEXT; }
                    else if (LogonType.ToUpper() != "LOGON32_LOGON_NEW_CREDENTIALS") { return "MakeToken failed. Invalid LogonType specified."; }

                    if (t.MakeToken(Username, Domain, Password, lt))
                    {
                        return "Successfully made and impersonated token for user: " + Domain + "\\\\" + Username;
                    }
                    else
                    {
                        return "Failed to make token for user: " + Domain + "\\\\" + Username;
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}