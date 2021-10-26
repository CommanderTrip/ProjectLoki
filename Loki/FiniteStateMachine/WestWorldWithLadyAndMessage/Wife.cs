using Loki.FiniteStateMachine.WestWorldWithLadyAndMessage.LadyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class Wife : BaseGameEntity
    {
        public StateMachine<Wife> StateMachine { get; set; }
        public Location_types Location { get; set; }
        
        public Wife(int id): base(id)
        {
            this.Location = Location_types.shack;
            this.StateMachine = new StateMachine<Wife>(this)
            {
                CurrentState = DoHouseWork.Instance(),
                GlobalState = GlobalState.Instance()
            };
        }

        public override void Update()
        {
            this.StateMachine.Update();
        }
    }
}
