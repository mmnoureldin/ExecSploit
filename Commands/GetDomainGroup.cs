using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetDomainGroup
    {
        public static string Execute(string Identities = "")
        {
            try
            {
                List<Domain.DomainObject> domainGroups = new List<Domain.DomainObject>();
                if (Identities.Trim() != "")
                {
                    List<string> identityList = Identities.Split(',').ToList();
                    domainGroups = new Domain.DomainSearcher().GetDomainGroups(identityList);
                }
                else
                {
                    domainGroups = new Domain.DomainSearcher().GetDomainGroups();
                }
                StringBuilder results = new StringBuilder();
                foreach (Domain.DomainObject domainGroup in domainGroups)
                {
                    results.Append(domainGroup.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}