using System;
using System.IO;

namespace ExecSploit
{
    public static class Delete
    {
        public static string Execute(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                    return $"File {Path} deleted.";
                }
                else if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                    return $"Directory {Path} deleted.";
                }
                else
                {
                    return $"{Path} does not exist.";
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}