using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class RevertToSelf
    {
        public static string Execute()
        {
            try
            {
                using (Tokens t = new Tokens())
                {
                    if (t.RevertToSelf())
                    {
                        return "Reverted to user: " + t.WhoAmI();
                    }
                    else
                    {
                        return "Failed to RevertToSelf.";
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}