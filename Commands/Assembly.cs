using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using SharpSploit.Execution;

namespace ExecSploit
{
    public static class Assembly
    {
        //public static Stream OutputStream { get; set; }
        public static string Execute(string Assembly, string AssemblyName, string Parameters = "")
        {
            try
            {
                string[] args = SplitCommandLine(Parameters).ToArray();

                TextWriter realStdOut = Console.Out;
                TextWriter realStdErr = Console.Error;
                //StreamWriter stdOutWriter = new StreamWriter(OutputStream);
                //StreamWriter stdErrWriter = new StreamWriter(OutputStream);
                //stdOutWriter.AutoFlush = true;
                //stdErrWriter.AutoFlush = true;
                Console.SetOut(realStdOut);
                Console.SetError(realStdErr);

                SharpSploit.Execution.Assembly.AssemblyExecute(Assembly, new Object[] { args });

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

        // Credit: https://stackoverflow.com/a/298990
        private static IEnumerable<string> SplitCommandLine(string commandLine)
        {
            bool inQuotes = false;

            return commandLine.Split(c =>
            {
                if (c == '\"' || c == '\'')
                    inQuotes = !inQuotes;

                return !inQuotes && c == ' ';
            })
                .Select(arg => arg.Trim().TrimMatchingQuotes('\"').TrimMatchingQuotes('\''))
                .Where(arg => !string.IsNullOrEmpty(arg));
        }

        private static IEnumerable<string> Split(this string str, Func<char, bool> controller)
        {
            int nextPiece = 0;

            for (int c = 0; c < str.Length; c++)
            {
                if (controller(str[c]))
                {
                    yield return str.Substring(nextPiece, c - nextPiece);
                    nextPiece = c + 1;
                }
            }

            yield return str.Substring(nextPiece);
        }

        private static string TrimMatchingQuotes(this string input, char quote)
        {
            if ((input.Length >= 2) &&
                (input[0] == quote) && (input[input.Length - 1] == quote))
                return input.Substring(1, input.Length - 2);

            return input;
        }
    }
}