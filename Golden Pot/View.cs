using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class View
    {
        private String[,] map;

        private String snake = "██";
        private String snakeTail = "▓▓";
        private String apple = "🍏";
        private String border = "▓▓";

        public View(Coordinates size)
        {
            this.map = new String[size.getX() + 2, size.getY() + 2];
        }

        public void show(List<Entity> entities)
        {
            clearMap();

            foreach (Entity entity in entities)
            {
                Coordinates coordinates = entity.getCoordinates();
                map[coordinates.getX(), coordinates.getY()] = getEntityImage(entity);
            }

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write('\n');
            }
        }

        private String getEntityImage(Entity entity)
        {
            if (entity is Snake)
            {
                return snake;
            }
            else if (entity is SnakeTail)
            {
                return snakeTail;
            }
            else if (entity is Apple)
            {
                return apple;
            }

            return "";
        }

        private void clearMap()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (x == 0 || x == map.GetLength(0) - 1)
                    {
                        map[x, y] = border;
                    }
                    else
                    {
                        map[x, y] = "  ";
                    }
                }

                map[x, 0] = border;
                map[x, map.GetLength(0) - 1] = border;
            }

            Console.Clear();
        }
    }
}