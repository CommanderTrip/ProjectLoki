using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.MinerStates.WestWorld1
{
    class GoHomeAndSleepTillRested : State
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

        public override void enter(Miner miner)
        {
            if (miner.location != location_types.shack)
            {
                System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Walkin' home");
                miner.location = location_types.shack;
            }
        }

        public override void execute(Miner miner)
        {
            // If the miner is not fatigued, dig for nuggests again
            if(!miner.isFatigued())
            {
                System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": What a God darn fantastic nap! Time to find more gold");
                miner.changeState(EnterMineAndDigForNugget.Instance());
            } else
            {
                // Sleep
                miner.decreaseFatigue();
                System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": ZZZZzzzzZZZZ...");
            }
        }

        public override void exit(Miner miner)
        {
            System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Leavin' the house");
        }
    }
}
