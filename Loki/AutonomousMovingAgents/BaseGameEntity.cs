using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.AutonomousMovingAgents
{
    class BaseGameEntity
    {
        public enum entity_type
        {
            default_entity_type = -1
        }

        private int _id; // Unique ID for each entity
        private static int _nextValidId = 0; // Incremented each time an entity is created and marks the next id
        private int _entityType;    // Entities have a type association
        private bool _tag;  // Generic flag
        
        // Entity location
        protected Vector2 position { get; set; }
        protected Vector2 scale;
        protected double boundingRadius { get; set; }

        public BaseGameEntity()
        {
            SetId(_nextValidId);
            boundingRadius = 0.0;
            position = new Vector2();
            scale = new Vector2(1, 1);
            _entityType = (int)entity_type.default_entity_type;
            _tag = false;
        }

        public BaseGameEntity(int entity_type)
        {
            SetId(_nextValidId);
            boundingRadius = 0.0;
            position = new Vector2();
            scale = new Vector2(1, 1);
            _entityType = entity_type;
            _tag = false;
        }

        public BaseGameEntity(int entity_type, Vector2 position, double radius)
        {
            SetId(_nextValidId);
            boundingRadius = radius;
            this.position = position;
            scale = new Vector2(1, 1);
            _entityType = entity_type;
            _tag = false;
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

        public void setScale(Vector2 val)
        {
            boundingRadius *= Math.Max(val.X, val.Y) / Math.Max(scale.X, scale.Y);
            scale = val;
        }

        public void setScale(double val)
        {
            boundingRadius *= val / Math.Max(scale.X, scale.Y);
            scale = new Vector2((float)val, (float)val);
        }
    }
}
