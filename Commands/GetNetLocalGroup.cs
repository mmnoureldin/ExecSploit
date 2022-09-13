using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetNetLocalGroup
    {
        public static string Execute(string ComputerNames = "")
        {
            try
            {
                List<string> computerList = ComputerNames.Split(',').ToList();
                List<Net.LocalGroup> localGroups = Net.GetNetLocalGroups(computerList);

                StringBuilder results = new StringBuilder();
                foreach (Net.LocalGroup localGroup in localGroups)
                {
                    results.Append(localGroup.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}