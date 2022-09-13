using System;
using System.IO;

namespace ExecSploit
{ 
public static class Upload
{
    public static string Execute(string FilePath, string FileContents)
    {
        try
        {
            File.WriteAllBytes(FilePath, Convert.FromBase64String(FileContents));
            return FilePath;
        }
        catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
    }
}
}