using System;
using System.Drawing.Drawing2D; // For Vector2 and Matrix
using System.Drawing;   // For Point
using System.Numerics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LokiTests")]
namespace Loki.AutonomousMovingAgents
{
    class MovingEntity : BaseGameEntity
    {
        protected Vector2 velocity { get; set; }

        // Normalized vector in the direction of the entity heading
        protected Vector2 heading;
        protected Vector2 side { get; set; }   // vector perpendicular to the heading vector
        protected double mass { get; set; }
        protected double maxSpeed { get; set; }
        protected double maxForce { get; set; } // The max force this entity can produce to power itself
        protected double maxTurnRate { get; set; } // Maximum turn rate (radians/sec) this vehicle can rotate


        public MovingEntity(
            Vector2 position,
            double radius,
            Vector2 velocity,
            double maxSpeed,
            Vector2 heading,
            double mass,
            Vector2 scale,
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

        // Gets the length of the velocity vector
        // Returns a bool depending if the magnitude of the velocity vector exceeds the maxSpeed.
        public bool IsSpeedMaxedOut()
        {
            // Sqrt is computationally expensive so just check the squares
            return maxSpeed * maxSpeed <= velocity.LengthSquared();
        }
        public double Speed()
        {
            return velocity.Length();
        }

        public double SpeedSq()
        {
            return velocity.LengthSquared();
        }

        // Rotate to Face Position -----------------------------------------------------------
        // Given a target, this will rotate the entity's heading and side vector by an amount
        // not greater than the maxTurnRate until the entity faces the target.
        // Returns true when the entity is facing the target
        public bool RotateHeadingToFacePosition(Vector2 target)
        {
            // 1. Get the Vector to the target and normilize
            Vector2 toTarget = new Vector2(target.X - position.X, target.Y - position.Y);
            toTarget = Vector2.Normalize(toTarget);

            // 2. Determine the angle between the heading vector and the target
            // Using dot product...
            // Angles are normalized so there is no need to use magnitude and 
            double angle = Math.Acos(Vector2.Dot(Vector2.Normalize(heading), toTarget));

            // 3. Return if we are facing the target
            if (angle < 0.001) return true;

            // 4. Truncate the angle to the maximum turn rate
            if (angle > maxTurnRate) angle = maxTurnRate;

            // 5. Use Rotation matrix to rotate heading vector correctly
            Matrix RotationMatrix = new Matrix();
            RotationMatrix.Rotate((float)(angle * 180 / Math.PI) * VectorSign(heading, toTarget));
            PointF[] rotatePoints = {new PointF(heading.X, heading.Y), new PointF(velocity.X, velocity.Y)};
            RotationMatrix.TransformVectors(rotatePoints);
            heading = new Vector2(rotatePoints[0].X, rotatePoints[0].Y);
            velocity = new Vector2(rotatePoints[1].X, rotatePoints[1].Y);

            // 6. Recreate the side vector
            this.side = Perp(heading);

            // Not facing the target
            return false;
        }


        // Sign --------------------------------------------------------------
        // Returns positive if v2 is clockwise of the home vector.
        // Returns negative if anticlockwise (y points down, x points right)
        public static int VectorSign(Vector2 home, Vector2 target)
        {
            return home.Y * target.X > home.X * target.Y ? -1 : 1;
        }

        // Perp --------------------------------------------------------------
        // Creates a vector that is +90 deg from the heading angle.
        public static Vector2 Perp(Vector2 inV)
        {
            return new Vector2(-inV.Y, inV.X);
        }

        // Defined Getter Setter cause the setter is unique
        public Vector2 getHeading()
        {
            return heading;
        }

        public void setHeading(Vector2 newHeading)
        {
            heading = newHeading;
            side = Perp(heading);
        }
    }
}
