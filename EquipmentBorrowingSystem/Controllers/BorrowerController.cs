using EquipmentBorrowingSystem.BackEnd.Logic;
using EquipmentBorrowingSystem.BackEnd.Models;
using EquipmentBorrowingSystem.Views;
using EquipmentBorrowingSystem.Views.Borrower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{
    class BorrowerController : Controller
    {
        private BorrowerLogic Logic;
        public BorrowerController(Director director) : base(director)
        {
            Logic = new BorrowerLogic(director.State);
        }

        public Display Login()
        {
            return new LoginDisplay(Director, new User(0,0,"",""));
        }

        public Display Login(User user)
        {
            User validatedUser= Logic.Login(user);
            if (validatedUser == null) 
            {
                return Login(user);
            }
            Director.State.LoggedInUser = validatedUser;
            return Menu();
        }

        public Display Menu()
        {
            return new MenuDisplay(Director);
        }





        


    }
}
