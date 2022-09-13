using System;
using System.IO;
using System.Linq;

using SharpSploit.Generic;
using SharpSploit.Execution;

namespace ExecSploit
{
    public static class AssemblyReflect
    {
        //public static Stream OutputStream { get; set; }
        public static string Execute(string Assembly, string AssemblyName, string TypeName, string MethodName, string Parameters = "")
        {
            try
            {
                Object[] args = default(Object[]);
                if (Parameters != null && Parameters != "") { args = Parameters.Split(',').Select(P => (Object)P).ToArray(); }

                TextWriter realStdOut = Console.Out;
                TextWriter realStdErr = Console.Error;
                //StreamWriter stdOutWriter = new StreamWriter(OutputStream);
                //StreamWriter stdErrWriter = new StreamWriter(OutputStream);
                //stdOutWriter.AutoFlush = true;
                //stdErrWriter.AutoFlush = true;
                Console.SetOut(realStdOut);
                Console.SetError(realStdErr);

                GenericObjectResult result = SharpSploit.Execution.Assembly.AssemblyExecute(Assembly, TypeName, MethodName, args);

                Console.Out.Flush();
                Console.Error.Flush();
                //Console.SetOut(realStdOut);
                //Console.SetError(realStdErr);

                //OutputStream.Close();
                return "";
            }
            catch (Exception e)
            {
                /*if (OutputStream != null)
                {
                    OutputStream.Close();
                }*/
                return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace + Environment.NewLine + e.InnerException.GetType().FullName + ": " + e.InnerException.Message + Environment.NewLine + e.InnerException.StackTrace;
            }
        }
    }
}