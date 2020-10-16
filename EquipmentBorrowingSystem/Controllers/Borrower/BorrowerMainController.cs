using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Borrower.Main;
using EquipmentBorrowingSystem.Displays.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers.Staff
{
    class BorrowerMainController : Controller
    {
        // Select One:
        // private BorrowerLogic Logic;
        // private StaffLogic Logic;

        //     Change Class Name
        //     VVVVVVVVVVVVVVV
        public BorrowerMainController()
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


        public Display BorrowerMenu()
        {
            Director.GetInstance().ShowDisplay(Director.GetInstance().BorrowerAccountController.Login());
            return new BorrowerMenuDisplay(new Empty());
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
