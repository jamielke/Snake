using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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
            List<Entity> list = new List<Entity>();

            foreach (Entity entity in entities.ToList())
            {
                list.Add(entity);
                if (entity is Snake)
                {
                    Snake snake = (Snake)entity;
                    foreach (SnakeTail snakeTail in snake.getSnakeTail())
                    {
                        list.Add(snakeTail);
                    }
                }
            }

            return list;
        }

        public void spawnApple()
        {
            bool hasApple = false;

            foreach (Entity entity in entities)
            {
                if (entity is Apple)
                {
                    hasApple = true;
                    break;
                }
            }

            while (!hasApple)
            {
                Random rng = new Random();
                uint x = (uint)rng.Next(1, (int)GameManager.getSize().getX());
                uint y = (uint)rng.Next(1, (int)GameManager.getSize().getY());
                Apple apple = new Apple(new Coordinates(x, y));

                foreach (Entity entity in entities.ToList())
                {
                    if (apple.getCoordinates() != entity.getCoordinates())
                    {
                        entities.Add(apple);
                        hasApple = true;
                        return;
                    }
                }
            }
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