using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using JobLib;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EquipmentBorrowingSystem.Displays;

//Latest Edit: Mark Anthony Mamauag

namespace EquipmentBorrowingSystem.Views.Staff.BorrowedEquipmentLog
{
    class BorrowedEquipmentLogCliDisplay : CliDisplay<EquipmentRequest>
    {
        public BorrowedEquipmentLogCliDisplay(EquipmentRequest model) : base(model)
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
                              "G. See Specific Request Information\n" +
                              "X. Exit\n");

            string selection = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "C", "D", "E", "F", "G", "X"));

                 if (selection == "A") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.AllRequests()); }
            else if (selection == "B") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.PendingRequests()); }
            else if (selection == "C") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.DeniedRequests()); }
            else if (selection == "D") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.ActiveRequests()); }
            else if (selection == "E") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.CompleteRequests()); }
            else if (selection == "F") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.OverdueRequests()); }
            else if (selection == "G") { int val = RequestID(); Director.ShowDisplay(Director.BorrowedEquipmentLogController.RequestInformation(val)); }       
            else if (selection == "X") { JHelper.ExitPrompt(); }
        }

        public int RequestID()
        {
            List<EquipmentRequest> request = ApplicationState.GetInstance().EquipmentRequests.Values.ToList();
            return request[JHelper.InputInt("Enter Request ID: ", validator: e => InRange(e, 1, request.Count)) - 1].Id;
        }

        private bool InRange(int value, int min, int max)
        {
            if (value > max || value < min)
            {
                Console.WriteLine("\n>> ERROR: The ID entered does not exist <<\n");
                return false;
            }
            return true;
        }
    }
}
