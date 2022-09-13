using System;

using SharpSploit.LateralMovement;

namespace ExecSploit
{
    public static class PowerShellRemotingCommand
    {
        public static string Execute(string ComputerName, string Command, string Domain = "", string Username = "", string Password = "")
        {
            try
            {
                return PowerShellRemoting.InvokeCommand(ComputerName, Command, Domain, Username, Password);
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}