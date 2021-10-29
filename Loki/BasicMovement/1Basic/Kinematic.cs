using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vector2D;

namespace Loki.BasicMovement._1Basic
{
    class Kinematic
    {
        public Vector2D position { get; set; }
        public double orientation { get; set; }
        public Vector2D velocity { get; set; }
        public double rotation { get; set; }

        public Kinematic()
        {
            position = new Vector2D();
            orientation = 0;
            velocity = new Vector2D(0, 0);
            rotation = 0;
        }

        /// <summary>
        /// Uses the high-school equations to update motion.
        /// </summary>
        /// <param name="steering"></param>
        /// <param name="time"></param>
        public void UpdateHS(SteeringOutput steering, double deltaTime)
        {
            // Update Position and Orientation
            position.X += (velocity.X * deltaTime) + (steering.linear.X * 0.5 * deltaTime * deltaTime);
            position.Y += (velocity.Y * deltaTime) + (steering.linear.Y * 0.5 * deltaTime * deltaTime);
            orientation += (rotation * deltaTime) + (steering.angular * 0.5 * deltaTime * deltaTime);

            // Then update Velocity and Rotation
            velocity.X += (steering.linear.X * deltaTime);
            velocity.Y += (steering.linear.Y * deltaTime);
            rotation += (steering.angular * deltaTime);
        }

        /// <summary>
        /// Uses the Newton-Euler-1 equations to update motion. More common.
        /// </summary>
        /// <param name="steering"></param>
        /// <param name="time"></param>
        public void UpdateNE1(SteeringOutput steering, double deltaTime)
        {
            // Update Position and Orientation
            position.X += velocity.X * deltaTime;
            position.Y += velocity.Y * deltaTime;
            orientation += rotation * deltaTime;

            // Then update Velocity and Rotation
            velocity.X += steering.linear.X * deltaTime;
            velocity.Y += steering.linear.Y * deltaTime;
            rotation += steering.angular * deltaTime;
        }

        public double newOrientation(double currentOrientation, Vector2D velocity)
        {
            // Make sure the velocity is non-zero
            if (velocity.Length() > 0)
            {
                // Calulate the new orientation from arctan of velocity
                return Math.Atan2(velocity.X, velocity.Y);
            }

            // If it stopped, just keep facing that direction
            return currentOrientation;
        }
    }
}
