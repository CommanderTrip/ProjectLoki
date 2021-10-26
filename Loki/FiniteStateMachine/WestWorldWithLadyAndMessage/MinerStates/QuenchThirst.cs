using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage.MinerStates
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

        public override void Enter(Miner miner)
        {
            if (miner.location != Location_types.saloon)
            {
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": Boy, ah sure is thirsty! Walkin' to the saloon");
                miner.location = Location_types.saloon;
            }
        }

        public override void Execute(Miner miner)
        {
            if (miner.isThirsty())
            {
                miner.buyDrinks();
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": That's some mighty fine liquor");
                miner.changeState(EnterMineAndDigForNugget.Instance());
            } else
            {
                System.Console.WriteLine("ERROR: .isThirsty() in the QuenchThirst was false.");
            }
        }

        public override void Exit(Miner miner)
        {
            System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": Leaving the saloon, feelin' good");
        }
    }
}
