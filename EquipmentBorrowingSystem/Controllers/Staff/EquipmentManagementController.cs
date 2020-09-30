using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Views;
using EquipmentBorrowingSystem.Views.Borrower;
using EquipmentBorrowingSystem.Views.Staff;
using EquipmentBorrowingSystem.Views.Staff.EquipmentManagement;
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
        public EquipmentManagementController(Director director) : base(director)
        {
            Logic = new StaffLogic(director.State);
        }

        public Display EquipmentMenu()
        {
            return new EquipmentMenu(Director, null);
        }

        public Display EquipmentList()
        {
            return new EquipmentList(Director, Logic.SeeAllEquipments());
        }

        public Display AddEquipment()
        {
            return new EquipmentDisplay(Director, new Equipment(0, 0, 0, ""), EquipmentDisplay.ViewMode.ADD);
        }

        public Response AddEquipment(Equipment equipment)
        {
            Logic.AddEquipment(equipment);
            return new Response(true, "Equipment Added");
        }

        public Display ViewEquipment(int id)
        {
            return new EquipmentDisplay(Director, Logic.GetEquipment(id), EquipmentDisplay.ViewMode.VIEW);
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
