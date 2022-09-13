using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecSploit
{
    internal interface ICommand
    {
        void Execute(Dictionary<string, string> arguments);

    }
}
