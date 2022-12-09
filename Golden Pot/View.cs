using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class View
    {
        private EntityManager entityManager;
        private String[,] map;

        private String snake = "██";
        private String snakeTail = "■";
        private String apple = "🍏";

        public View(EntityManager entityManager, Coordinates size)
        {
            this.entityManager = entityManager;
            this.map = new String[size.getX() + 2, size.getY() + 2];
        }

        public void show()
        {

            for (int x = 0; x < map.GetLength(0); x++)
            {
                map[x, 0] = "██";
                map[x, map.GetLength(0) - 1] = "██";
            }

            foreach (Entity entity in entityManager.getEntities())
            {
                Coordinates coordinates = entity.getCoordinates();

                String image = "";
                if (entity is Snake)
                {
                    image = snake;
                }
                else if (entity is SnakeTail)
                {
                    image = snakeTail;
                }
                else if (entity is Apple)
                {
                    image = apple;
                }

                map[coordinates.getX(), coordinates.getY()] = image;
            }

            Console.Clear();

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write('\n');
            }
        }
    }
}