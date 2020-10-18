using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays.Template;
using EquipmentBorrowingSystem.Misc;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Borrower.BorrowerAccount
{
    class StaffLoginDisplay : LoginDisplay
    {
        public StaffLoginDisplay(User model) : base(model)
        {
            emailTb.Text = "staff@mcl.edu.ph";
            passwordTb.Text = "qwerty";
        }
        public override void NextAction()
        {
            Director.ShowDisplay(Director.StaffMainController.StaffMenu());
        }

        public override Response LoginAction()
        {
            return Director.StaffAccountController.Login(Model);
        }
    }
}
