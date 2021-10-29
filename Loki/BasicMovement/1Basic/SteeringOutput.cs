using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Vector2D;

namespace Loki.BasicMovement._1Basic
{
    class SteeringOutput
    {
        // Accelertations 
        public Vector2D linear { get; set; }
        public double angular { get; set; }

        public SteeringOutput()
        {
            linear = new Vector2D(0, 0);
            angular = 0;
        }
    }
}
