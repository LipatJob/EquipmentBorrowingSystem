using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views.Components
{
    class CLabel : Label
    {
        public CLabel(string text = "", int width = 0, int height = 0, int locationX = 0, int locationY = 0)
        {
            this.Text = text;
            this.Size = new Size(width, height);
            this.Location = new Point(locationX, locationY);
        }
    }
}
