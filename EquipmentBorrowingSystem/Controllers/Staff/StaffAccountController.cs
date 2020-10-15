using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Borrower.BorrowerAccount;
using EquipmentBorrowingSystem.Displays.Staff.StaffAccount;
using EquipmentBorrowingSystem.Displays.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers.Staff
{

    class StaffAccountController : Controller
    {
        private StaffLogic Logic;

        public StaffAccountController()
        {
            Logic = new StaffLogic(ApplicationState.GetInstance());
        }

        public Display AccountMenu()
        {
            return new StaffAccountMenu(new Object());
        }

        public Display Login()
        {
            return new StaffLoginDisplay(new User());
        }

        public Response Login(User user)
        {
            User loggedinUser = Logic.Login(user);
            if (loggedinUser == null)
            {
                return new Response(false, "Login Failed. Check Username or Password");
            }

            ApplicationState.GetInstance().LoggedInUser = loggedinUser;
            return new Response(true, "User now logged in");
        }

        public Display CreateBorrowerAccount()
        {
            return new CreateBorrowerAccountDisplay(new User());
        }

        public Response CreateBorrowerAccount(User user)
        {
            return Logic.CreateBorrowerAccount(user);
        }

        public Display SeeBorrowerList()
        {
            return new BorrowersListDisplay(Logic.SeeBorrowersList());
        }

        public Display SeeBorrowerHistory(int id)
        {
            return new BorrowerHistoryDisplay(Logic.SeeBorrowHistory(id));
        }
    }
    
}
