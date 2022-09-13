using System;
using System.IO;

namespace ExecSploit
{
    public static class CreateDirectory
    {
        public static string Execute(string Path)
        {
            try
            {
                var directory = Directory.CreateDirectory(Path);
                return directory.FullName + " created.";
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}