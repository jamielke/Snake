using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public class Player
    {
        private Snake snake;

        public Player(Snake snake)
        {
            this.snake = snake;
        }

        public Snake getSnake()
        {
            return snake;
        }
    }
}