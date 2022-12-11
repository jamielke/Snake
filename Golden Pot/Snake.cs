using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class Snake : Entity
    {
        private Direction direction;
        private Direction nextDirection;
        private List<SnakeTail> tail;

        public Snake(Coordinates coordinates)
            : base(coordinates)
        {
            this.direction = Direction.left;
            this.nextDirection = Direction.left;
            this.tail = new List<SnakeTail>();
            for (int i = 0; i < 5; i++)
            {
                tail.Add(new SnakeTail(this.coordinates));
            }
        }

        public void move()
        {
            tail.RemoveAt(tail.Count - 1);
            tail.Insert(0, new SnakeTail(this.coordinates));

            setDirection();
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
            tail.Insert(0, new SnakeTail(this.getCoordinates()));
        }

        public Direction getDirection()
        {
            return direction;
        }

        public List<SnakeTail> getSnakeTail()
        {
            return tail;
        }

        public void setNextDirection(Direction nextDirection)
        {
            this.nextDirection = nextDirection;
        }

        private void setDirection()
        {
            if (((int)nextDirection + 2) % 4 == (int)this.direction)
            {
                return;
            }
            this.direction = nextDirection;
        }
    }
}