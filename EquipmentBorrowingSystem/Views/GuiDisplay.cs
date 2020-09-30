using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views
{
    abstract class GuiDisplay : Form, Display
    {
        protected Director director;

        public GuiDisplay(Director director)
        {
            this.director = director;
        }
        
        public void ShowDisplay()
        {
            director.ShowGuiView(this);
        }
    }
}
