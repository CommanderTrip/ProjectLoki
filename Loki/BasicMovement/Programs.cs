using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Loki.BasicMovement._1Basic;
using Loki.BasicMovement._2Kinematic;

namespace Loki.BasicMovement
{
    public static class Programs
    {
        /// <summary>
        /// Uses basic motion with fake steering to move actor.
        /// </summary>
        public static void Program1(bool useHS)
        {

            // Create the initial conditions of the driver and time
            SteeringOutput steering = new SteeringOutput();
            Kinematic kinematic = new Kinematic();
            kinematic.position.X = 0;
            kinematic.position.Y = 60;
            kinematic.velocity.X = 8;
            kinematic.velocity.Y = 2;
            steering.linear.X = 0;
            steering.linear.Y = 1;
            kinematic.orientation = 0;
            kinematic.rotation = 0;
            steering.angular = 0;

            double time = 0;
            double deltaTime = 0.5;

            // Output the first line of the file
            string path = "C:\\Users\\J\\Documents\\Git Repos\\ProjectLoki\\Loki\\data.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"{time}, {kinematic.position.X}, {kinematic.position.Y}, {kinematic.velocity.X}, {kinematic.velocity.Y}, {steering.linear.X}, {steering.linear.Y}, {kinematic.orientation}, {kinematic.rotation}, {steering.angular}");
            }

            // Run simulation for 100 simulated seconds
            while (time < 100)
            {
                time += deltaTime;
                if (useHS)
                {
                    kinematic.UpdateHS(steering, deltaTime);
                }
                else
                {
                    kinematic.UpdateNE1(steering, deltaTime);
                }
                

                // Update accelerations in fake behavior
                steering.linear.X = kinematic.position.X / -100 * deltaTime * 9;
                steering.linear.Y = kinematic.position.Y / -100 * deltaTime * 3;
                steering.angular = (50 - time) * 0.0001;

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{time}, {kinematic.position.X}, {kinematic.position.Y}, {kinematic.velocity.X}, {kinematic.velocity.Y}, {steering.linear.X}, {steering.linear.Y}, {kinematic.orientation}, {kinematic.rotation}, {steering.angular}");
                }
            }
        }

        public static void Program2()
        {
            Actor prime = new Actor();
            Actor target = new Actor();
        }
    }
}
