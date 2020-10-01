using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views.Template
{
    //   Replace with class name       Replace with model class
    //   VVVVVVVVVVVVVVV               VVVVVV
    class EmptyCliDisplay : CliDisplay<Empty>
    {
        //   Replace with class name              Replace with model class
        //   VVVVVVVVVVVVVVV                      VVVVVV
        public EmptyCliDisplay(Director director, Empty model) : base(director, model)
        {

        }

        public override void ShowDisplay()
        {
            // Put all Console GUI Here

            // To go to another display do:
            // Director.ShowDisplay(Director.<Your Controller>.<Your Method>());
            // Make sure <Your Method> returns a display
            // Your may pass the model to the arguments of the method
        }

        private void ChangeDisplay()
        {
            // Example of changing the display
            // SampleDisplayFunction() is a display function
            Director.ShowDisplay(Director.EmptyController.SampleDisplayFunction());
        }

        private void PassModelToController()
        {
            // Example of passing the model to the controller
            Director.EmptyController.SampleActionFunction(Model);
        }
    }
}
