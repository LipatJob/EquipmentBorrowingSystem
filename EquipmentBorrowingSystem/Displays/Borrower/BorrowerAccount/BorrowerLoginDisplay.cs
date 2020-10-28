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

    class BorrowerLoginDisplay : LoginDisplay
    {
        public BorrowerLoginDisplay(User model):base(model)
        {
            // emailTb.Text = "borrower@mcl.edu.ph";
            // passwordTb.Text = "qwerty";
        }
        public override void NextAction()
        {
            Director.ShowDisplay(Director.BorrowerMainController.BorrowerMenu());
        }

        public override Response LoginAction()
        {
            return Director.BorrowerAccountController.Login(Model);
        }
    }
}
