using EquipmentBorrowingSystem.Backend.Models;
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
            Console.Clear();
            Console.WriteLine(
                "A. Request to Borrow Equipment\n" +
                "B. See Infomartion and Status (Current Request)\n" +
                "C. Return Equipment");

            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "A") { Director.ShowDisplay(Director.EquipmentBorrowingController.RequestToBorrow()); }
            else if (choice.ToUpper() == "B") { Director.ShowDisplay(Director.EquipmentManagementController.EquipmentList()); }
            else if (choice.ToUpper() == "C") { Director.ShowDisplay(Director.EquipmentManagementController.EquipmentList()); }
        }
    }
}
