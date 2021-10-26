using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.AutonomousMovingAgents.Util
{
    class C2DMatrix
    {
        private double _11, _12, _13;   // Row one
        private double _21, _22, _23;   // Row two
        private double _31, _32, _33;   // Row three

        // Create a 3x3 zero matrix
        C2DMatrix()
        {
            _11 = 0.0; _12 = 0.0; _13 = 0.0;
            _21 = 0.0; _22 = 0.0; _23 = 0.0;
            _31 = 0.0; _32 = 0.0; _33 = 0.0;
        }

        // Make this matrix the identity matrix
         public void Identity()
        {

        }

        // Multiply matricies
        public void MatrixMultiply(C2DMatrix matrixIn)
        {

        }

        // Create a transformation matrix
        public void Translate(double x, double y)
        {

        }

        
    }
}
