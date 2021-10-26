using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorld1
{
    class State
    {
        virtual public void enter(Miner miner) { }  // This will run when a state is entered

        virtual public void execute(Miner miner) { }    // This is called by the miner during its update

        virtual public void exit(Miner miner) { }   // This will run when the state is exited

    }
}
