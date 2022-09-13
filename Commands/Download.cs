using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ExecSploit
{
    public static class Download
    {
        public static Stream OutputStream { get; set; }
        public static string Execute(string FileName)
        {
            try
            {
                using (FileStream fs = File.OpenRead(FileName))
                {
                    byte[] read = new byte[1048576];
                    int count;
                    while ((count = fs.Read(read, 0, read.Length)) > 0)
                    {
                        IEnumerable<byte> finalRead = read.Take(count).AsEnumerable();
                        int b = 0;
                        while (count % 3 != 0 && b != -1)
                        {
                            b = fs.ReadByte();
                            if (b != -1)
                            {
                                finalRead = finalRead.Concat(new byte[] { (byte)b });
                            }
                            count++;
                        }
                        byte[] base64 = Encoding.UTF8.GetBytes(Convert.ToBase64String(finalRead.ToArray()));
                        OutputStream.Write(base64, 0, base64.Length);
                        OutputStream.Flush();
                    }
                }
                OutputStream.Close();
                return "";
            }
            catch (Exception e)
            {
                if (OutputStream != null)
                {
                    OutputStream.Close();
                }
                return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace;
            }
        }
    }
}