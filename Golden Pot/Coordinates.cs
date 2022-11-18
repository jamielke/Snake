using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public struct Coordinates
    {
        private uint x;
        private uint y;

        public Coordinates(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }

        public uint getX()
        {
            return x;
        }

        public void setX(uint x)
        {
            this.x = x;
        }

        public uint getY()
        {
            return y;
        }

        public void setY(uint y)
        {
            this.y = y;
        }
    }
}