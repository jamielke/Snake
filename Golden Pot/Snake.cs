using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class Snake : Entity
    {
        private Direction direction;
        private List<SnakeTail> tail;

        public Snake(Coordinates coordinates)
            : base(coordinates)
        {
            this.direction = Direction.left;
            this.tail = new List<SnakeTail>();
            for (int i = 0; i < 5; i++)
            {
                tail.Add(new SnakeTail(this.coordinates));
            }
        }

        public void move()
        {
            Console.WriteLine(tail.Count);
            tail.RemoveAt(tail.Count - 1);
            tail.Insert(0, new SnakeTail(this.coordinates));

            switch (direction)
            {
                case Direction.left:
                    coordinates.setX(coordinates.getX() - 1);
                    break;
                case Direction.up:
                    coordinates.setY(coordinates.getY() - 1);
                    break;
                case Direction.right:
                    coordinates.setX(coordinates.getX() + 1);
                    break;
                case Direction.down:
                    coordinates.setY(coordinates.getY() + 1);
                    break;
            }
        }

        public void grow()
        {
            tail.Prepend(new SnakeTail(this.getCoordinates()));
        }

        public Direction getDirection()
        {
            return direction;
        }

        public void setDirection(Direction direction)
        {
            this.direction = direction;
        }
    }
}