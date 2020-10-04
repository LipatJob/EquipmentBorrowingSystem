using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{
    //    Change Class Name
    //    VVVVVVVVVVVVVVV
    class EmptyController : Controller
    {
        // Select One:
        // private BorrowerLogic Logic;
        // private StaffLogic Logic;

        //     Change Class Name
        //     VVVVVVVVVVVVVVV
        public EmptyController()
        {
            // Each controller must be registered in the director
            // To Register controller:
            // 1. Add controller member in director. eg. public <Name>Controller <Identifier>Controller { get; };
            // 2. Instantiate controller member in contructor. eg. <identifier> = new <Name>Controller();
            // See Director.cs for example

            // Select One:
            // Logic = new BorrowerLogic(ApplicationState.GetInstance());
            // Logic = new StaffLogic(ApplicationState.GetInstance());
        }

        public Display SampleDisplayFunction()
        {
            // This method is used to change the display
            // Return the Display that you want to go to next

            //                           Replace with model
            //                           VVVVVVVVVVVV
            return new EmptyGuiDisplay(new Empty());
        }

        //                                  Replace with model class
        //                                  VVVVVV
        public Response SampleActionFunction(Empty obj)
        {
            // This Method does an action
            // For example, it may insert the object to the database


            //                  is action Successful
            //                  VVVV
            return new Response(true, "Your Message Here");
        }


    }
}
