using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Coordinates
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null || !GetType().Equals(obj.GetType()))) 
                return false;
            Coordinates other = (Coordinates)obj;
            return x == other.x && y == other.y;
        }

        public void ApplyMovementChange(Directions direction)
        {
            switch (direction)
            {
                case Directions.left:
                    x--;
                    break;
                case Directions.right:
                    x++;
                    break;
                case Directions.up:
                    y--;
                    break;
                case Directions.down:
                    y++;
                    break;
            }
        }
    }
}
