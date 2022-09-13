using System;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class SetRemoteRegistryKey
    {
        public static string Execute(string Hostname, string RegPath, string Value)
        {
            try
            {
                if (Registry.SetRemoteRegistryKey(Hostname, RegPath, Value))
                {
                    return "Successfully wrote: \"" + Value + "\" to registry: " + RegPath;
                }
                else
                {
                    return "Failed to write: \"" + Value + "\" to registry: " + RegPath;
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}