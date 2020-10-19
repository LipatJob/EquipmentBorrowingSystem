using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Borrower.Violations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers.Borrower
{

    class BorrowerViolationsController : Controller
    {
        // Select One:
        private BorrowerLogic Logic;
        // private StaffLogic Logic;

        //     Change Class Name
        //     VVVVVVVVVVVVVVV
        public BorrowerViolationsController()
        {
            // Each controller must be registered in the director
            // To Register controller:
            // 1. Add controller member in director. eg. public <Name>Controller <Identifier>Controller { get; };
            // 2. Instantiate controller member in contructor. eg. <identifier> = new <Name>Controller();
            // See Director.cs for example

            // Select One:
            Logic = new BorrowerLogic(ApplicationState.GetInstance());
            // Logic = new StaffLogic(ApplicationState.GetInstance());
        }

        public Display SeeViolations()
        {
            return new ViolationsDisplay(Logic.SeeViolationHistory());
        }

    }
}
