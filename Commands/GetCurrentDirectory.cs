using System;
using System.IO;

namespace ExecSploit
{
    public static class GetCurrentDirectory
    {
        public static string Execute()
        {
            try
            {
                return Directory.GetCurrentDirectory();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}