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

        public Snake(List<SnakeTail> tail, Coordinates coordinates)
            : base(coordinates)
        {
            this.direction = Direction.left;
            this.tail = tail;
        }

        public void move()
        {
            tail.RemoveAt(tail.Count - 1);
            tail.Prepend(new SnakeTail(this.getCoordinates()));

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