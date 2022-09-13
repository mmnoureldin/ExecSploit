using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetNetLocalGroupMember
    {
        public static string Execute(string ComputerNames = "", string GroupName = "Administrators")
        {
            try
            {
                List<string> computerList = ComputerNames.Split(',').ToList();
                List<Net.LocalGroupMember> localGroupMembers = Net.GetNetLocalGroupMembers(computerList, GroupName);

                StringBuilder results = new StringBuilder();
                foreach (Net.LocalGroupMember localGroupMember in localGroupMembers)
                {
                    results.Append(localGroupMember.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}