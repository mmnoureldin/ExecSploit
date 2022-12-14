using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class GetDomainUser
    {
        public static string Execute(string Identities = "")
        {
            try
            {
                List<Domain.DomainObject> domainUsers = new List<Domain.DomainObject>();
                if (Identities.Trim() != "")
                {
                    List<string> identityList = Identities.Split(',').ToList();
                    domainUsers = new Domain.DomainSearcher().GetDomainUsers(identityList);
                }
                else
                {
                    domainUsers = new Domain.DomainSearcher().GetDomainUsers();
                }
                StringBuilder results = new StringBuilder();
                foreach (Domain.DomainObject domainUser in domainUsers)
                {
                    results.Append(domainUser.ToString());
                    results.AppendLine("------");
                }
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}