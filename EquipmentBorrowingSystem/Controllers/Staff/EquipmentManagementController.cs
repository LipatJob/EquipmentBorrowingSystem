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
            return new EquipmentListDisplay(Logic.SeeAllEquipments());
        }

        public Display AddEquipment()
        {
            return new EquipmentGuiDisplay(new Equipment(), EquipmentGuiDisplay.ViewMode.ADD);
        }

        public Response AddEquipment(Equipment equipment)
        {
            Logic.AddEquipment(equipment);
            return new Response(true, "Equipment Added");
        }

        public Display ViewEquipment(int id)
        {
            return new EquipmentGuiDisplay(Logic.GetEquipment(id), EquipmentGuiDisplay.ViewMode.VIEW);
        }

        public Response EditEquipment(Equipment equipment)
        {
            return Logic.EditEquipment(equipment);
        }

        public Response DeleteEquipment(int id)
        {
            ;
            return Logic.DeleteEquipment(id);
        }
    }
}
