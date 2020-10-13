using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.BorrowRequest
{
    class ManageRequests : CliDisplay<RequestStatus>
    {
                
        public ManageRequests(RequestStatus model) : base(model)
        {

        }

        public override void ShowDisplay()
        {
            //GET: ID of the request to be managed
            Model.Id = JHelper.InputInt("Enter Request ID: ");

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
            //Director.EmptyController.SampleActionFunction(Model);
        }
    }
}

