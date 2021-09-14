using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Defeat
{
    public static class Admin
    {
        public static bool IsAdmin => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        public static void Get()
        {
            Process.Start(new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName)
            {
                UseShellExecute = true,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false
            });

            Process.GetCurrentProcess().Kill();
        }
    }
}
