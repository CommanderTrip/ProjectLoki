using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.BasicMovement._2Kinematic
{
    static class SteeringBehavior
    {
        public static void Seek(Actor prime, Actor target)
        {
            // 1. Get the direction from prime to the target
            Vector2D velocity = new Vector2D(target.position.X - prime.position.X, target.position.Y - prime.position.Y);

            // 2. Truncate the vector to be the prime's max speed.
            velocity.Truncate(prime.maxSpeed);

            // 3. Face the direction of movement.
            prime.Face(velocity);
        }

 
    }
}
