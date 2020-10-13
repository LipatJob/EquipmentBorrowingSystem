using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Borrower;
using EquipmentBorrowingSystem.Displays.Staff;
using EquipmentBorrowingSystem.Displays.Staff.EquipmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{
    class EquipmentManagementController : Controller
    {
        private StaffLogic Logic;
        public EquipmentManagementController()
        {
            Logic = new StaffLogic(ApplicationState.GetInstance());
        }

        public Display EquipmentMenu()
        {
            return new EquipmentMenu(null);
        }

        public Display EquipmentList()
        {
            return new EquipmentList(Logic.SeeAllEquipments());
        }

        public Display AddEquipment()
        {
            return new EquipmentDisplay(new Equipment(), EquipmentDisplay.ViewMode.ADD);
        }

        public Response AddEquipment(Equipment equipment)
        {
            Logic.AddEquipment(equipment);
            return new Response(true, "Equipment Added");
        }

        public Display ViewEquipment(int id)
        {
            return new EquipmentGuiDisplay(Logic.GetEquipment(id));
        }

        public Response EditEquipment(Equipment equipment)
        {
            Logic.EditEquipment(equipment);
            return new Response(true, "Equipment Edited", null);
        }

        public Response DeleteEquipment(int id)
        {
            Logic.DeleteEquipment(id);
            return new Response(true, "Equipment Edited", null);
        }
    }
}
