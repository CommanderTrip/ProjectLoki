using GameAI.FiniteStateMachine.MinerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorld1
{
    class Miner : BaseGameEntity
    {
        private StateMachine stateMachine;
        public location_types location { get; set; }    // Current location of the miner
        public int goldCarried { get; set; }    // Gold on the miner
        private int moneyInBank;    // Gold the miner has in the bank
        private int thirst; // Current thirst value; the higher the thirstier
        private int fatigue;    // Current fatigue value; the higher the more tired

        private const int MAX_CARRY = 3;  // Max number of nuggests a miner can hold
        private const int THIRST_THRESHOLD = 5; // Max value before miner is thirsty
        private const int COMFORT_LEVEL = 5;    // The amount of wealth needed to be accumulated before the miner will go home
        private const int FATIGUE_THRESHOLD = 5;    // Max value before miner is tired

        public Miner(int id) : base(id)
        {
            this.location = location_types.shack;
            this.goldCarried = 0;
            this.moneyInBank = 0;
            this.thirst = 0;
            this.fatigue = 0;
            this.stateMachine = new StateMachine(this);
            this.stateMachine.currentState = GoHomeAndSleepTillRested.Instance();
        }

        public override void update()
        {
            this.thirst++;
            if (stateMachine != null)
            {
                stateMachine.update();
            }
        }
        
        public void changeState(State newState)
        {
            stateMachine.changeState(newState);
        }


        public void addGoldToCarried(int minedGold)
        {
            this.goldCarried += minedGold;
        }

        public bool arePocketsFull()
        {
            return this.goldCarried >= MAX_CARRY ? true : false;
        }

        public bool isThirsty()
        {
            return this.thirst > THIRST_THRESHOLD ? true : false;
        }

        public void addToWealth(int amount)
        {
            this.moneyInBank += amount;
        }

        public bool isSatisfiedFromWork()
        {
            return this.moneyInBank >= COMFORT_LEVEL ? true : false;
        }

        public bool isFatigued()
        {
            return fatigue > FATIGUE_THRESHOLD ? true : false;
        }

        public void decreaseFatigue()
        {
            this.fatigue--;
        }

        public void buyDrinks()
        {
            this.thirst = 0;
            this.moneyInBank -= 2;
        }
    }
}
