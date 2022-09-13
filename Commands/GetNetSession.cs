using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetNetSession
    {
        public static string Execute(string ComputerNames = "")
        {
            try
            {
                List<string> computerList = ComputerNames.Split(',').ToList();
                List<Net.SessionInfo> sessionInfos = Net.GetNetSessions(computerList);

                StringBuilder results = new StringBuilder();
                foreach (Net.SessionInfo sessionInfo in sessionInfos)
                {
                    results.Append(sessionInfo.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}