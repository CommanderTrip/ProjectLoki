using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.MinerStates.WestWorld1
{
    /*
     * In this state, the mine should change location to be at the gold mine.
     * Once there, he should mine for gold until his pockets are full. He should then change state to "VisitBankAndDepositNugget".
     * If the miner gets thirsty while digging, he should change state to "QuenchThirst".
     * Implemented as a Singleton Class.
     */
    class EnterMineAndDigForNugget : State
    {
        // Singleton
        static private EnterMineAndDigForNugget _instance = null;
        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance()
        {
            if (_instance == null)
            {
                _instance = new EnterMineAndDigForNugget();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void enter(Miner miner)
        {
            // If the miner is not at the gold mine, change to gold mine
            if (miner.location != location_types.goldmine)
            {
                System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Walkin' to the gold mine");
                miner.location = location_types.goldmine;
            }
        }

        public override void execute(Miner miner)
        {
            // The miner will dig until his pockets are full
            System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Pickin' up a nugget");
            miner.addGoldToCarried(1);

            // If the miner is carrying his limit, deposit at the bank
            if (miner.arePocketsFull())
            {
                miner.changeState(VisitBankandDepositGold.Instance());
            }

            if (miner.isThirsty())
            {
                miner.changeState(QuenchThirst.Instance());
            }
        }

        public override void exit(Miner miner)
        {
            System.Console.WriteLine(Name.GetEntityName(miner.getId()) + ": Ah'm leavn' the gold mine with some good ole gold");
        }
    }
}
