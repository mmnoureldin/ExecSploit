using System;
using System.IO;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class ChangeDirectory
    {
        public static string Execute(string Directory)
        {
            try
            {
                Host.ChangeCurrentDirectory(Directory);
                return Host.GetCurrentDirectory();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}