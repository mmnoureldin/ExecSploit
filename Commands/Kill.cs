using System;
using System.Diagnostics;


namespace ExecSploit
{
    public static class Kill
    {
        public static string Execute(string ProcessId)
        {
            try
            {
                int pid = int.Parse(ProcessId);
                using (var process = Process.GetProcessById(pid))
                {
                    string processName = process.ProcessName;
                    process.Kill();
                    if (process.HasExited)
                    {
                        return $"Process ID {pid} ({processName}) killed.";
                    }
                    else
                    {
                        return $"Could not kill Process ID {pid} ({processName})";
                    }
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}