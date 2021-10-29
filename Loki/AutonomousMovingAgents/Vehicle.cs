using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.AutonomousMovingAgents
{
    class Vehicle : MovingEntity
    {
        public GameWorld world { get; set; }    // World data
        public SteeringBehavior steering { get; set; }  // Steering behavor
    
    }
}
