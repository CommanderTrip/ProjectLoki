using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates
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

        public override void enter(Wife wife)
        {
            System.Console.WriteLine(Name.GetEntityName(wife.getId()) + ": Walkin' to the can. Need to powda mah pretty li'lle nose");
        }

        public override void execute(Wife wife)
        {
            System.Console.WriteLine(Name.GetEntityName(wife.getId()) + ": Ahhhhhh! Sweet relief!");
            wife.stateMachine.revertState();
        }

        public override void exit(Wife wife)
        {
            System.Console.WriteLine(Name.GetEntityName(wife.getId()) + ": Leavin' the Jon");
        }
    }
}
