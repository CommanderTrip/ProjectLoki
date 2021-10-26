using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates
{
    class VisitBathroom : State<Wife>
    {
        // Singleton
        static private VisitBathroom _instance = null;
        private VisitBathroom() { }

        public static VisitBathroom Instance()
        {
            if (_instance == null)
            {
                _instance = new VisitBathroom();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void Enter(Wife wife)
        {
            System.Console.WriteLine(Name.GetEntityName(wife.GetId()) + ": Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public override void Execute(Wife wife)
        {
            System.Console.WriteLine(Name.GetEntityName(wife.GetId()) + ": Ahhhhhh! Sweet relief!");
            wife.StateMachine.RevertState();
        }

        public override void Exit(Wife wife)
        {
            System.Console.WriteLine(Name.GetEntityName(wife.GetId()) + ": Leavin' the Jon");
        }
    }
}
