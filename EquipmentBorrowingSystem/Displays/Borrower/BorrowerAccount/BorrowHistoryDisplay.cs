using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Borrower.BorrowerAccount
{

    class BorrowHistoryDisplay : CliDisplay<IEnumerable<EquipmentRequest>>
    {
        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public BorrowHistoryDisplay(IEnumerable<EquipmentRequest> model) //<<< Replace with model class
            : base(model)
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
    }
}
