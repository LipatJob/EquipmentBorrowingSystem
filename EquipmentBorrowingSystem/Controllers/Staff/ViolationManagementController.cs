using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Borrower.Violations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers.Staff
{
    class ViolationManagementController : Controller
    {
        // Select One:
        // private BorrowerLogic Logic;
        private StaffLogic Logic;

        //     Change Class Name
        //     VVVVVVVVVVVVVVV
        public ViolationManagementController()
        {
            // Each controller must be registered in the director
            // To Register controller:
            // 1. Add controller member in director. eg. public <Name>Controller <Identifier>Controller { get; };
            // 2. Instantiate controller member in contructor. eg. <identifier> = new <Name>Controller();
            // See Director.cs for example

            // Select One:
            // Logic = new BorrowerLogic(ApplicationState.GetInstance());
            Logic = new StaffLogic(ApplicationState.GetInstance());
        }

        public Display SeeViolations()
        {
            return new ViolationManagementDisplay(Logic.SeeAllViolations());
        }

        public Display DisplayViolation(int id)
        {
            return new ViolationDisplay(Logic.GetViolation(id), ViolationDisplay.Modes.VIEW);
        }

        public Response DeleteViolation(int id)
        {
            return Logic.DeleteViolation(id);
        }

        public Display AddViolation(int borrowerId, int requestId)
        {
            return new ViolationDisplay(new BorrowerViolation(borrowerId, requestId, 0, 0, false), ViolationDisplay.Modes.ADD);
        }

        public Display AddOverdueViolation(int borrowerId, int requestId)
        {
            return new ViolationDisplay(new BorrowerViolation(borrowerId, requestId, ApplicationState.GetInstance().Violations.Values.Where(e=>e.Name == "Overdue").FirstOrDefault().Id, 0, false), ViolationDisplay.Modes.ADD);
        }

        public Response AddViolation(BorrowerViolation model)
        {
            return Logic.AddViolation(model);
        }

        public Response EditViolation(BorrowerViolation model)
        {
            return Logic.EditViolation(model);
        }
    }
}
