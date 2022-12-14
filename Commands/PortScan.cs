using System;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Enumeration;
using SharpSploit.Generic;

namespace ExecSploit
{
    public static class PortScan
    {
        public static string Execute(string ComputerNames, string Ports, string Ping)
        {
            try
            {
                List<int> portList = new List<int>();
                foreach (string entry in Ports.Split(','))
                {
                    if (entry.Contains("-"))
                    {
                        string[] parts = entry.Split('-');
                        int firstPort = int.Parse(parts[0]);
                        int numPorts = int.Parse(parts[1]) - firstPort + 1;
                        portList.AddRange(Enumerable.Range(firstPort, numPorts));
                    }
                    else
                    {
                        portList.Add(int.Parse(entry));
                    }
                }
                List<string> computerList = ComputerNames.Split(',').ToList();
                bool pingB = (Ping.ToLower() == "true" ? true : false);
                SharpSploitResultList<Network.PortScanResult> results = Network.PortScan(computerList, portList, pingB);
                return results.ToString();
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}