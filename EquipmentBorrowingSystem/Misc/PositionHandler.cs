using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Misc
{
    class PositionHandler
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int AmountX { get; set; }
        public int AmountY { get; set; }

        public PositionHandler(int x, int y, int amountX, int amountY)
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

        public PositionHandler Up()
        {
            Y -= AmountY;
            return this;
        }

        public PositionHandler Down()
        {
            Y += AmountY;
            return this;
        }

        public PositionHandler Left()
        {
            X -= AmountX;
            return this;
        }

        public PositionHandler Right()
        {
            X += AmountX;
            return this;
        }
    }
}
