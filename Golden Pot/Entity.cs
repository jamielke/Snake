using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golden_Pot
{
    public abstract class Entity
    {
        protected Coordinates coordinates;

        protected Entity(Coordinates coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates getCoordinates()
        {
            return coordinates;
        }
    }
}