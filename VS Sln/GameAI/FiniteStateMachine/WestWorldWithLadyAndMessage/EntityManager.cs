using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage
{
    class EntityManager
    {
        private Dictionary<int, BaseGameEntity> entityMap;

        // Singleton
        static private EntityManager _instance = null;
        private EntityManager() 
        {
            entityMap = new Dictionary<int, BaseGameEntity>();
        }

        public static EntityManager Instance()
        {
            if (_instance == null)
            {
                _instance = new EntityManager();
            }
            return _instance;
        }

        //~~~~~~~~~~
        // Methods
        //~~~~~~~~~~
        public void registerEntity(BaseGameEntity entity) 
        {
            entityMap.Add(entity.getId(), entity);
        }

        public BaseGameEntity getEntityByID(int id) 
        {
            foreach(KeyValuePair<int, BaseGameEntity> kvp in entityMap)
            {
                if (kvp.Key == id) return kvp.Value;
            }
            return null;
        }

        public void RemoveEntity(BaseGameEntity entity) 
        {
            if (entityMap.ContainsKey(entity.getId())) entityMap.Remove(entity.getId());
            else System.Console.WriteLine("Entity does not exist in registry");
        }

    }
}
