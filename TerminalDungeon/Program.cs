using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalDungeon.UI;

namespace TerminalDungeon
{

    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new AestheticsConsole();
            ProgramUI ui = new ProgramUI(console);
            ui.Run();
        }
    }
}