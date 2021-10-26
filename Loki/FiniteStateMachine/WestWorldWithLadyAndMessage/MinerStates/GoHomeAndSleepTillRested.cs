using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage.MinerStates
{
    class GoHomeAndSleepTillRested : State<Miner>
    {
        // Singleton
        static private GoHomeAndSleepTillRested _instance = null;
        private GoHomeAndSleepTillRested() { }

        public static GoHomeAndSleepTillRested Instance()
        {
            if (_instance == null)
            {
                _instance = new GoHomeAndSleepTillRested();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void Enter(Miner miner)
        {
            if (miner.location != Location_types.shack)
            {
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": Walkin' home");
                miner.location = Location_types.shack;
            }
        }

        public override void Execute(Miner miner)
        {
            // If the miner is not fatigued, dig for nuggests again
            if(!miner.isFatigued())
            {
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": What a God darn fantastic nap! Time to find more gold");
                miner.changeState(EnterMineAndDigForNugget.Instance());
            } else
            {
                // Sleep
                miner.decreaseFatigue();
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": ZZZZzzzzZZZZ...");
            }
        }

        public override void Exit(Miner miner)
        {
            System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": Leavin' the house");
        }
    }
}
