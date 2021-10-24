using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage.MinerStates
{
    class QuenchThirst : State<Miner>
    {
        // Singleton
        static private QuenchThirst _instance = null; 
        private QuenchThirst() { }

        public static QuenchThirst Instance()
        {
            if (_instance == null)
            {
                _instance = new QuenchThirst();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void enter(Miner miner)
        {
            if (miner.location != location_types.saloon)
            {
                System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Boy, ah sure is thirsty! Walkin' to the saloon");
                miner.location = location_types.saloon;
            }
        }

        public override void execute(Miner miner)
        {
            if (miner.isThirsty())
            {
                miner.buyDrinks();
                System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": That's some mighty fine liquor");
                miner.changeState(EnterMineAndDigForNugget.Instance());
            } else
            {
                System.Console.WriteLine("ERROR: .isThirsty() in the QuenchThirst was false.");
            }
        }

        public override void exit(Miner miner)
        {
            System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Leaving the saloon, feelin' good");
        }
    }
}
