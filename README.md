# ExecSploit

**ExecSploit** is a SharpSploit port to commandline application. It contains most of the commands that may be used by C2 frameworks.
ExecSploit may be run from local disk or through loading into memory.
Below is the help menu that contains the supported commands.
```plaintext
PS > ExecSploit.exe
___________                      _________      .__         .__  __
\_   _____/__  ___ ____   ____  /   _____/_____ |  |   ____ |__|/  |_
 |    __)_\  \/  // __ \_/ ___\ \_____  \\____ \|  |  /  _ \|  \   __\
 |        \>    <\  ___/\  \___ /        \  |_> >  |_(  <_> )  ||  |
/_______  /__/\_ \\___  >\___  >_______  /   __/|____/\____/|__||__|
        \/      \/    \/     \/        \/|__|
  v1.0.0


Required command was not provided.

Description:
        SharpSploit Porting to CommandLine.

Usage:
        execsploit [command] [options]

Options:
        /version              Show version information
        /help                 Show help and usage information
        /consoleoutfile       Save output to user file.

Commands:

        WMICommand                                           Execute a process on a remote system using Win32_Process Create, optionally with alternate credentials.
        PowerShellRemotingCommand                            Execute a PowerShell command on a remote system using PowerShell Remoting, optionally with alternate credentials.
        DCOMCommand                                          Execute a process on a remote system using various DCOM methods.
        ScreenShot                                           Takes a screenshot of the currently active desktop, move into a targeted pid for specific desktops
        Download                                             Download a file.
        Upload                                               Upload a file.
        WhoAmI                                               Gets the username of the currently used/impersonated token.
        GetCurrentDirectory, pwd                             Get the Grunt's Current Working Directory
        ChangeDirectory, cd                                  Change the current directory.
        ReadTextFile, cat                                    Read a text file on disk.
        CreateDirectory, mkdir                               Creates all directories and subdirectories in the specified path unless they already exist.
        Delete, rm, del                                      Delete a file or directory.
        Copy, cp                                             Copy a file from one location to another.
        Kill                                                 Kills the process of a given Process ID.
        PrivExchange                                         Performs the PrivExchange attack by sending a push notification to EWS.
        BypassAmsi                                           Bypasses AMSI by patching the AmsiScanBuffer function.
        Shell, CreateProcess                                 Execute a Shell command using CreateProcess.
        ShellCmd, CreateCmdProcess, cmd                      Execute a Shell command using CreateProcess with "cmd.exe / c"
        ShellRunAs, CreateProcessAsUser, runas               Execute a Shell command using CreateProcess as a specified user.
        ShellCmdRunAs, CreateCmdProcessAsUser, runascmd      Execute a Shell command using CreateProcess with "cmd.exe / c" as a specified user.
        CreateProcessWithToken                               Creates a process with the currently impersonated token.
        PowerShell                                           Execute a PowerShell command.
        Assembly                                             Execute a dotnet Assembly EntryPoint.
        ShellCode                                            Executes a specified shellcode byte array by copying it to pinned memory, modifying the memory permissions, and executing.
        GetNetLoggedOnUser                                   Gets a list of `LoggedOnUser`s from specified remote computer(s).
        GetNetLocalGroupMember                               Gets a list of `LocalGroupMember`s from specified remote computer(s).
        GetNetLocalGroup                                     Gets a list of `LocalGroup`s from specified remote computer(s).
        GetDomainGroup                                       Gets a list of specified (or all) group `DomainObject`s in the current Domain.
        GetDomainUser                                        Gets a list of specified (or all) user `DomainObject`s in the current Domain.
        GetDomainComputer                                    Gets a list of specified (or all) computer `DomainObject`s in the current Domain.
        Keylogger                                            Monitor the keystrokes for a specified period of time.
        Kerberoast                                           Perform a "Kerberoast" attack that retrieves crackable service tickets for Domain User's w/ an SPN set.
        PortScan                                             Perform a TCP port scan.
        ListDirectory, ls                                    Get a listing of the current directory.
        ProcessList, ps                                      Get a list of currently running processes.
        SetRegistryKey                                       Sets a value into the registry.
        GetRegistryKey                                       Gets a value stored in registry.
        SetRemoteRegistryKey                                 Sets a value into the registry on a remote system.
        GetRemoteRegistryKey                                 Gets a value stored in registry on a remote system.
        PersistStartup                                       Installs a payload into the current users startup folder.
                                                             Payload: Payload to write to a file.E.g. "powershell -Sta -Nop -Window Hidden -EncodedCommand <blah>".
                                                             FileName: Name of the file to write. E.g. "startup.bat".

        PersistCOMHijack                                     Hijacks a CLSID key to execute a payload for persistence.
        PersistWMI                                           Creates a WMI Event, Consumer and Binding to execute a payload.
        PersistAutorun                                       Installs an autorun value in HKCU or HKLM to execute a payload.
                                                             TargetHive: Target hive to install autorun.Specify "CurrentUser" for HKCU and "LocalMachine" for HKLM.
                                                             Value: Value to set in the registry.E.g. "C:\Example\GruntStager.exe"
                                                             Name: Name for the registy value.E.g. "Updater".

        MakeToken                                            Makes a new token with a specified username and password, and impersonates it to conduct future actions as the specified user.
        GetSystem                                            Impersonate the SYSTEM user. Equates to ImpersonateUser("NT AUTHORITY\SYSTEM").
        ImpersonateProcess                                   Impersonate the token of the specified process. Used to execute subsequent commands as the user associated with the token of the specified process.
        ImpersonateUser                                      Find a process owned by the specified user and impersonate the token. Used to execute subsequent commands as the specified user.
        BypassUACCommand                                     Bypasses UAC through token duplication and executes a command with high integrity.
        RevertToSelf, RevToSelf                              Ends the impersonation of any token, reverting back to the initial token associated with the current process.
                                                             Useful in conjuction with functions impersonate a token and do not automatically RevertToSelf,
                                                             such as ImpersonateUser(), ImpersonateProcess(), GetSystem(), and MakeToken().
        LogonPasswords                                       Execute the 'privilege::debug sekurlsa::logonPasswords' Mimikatz command.
        LsaSecrets                                           Execute the 'privilege::debug lsadump::secrets' Mimikatz command.
        LsaCache                                             Execute the 'privilege::debug lsadump::cache' Mimikatz command.
        SamDump                                              Execute the 'privilege::debug lsadump::sam' Mimikatz command.
        Wdigest                                              Execute the 'sekurlsa::wdigest' Mimikatz command.
        DCSync                                               Execute the 'lsadump::dcsync Mimikatz command.
        Mimikatz                                             Execute a mimikatz command.
        SafetyKatz                                           Use SafetyKatz.
```

Each command option can be viewed by running the command without arguments or by adding "/help" as in below:

```plaintext
PS > ExecSploit.exe mimikatz /help

Description:
        Execute a mimikatz command.
Usage:
        ExecSploit Mimikatz [options]
Options:
        /Command      Mimikatz command to execute.
```

Below is a sample output from mimikatz command.

```plaintext
PS > ExecSploit.exe mimikatz /Command:coffee

  .#####.   mimikatz 2.2.0 (x64) #19041 Feb 18 2021 15:41:34
 .## ^ ##.  "A La Vie, A L'Amour" - (oe.eo)
 ## / \ ##  /*** Benjamin DELPY `gentilkiwi` ( benjamin@gentilkiwi.com )
 ## \ / ##       > https://blog.gentilkiwi.com/mimikatz
 '## v ##'       Vincent LE TOUX             ( vincent.letoux@gmail.com )
  '#####'        > https://pingcastle.com / https://mysmartlogon.com ***/

mimikatz(powershell) # coffee

    ( (
     ) )
  .______.
  |      |]
  \      /
   `----'

[+] Execution Done.
```
