using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class BaseGameEntity
    {
        private int id; // Unique ID for each entity
        private static int nextValidId; // Incremented each time an entity is created and marks the next id

        public BaseGameEntity(int id)
        {
            setId(id);
        }

        public virtual void update() { }  // All entities will implement this

        public int getId()
        {
            return this.id;
        }

        private void setId(int id)
        {
            try
            {
                if (id >= nextValidId)
                {
                    this.id = id;
                    nextValidId++;
                }
                else
                {
                    throw new Exception("New entity ID did not pass test.");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                System.Environment.Exit(-1);
            }
        }


    }
}
