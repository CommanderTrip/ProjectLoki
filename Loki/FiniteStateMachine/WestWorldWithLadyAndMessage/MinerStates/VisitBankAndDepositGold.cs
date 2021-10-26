using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage.MinerStates
{
    /*
     * When the miner is full on mining gold, they will transition to this state.
     * The miner will change location to the bank and move the gold from their pockets to the vault.
     */
    class VisitBankandDepositGold : State<Miner>
    {
        // Singleton
        static private VisitBankandDepositGold _instance = null;
        private VisitBankandDepositGold() { }

        public static VisitBankandDepositGold Instance()
        {
            if (_instance == null)
            {
                _instance = new VisitBankandDepositGold();
            }
            return _instance;
        }

        //~~~~~~~~~~~~~~~~~~~~~~
        // Override Methods
        //~~~~~~~~~~~~~~~~~~~~~~

        public override void Enter(Miner miner)
        {
            // Make sure the miner location is set to the bank
            if (miner.location != Location_types.bank)
            {
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": Goin' to the bank. Yes siree");
                miner.location = Location_types.bank;
            }
        }

        public override void Execute(Miner miner)
        {
            // Deposit the gold from pockets into the bank
            miner.addToWealth(miner.goldCarried);

            // Empty the miner's pockets
            miner.goldCarried = 0;

            // Is the miner wealthy enough to go home?
            if (miner.isSatisfiedFromWork())
            {
                System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": WooHoo! Rich enough for now. Back home to mah li'lle lady");
                miner.changeState(GoHomeAndSleepTillRested.Instance());
            } else
            {
                miner.changeState(EnterMineAndDigForNugget.Instance());
            }
        }

        public override void Exit(Miner miner)
        {
            System.Console.WriteLine(Name.GetEntityName(miner.GetId()) + ": Leavin' the bank");
        } 
    }
}
