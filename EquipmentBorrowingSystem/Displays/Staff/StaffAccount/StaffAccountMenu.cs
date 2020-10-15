using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.StaffAccount
{

    class StaffAccountMenu : CliDisplay<Object>
    {
        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public StaffAccountMenu(Object model) //<<< Replace with model class
            : base(model)
        {

        }

        public override void ShowDisplay()
        {
            Console.Clear();
            Console.WriteLine(
                "A. Create Borrower Account\n" +
                "B. See Borrower List\n" +
                "X. Exit");

            string selection = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "X"));

            if (selection == "A") { Director.ShowDisplay(Director.StaffAccountController.CreateBorrowerAccount()); }
            else if (selection == "B") { Director.ShowDisplay(Director.StaffAccountController.SeeBorrowerList()); } // TODO
            else if (selection == "X") { JHelper.ExitPrompt(); }
        }

    }
}
