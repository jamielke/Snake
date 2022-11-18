using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class EntityManager
    {
        private List<Entity> entities;

        public EntityManager()
        {
            entities = new List<Entity>();
        }

        public List<Entity> getEntities()
        {
            return entities;
        }

        public void addEntity(Entity entity)
        {
            entities.Add(entity);
        }

        public void removeEntity(Entity entity)
        {
            entities.Remove(entity);
        }
    }
}