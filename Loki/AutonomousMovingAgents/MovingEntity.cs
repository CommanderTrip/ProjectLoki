using System;
using Loki.AutonomousMovingAgents.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.AutonomousMovingAgents
{
    class MovingEntity : BaseGameEntity
    {
        protected Vector2D velocity { get; set; }
        protected Vector2D heading { get; set; }   // Normalized vector in the direction of the entity heading
        protected Vector2D side { get; set; }   // vector perpendicular to the heading vector
        protected double mass { get; set; }
        protected double maxSpeed { get; set; }
        protected double maxForce { get; set; } // The max force this entity can produce to power itself
        protected double maxTurnRate { get; set; } // Maximum turn rate (radians/sec) this vehicle can rotate


        public MovingEntity(
            Vector2D position,
            double radius,
            Vector2D velocity,
            double maxSpeed,
            Vector2D heading,
            double mass,
            Vector2D scale,
            double maxTurnRate,
            double maxForce) : base(0, position, radius)
        {
            this.heading = heading;
            this.velocity = velocity;
            this.mass = mass;
            this.maxSpeed = maxSpeed;
            this.maxTurnRate = maxTurnRate;
            this.maxForce = maxForce;
            base.scale = scale;
        }

        public bool isSpeedMaxedOut()
        {
            // Sqrt is computationally expensive so just check the squares
            return maxSpeed * maxSpeed >= velocity.lengthSq();
        }

        public double speed()
        {
            return velocity.length();
        }

        public double speedSq()
        {
            return velocity.lengthSq();
        }

        // Rotate to Face Position -----------------------------------------------------------
        // Given a target, this will rotate the entity's heading and side vector by an amount
        // not greater than the maxTurnRate until the entity faces the target.
        // Returns true when the entity is facing the target
        public bool rotateHeadingToFacePosition(Vector2D target)
        {
            // 1. Get the Vector to the target and normilize
            Vector2D toTarget = new Vector2D(target.x - position.x, target.y - position.y);
            toTarget.normalize();

            // 2. Determine the angle between the heading vector and the target
            // Using dot product...
            // Angles are normalized so there is no need to use magnitude and 
            double angle = Math.Acos(heading.dot(toTarget));

            // 3. Return if we are facing the target
            if (angle < 0.00001) return true;

            // 4. Truncate the angle to the maximum turn rate
            if (angle > maxTurnRate) angle = maxTurnRate;

            //
        }
    }
}
