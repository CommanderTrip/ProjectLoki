using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    struct Telegram
    {
        public int sender { get; set; } // The entity that sent the message
        public int receiver { get; set; }   // The entity intended to receive the message
        public int message { get; set; }    // The message itself
        public double dispatchTime { get; set; }    // The time the message was sent
        public Object extraInfo { get; set; }   // Any extra information that the sender wants to send
    }
}
