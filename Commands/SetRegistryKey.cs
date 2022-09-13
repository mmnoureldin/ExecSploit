using System;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class SetRegistryKey
    {
        public static string Execute(string RegPath, string Value)
        {
            try
            {
                if (Registry.SetRegistryKey(RegPath, Value))
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