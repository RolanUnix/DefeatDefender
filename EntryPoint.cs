using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defeat
{
    internal static class EntryPoint
    {
        public static void Main()
        {
            if (!Admin.IsAdmin) Admin.Get();
            Defender.Defeat();
        }
    }
}
