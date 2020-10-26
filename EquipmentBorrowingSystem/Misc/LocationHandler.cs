using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Misc
{
    class LocationHandler
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int AmountX { get; set; }
        public int AmountY { get; set; }

        public LocationHandler(int x, int y, int amountX, int amountY)
        {
            X = x;
            Y = y;
            AmountX = amountX;
            AmountY = amountY;

        }

        public Point GetPosition()
        {
            return new Point(X, Y);
        }

        public LocationHandler SetLocation(Point point)
        {
            X = point.X;
            Y = point.Y;
            return this;
        }

        public LocationHandler SetX(int value)
        {
            X = value;
            return this;
        }

        public LocationHandler setY(int value)
        {
            Y = value;
            return this;
        }

        public LocationHandler AddX(int amount)
        {
            X += amount;
            return this;
        }

        public LocationHandler AddY(int amount)
        {
            Y += amount;
            return this;
        }

        public LocationHandler Up()
        {
            Y -= AmountY;
            return this;
        }

        public LocationHandler Down()
        {
            Y += AmountY;
            return this;
        }

        public LocationHandler Left()
        {
            X -= AmountX;
            return this;
        }

        public LocationHandler Right()
        {
            X += AmountX;
            return this;
        }
    }
}
