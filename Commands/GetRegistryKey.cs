using System;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetRegistryKey
    {
        public static string Execute(string RegPath)
        {
            try
            {
                return Registry.GetRegistryKey(RegPath);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}