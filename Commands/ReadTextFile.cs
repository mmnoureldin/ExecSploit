using System;
using System.IO;

namespace ExecSploit
{
    public static class ReadTextFile
    {
        public static string Execute(string Path)
        {
            try
            {
                return File.ReadAllText(Path);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}