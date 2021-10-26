using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class State<T>
    {
        public virtual void Enter(T entity) { }  // This will run when a state is entered

        public virtual void Execute(T entity) { }    // This is called by the entity during its update

        public virtual void Exit(T entity) { }   // This will run when the state is exited

    }
}
