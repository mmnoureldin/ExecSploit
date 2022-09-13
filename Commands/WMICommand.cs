using System;
using System.Collections.Generic;

using SharpSploit.Generic;
using SharpSploit.LateralMovement;

namespace ExecSploit
{
public static class WMICommand
{
    public static string Execute(string ComputerName, string Command, string Username = "", string Password = "")
    {
        try
        {
            WMI.WmiExecuteResult result = WMI.WMIExecute(ComputerName, Command, Username, Password);
            if (result != null)
            {
                return new SharpSploitResultList<WMI.WmiExecuteResult> { WMI.WMIExecute(ComputerName, Command, Username, Password) }.ToString();
            }
            else
            {
                return "WMI Execution Failed";
            }
        }
        catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}