using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetNetLoggedOnUser
    {
        public static string Execute(string ComputerNames = "")
        {
            try
            {
                List<string> computerList = ComputerNames.Split(',').ToList();
                List<Net.LoggedOnUser> loggedOnUsers = Net.GetNetLoggedOnUsers(computerList);

                StringBuilder results = new StringBuilder();
                foreach (Net.LoggedOnUser loggedOnUser in loggedOnUsers)
                {
                    results.Append(loggedOnUser.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}