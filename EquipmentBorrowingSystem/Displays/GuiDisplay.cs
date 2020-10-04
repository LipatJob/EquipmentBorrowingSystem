using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays
{
    class GuiDisplay<BaseModel> : Form, Display
    {
        protected Director Director;
        protected BaseModel Model;

        public GuiDisplay()
        {

        }

        public GuiDisplay(BaseModel model)
        {
            this.Director = Director.GetInstance();
            Model = model;
        }
        
        public void ShowDisplay()
        {
            Director.ShowGuiView(this);
        }

        public void BindModelToView() { }

        public void BindViewToModel() { }


    }
}
