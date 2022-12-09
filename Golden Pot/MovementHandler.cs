using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace Golden_Pot
{
    public class MovementHandler
    {
        private EntityManager entityManager;
        private Coordinates size;

        public MovementHandler(EntityManager entityManager, Coordinates size)
        {
            this.entityManager = entityManager;
            this.size = size;
        }

        public bool move(Snake snake)
        {
            snake.move();

            return checkForCollision(snake) && checkOutOfBounds(snake);
        }

        public bool checkForCollision(Snake snake)
        {
            foreach (Entity entity in entityManager.getEntities())
            {
                if (snake.getCoordinates == entity.getCoordinates)
                {
                    if (entity is Apple)
                    {
                        entityManager.removeEntity(entity);
                        snake.grow();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool checkOutOfBounds(Snake snake)
        {
            uint snakeX = snake.getCoordinates().getX();
            uint snakeY = snake.getCoordinates().getY();

            return 0 <= snakeX && snakeX < size.getX()
                && 0 <= snakeY && snakeY < size.getY();
        }
    }
}