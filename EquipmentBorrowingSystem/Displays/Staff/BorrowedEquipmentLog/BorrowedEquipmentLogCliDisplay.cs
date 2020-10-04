using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using JobLib;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EquipmentBorrowingSystem.Displays;

namespace EquipmentBorrowingSystem.Views.Staff.BorrowedEquipmentLog
{
    class BorrowedEquipmentLogCliDisplay : CliDisplay<Object>
    {
        public BorrowedEquipmentLogCliDisplay(Object model) : base(model)
        {

        }

        public override void ShowDisplay()
        {
            Console.Clear();
            Console.WriteLine("Borrowed Equipment Log");
            Console.WriteLine("See the Request Status of Borrowed Equipments\n");

            Console.WriteLine("View:\n" +
                              "A. All Requests\n" +
                              "B. Pending Requests\n" +
                              "C. Denied Requests\n" +
                              "D. Active Requests\n" +
                              "E. Completed Requests\n" +
                              "F. Overdue Requests\n" +
                              "X. Exit\n");

            string selection = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "C", "D", "E", "F", "X"));

                 if (selection == "A") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.AllRequests()); }
            else if (selection == "B") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.PendingRequests()); }
            else if (selection == "C") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.DeniedRequests()); }
            else if (selection == "D") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.ActiveRequests()); }
            else if (selection == "E") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.CompleteRequests()); }
            else if (selection == "F") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.OverdueRequests()); }
            else if (selection == "X") { JHelper.ExitPrompt(); }
        }
    }
}
