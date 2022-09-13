using System;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class ProcessList
    {
        public static string Execute()
        {
            try
            {
                return Host.GetProcessList().ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}