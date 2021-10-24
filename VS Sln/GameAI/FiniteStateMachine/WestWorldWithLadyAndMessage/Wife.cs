using GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class Wife : BaseGameEntity
    {
        public StateMachine<Wife> stateMachine { get; set; }
        public location_types location { get; set; }
        
        public Wife(int id): base(id)
        {
            this.location = location_types.shack;
            this.stateMachine = new StateMachine<Wife>(this);
            this.stateMachine.currentState = DoHouseWork.Instance();
            this.stateMachine.globalState = GlobalState.Instance();
        }

        public override void update()
        {
            this.stateMachine.update();
        }
    }
}
