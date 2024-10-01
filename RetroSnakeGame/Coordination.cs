using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace RetroSnakeGame
{
    internal class Coordination
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Coordination(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        
        public override bool Equals(object? obj)
        {
            
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            
            else
            {
                Coordination other = (Coordination)obj;
                return x == other.X && y == other.Y;
            }
            
        }

        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
            }
        }

    }
    
}
