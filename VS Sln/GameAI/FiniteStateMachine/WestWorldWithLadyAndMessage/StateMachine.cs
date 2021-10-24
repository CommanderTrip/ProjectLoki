using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class StateMachine<T>
    {
        private T owner;
        public State<T> currentState { get; set; }
        public State<T> prevState { get; set; }
        public State<T> globalState { get; set; }

        public StateMachine(T owner)
        {
            this.owner = owner;
            currentState = null;
            globalState = null;
        }

        public void update()
        {
            // If global state exists, call update on that
            if (globalState != null) globalState.execute(owner);

            // Same with the current state
            if (currentState != null) currentState.execute(owner);
        }

        public void changeState(State<T> newState)
        {
            if (newState != null)
            {
                // Record the previous state 
                this.prevState = this.currentState;

                // Call exit on the current state;
                this.currentState.exit(owner);

                // Change State
                this.currentState = newState;

                // Call entry on the new state
                this.currentState.enter(owner);
            }
        }

        public void revertState()
        {
            changeState(prevState);
        }
        public bool isInState(State<T> testState)
        {
            return currentState.GetType() == testState.GetType() ? true : false;
        }
    }
}
