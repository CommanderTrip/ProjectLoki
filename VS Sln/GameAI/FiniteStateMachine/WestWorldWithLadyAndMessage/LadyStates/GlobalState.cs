using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates
{
    class GlobalState : State<Wife>
    {
        // Singleton
        static private GlobalState _instance = null;
        private GlobalState() { }

        public static GlobalState Instance()
        {
            if (_instance == null)
            {
                _instance = new GlobalState();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void enter(Wife wife)
        {
            
        }

        public override void execute(Wife wife)
        {
            if (new Random().NextDouble() < 0.1)
            {
                wife.stateMachine.changeState(VisitBathroom.Instance());
            }
        }

        public override void exit(Wife wife)
        {

        }
    }
}
