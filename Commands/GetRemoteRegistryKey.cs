using System;

using SharpSploit.Enumeration;

namespace ExecSploit
{

    public static class GetRemoteRegistryKey
    {
        public static string Execute(string Hostname, string RegPath)
        {
            try
            {
                return Registry.GetRemoteRegistryKey(Hostname, RegPath);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}