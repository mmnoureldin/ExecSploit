using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.DirectoryServices;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetDomainComputer
    {
        public static string Execute(string Identities = "")
        {
            try
            {
                List<Domain.DomainObject> domainComputers = new List<Domain.DomainObject>();
                if (Identities.Trim() != "")
                {
                    List<string> identityList = Identities.Split(',').ToList();
                    domainComputers = new Domain.DomainSearcher().GetDomainComputers(identityList);
                }
                else
                {
                    domainComputers = new Domain.DomainSearcher().GetDomainComputers();
                }
                StringBuilder results = new StringBuilder();
                foreach (Domain.DomainObject domainComputer in domainComputers)
                {
                    results.Append(domainComputer.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}