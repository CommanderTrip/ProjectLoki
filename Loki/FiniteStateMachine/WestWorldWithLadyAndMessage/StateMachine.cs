using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class StateMachine<T>
    {
        private T owner;
        public State<T> CurrentState { get; set; }
        public State<T> PrevState { get; set; }
        public State<T> GlobalState { get; set; }

        public StateMachine(T owner)
        {
            this.owner = owner;
            CurrentState = null;
            GlobalState = null;
        }

        public void Update()
        {
            // If global state exists, call update on that
            if (GlobalState != null) GlobalState.execute(owner);

            // Same with the current state
            if (CurrentState != null) CurrentState.execute(owner);
        }

        public void ChangeState(State<T> newState)
        {
            if (newState != null)
            {
                // Record the previous state 
                this.PrevState = this.CurrentState;

                // Call exit on the current state;
                this.CurrentState.exit(owner);

                // Change State
                this.CurrentState = newState;

                // Call entry on the new state
                this.CurrentState.Enter(owner);
            }
        }

        public void RevertState()
        {
            ChangeState(PrevState);
        }
        public bool IsInState(State<T> testState)
        {
            return CurrentState.GetType() == testState.GetType();
        }
    }
}
