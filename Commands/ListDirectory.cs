using System;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class ListDirectory
    {
        public static string Execute(string Path = "")
        {
            try
            {
                return string.IsNullOrEmpty(Path.Trim()) ? Host.GetDirectoryListing().ToString() : Host.GetDirectoryListing(Path.Trim()).ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}