using System;
using System.Security.Principal;

namespace ExecSploit
{
public static class WhoAmI
{
    public static string Execute()
    {
        try
        {
            return WindowsIdentity.GetCurrent().Name;
        }
        catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
    }
}
}