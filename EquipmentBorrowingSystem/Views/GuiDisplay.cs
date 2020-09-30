using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views
{
    abstract class GuiDisplay<BaseModel> : Form, Display
    {
        protected Director Director;
        protected BaseModel Model;

        public GuiDisplay(Director director, BaseModel model)
        {
            this.Director = director;
            Model = model;
        }
        
        public void ShowDisplay()
        {
            Director.ShowGuiView(this);
        }
    }
}
