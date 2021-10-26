using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    enum MinerNames
    {
        bob = 0,
        elsa = 1
    };

    class Name
    {
        public static string GetEntityName(int n)
        {
            switch (n)
            {
                case (int)MinerNames.bob:
                    return "Bob";
                case (int)MinerNames.elsa:
                    return "Elsa";
                default:
                    return "UNKOWN";
            }
        }
    }
}
