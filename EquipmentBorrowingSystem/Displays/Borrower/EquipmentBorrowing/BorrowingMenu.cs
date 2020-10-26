using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Borrower.EquipmentBorrowing
{
    class BorrowingMenu : CliDisplay<Object>
    {
        public BorrowingMenu(Object model) : base(model)
        {

        }
        public override void ShowDisplay()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(
                    "------Manage and View Borrowed Equipment------\n" +
                    "A. Request to Borrow Equipment\n" +
                    "B. See Information and Status (Current Request)\n" +
                    "C. See Borrow History\n" + 
                    "X. Back");
                string choice = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "C", "X"));

                if (choice.ToUpper() == "A") { Director.ShowDisplay(Director.EquipmentBorrowingController.RequestToBorrow()); }
                else if (choice.ToUpper() == "B") { Director.ShowDisplay(Director.EquipmentBorrowingController.SeeCurrentRequest()); }
                else if (choice.ToUpper() == "C") { Director.ShowDisplay(Director.EquipmentBorrowingController.SeeBorrowHistory()); }
                else if (choice.ToUpper() == "X") { break; }
            }

        }
    }
}
