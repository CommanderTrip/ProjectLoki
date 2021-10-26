using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates
{
    class DoHouseWork : State<Wife>
    {
        // Singleton
        static private DoHouseWork _instance = null;
        private DoHouseWork() { }

        public static DoHouseWork Instance()
        { 
            if (_instance == null)
            {
                _instance = new DoHouseWork();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void Enter(Wife wife)
        {
            
        }

        public override void Execute(Wife wife)
        {
            switch(new Random().Next(0,2))
            {
                case 0:
                    System.Console.WriteLine(Name.GetEntityName(wife.GetId()) + ": Moppin' the floor");
                    break;
                case 1:
                    System.Console.WriteLine(Name.GetEntityName(wife.GetId()) + ": Washin' the dishes");
                    break;
                case 2:
                    System.Console.WriteLine(Name.GetEntityName(wife.GetId()) + ": Makin; the bed");
                    break;
                default:
                    System.Console.WriteLine("You got here???");
                    break;
            }

        }

        public override void Exit(Wife wife)
        {

        }
    }
}
