using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    struct Telegram
    {
        public int Sender { get; set; } // The entity that sent the message
        public int Receiver { get; set; }   // The entity intended to receive the message
        public int Message { get; set; }    // The message itself
        public double DispatchTime { get; set; }    // The time the message was sent
        public Object ExtraInfo { get; set; }   // Any extra information that the sender wants to send
    }
}
