using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.BasicMovement._2Kinematic
{
    class Actor
    {
        public Vector2D position { get; set; }
        public double orientation { get; set; }
        public double maxSpeed { get; set; }

        public Actor()
        {
            position = new Vector2D();
            orientation = 0;
            maxSpeed = 10;
        }

        public Actor(Vector2D pos, double o, double maxSpeed)
        {
            position = pos;
            orientation = o;
            this.maxSpeed = maxSpeed;
        }

        public void Face(Vector2D velocity)
        {
            // Make sure the velocity is non-zero
            if (velocity.Length() > 0)
            {
                // Calulate the new orientation from arctan of velocity
                orientation = Math.Atan2(velocity.X, velocity.Y);
            }
        }
    }
}
