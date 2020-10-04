using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Views;
using EquipmentBorrowingSystem.Views.Staff.BorrowedEquipmentLog;
using EquipmentBorrowingSystem.Views.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{    
    class BorrowedEquipmentLogController : Controller
    {
        private StaffLogic Logic;

        public BorrowedEquipmentLogController(Director director) : base(director)
        {
            Logic = new StaffLogic(director.State);
        }

        public Display AllRequests()
        {

            return new BorrowedEquipmentLogGuiDisplay(Director, Logic.SeeAllRequests());
        }

        public Display PendingRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Director, Logic.SeeAllPendingRequests());
        }

        public Display DeniedRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Director, Logic.SeeAllDeniedRequests());
        }

        public Display ActiveRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Director, Logic.SeeAllActiveRequests());
        }

        public Display CompleteRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Director, Logic.SeeAllCompleteRequests());
        }

        public Display OverdueRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Director, Logic.SeeAllOverdueRequests());
        }

    }
}
