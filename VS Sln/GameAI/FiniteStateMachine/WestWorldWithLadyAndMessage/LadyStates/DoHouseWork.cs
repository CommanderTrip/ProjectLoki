using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates
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

        public override void enter(Wife wife)
        {
            
        }

        public override void execute(Wife wife)
        {
            switch(new Random().Next(0,2))
            {
                case 0:
                    System.Console.WriteLine(Name.GetEntityName(wife.getId()) + ": Moppin' the floor");
                    break;
                case 1:
                    System.Console.WriteLine(Name.GetEntityName(wife.getId()) + ": Washin' the dishes");
                    break;
                case 2:
                    System.Console.WriteLine(Name.GetEntityName(wife.getId()) + ": Makin; the bed");
                    break;
                default:
                    System.Console.WriteLine("You got here???");
                    break;
            }

        }

        public override void exit(Wife wife)
        {

        }
    }
}
