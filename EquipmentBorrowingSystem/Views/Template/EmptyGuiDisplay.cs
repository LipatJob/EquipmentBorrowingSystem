using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views.Template
{

    //   Replace with class name       Replace with model name
    //   VVVVVVVVVVVVVVV               VVVVVV
    class EmptyGuiDisplay : GuiDisplay<Object>
    {
        //   Replace with class name              Replace with model class
        //   VVVVVVVVVVVVVVV                      VVVVVV
        public EmptyGuiDisplay(Director director, Object model) : base(director, model)
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Use this class as you would use a Form
            // To go to another display do:
            // Director.ShowDisplay(Director.<Your Controller>.<Your Method>());
            // Make sure <Your Method> returns a display
        }
    }
}
