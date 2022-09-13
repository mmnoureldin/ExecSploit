using System;
using System.IO;

namespace ExecSploit
{
    public static class Copy
    {
        public static string Execute(string Source, string Destination)
        {
            try
            {
                File.Copy(Source, Destination);
                return "Successfully copied file from: " + Source + " to: " + Destination;
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}