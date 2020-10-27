using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
//using EquipmentBorrowingSystem.Displays.Staff.BorrowedEquipmentLog;
using EquipmentBorrowingSystem.Displays.Template;
using EquipmentBorrowingSystem.Views;
using EquipmentBorrowingSystem.Views.Staff.BorrowedEquipmentLog;
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

        public BorrowedEquipmentLogController() : base()
        {
            Logic = new StaffLogic(ApplicationState.GetInstance());
        }

        public Display RequestsMenu()
        {
            return new BorrowedEquipmentLogCliDisplay(null);
        }

        public Display AllRequests()
        {

            return new BorrowedEquipmentLog2GuiDisplay(Logic.SeeAllRequests());
        }

        public Display PendingRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Logic.SeeAllPendingRequests());
        }

        public Display DeniedRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Logic.SeeAllDeniedRequests());
        }

        public Display ActiveRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Logic.SeeAllActiveRequests());
        }

        public Display CompleteRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Logic.SeeAllCompleteRequests());
        }

        public Display OverdueRequests()
        {
            return new BorrowedEquipmentLogGuiDisplay(Logic.SeeAllOverdueRequests());
        }

        //Edited by: Mark Anthony Mamauag
        //Message: I added one part, thanks.

        public Display RequestInformation(int id)
        {
            return new RequestInformationGui2Display(Logic.SeeRequestInformation(id));
        }

        public Response ApproveRequest(int id)
        {
            Logic.ApproveRequest(id);
            return new Response(true, "Requst Approved!", null);
        }

        public Response DenyRequest(int id)
        {
            Logic.DenyRequest(id);
            return new Response(true, "Requst Denied!", null);
        }

        internal IEnumerable<EquipmentRequest> GetOverdueRequests()
        {
            return Logic.SeeAllOverdueRequests();
        }
    }
}
