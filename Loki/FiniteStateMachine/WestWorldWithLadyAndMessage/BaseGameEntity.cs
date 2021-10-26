using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class BaseGameEntity
    {
        private int _id; // Unique ID for each entity
        private static int _nextValidId; // Incremented each time an entity is created and marks the next id

        public BaseGameEntity(int id)
        {
            SetId(id);
        }

        public virtual void Update() { }  // All entities will implement this

        public int GetId()
        {
            return this._id;
        }

        private void SetId(int id)
        {
            try
            {
                if (id >= _nextValidId)
                {
                    this._id = id;
                    _nextValidId++;
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
