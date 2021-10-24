using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class State<T>
    {
        virtual public void enter(T entity) { }  // This will run when a state is entered

        virtual public void execute(T entity) { }    // This is called by the entity during its update

        virtual public void exit(T entity) { }   // This will run when the state is exited

    }
}
