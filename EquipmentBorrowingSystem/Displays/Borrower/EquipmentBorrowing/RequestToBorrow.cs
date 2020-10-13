using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JobLib;
using EquipmentBorrowingSystem.Controllers;

namespace EquipmentBorrowingSystem.Displays.Borrower.EquipmentBorrowing
{
    class RequestToBorrow : CliDisplay<EquipmentRequest>
    {
        public RequestToBorrow(EquipmentRequest model) : base(model)
        {

        }

        public override void ShowDisplay()
        {
            Console.Clear();
            Model.BorrowerID = 0; //to be edited later (No Login Module)

            //dipslay list of equipments
            //input Equipment ID
            int i = 1;
            Console.WriteLine("---- Select Equipment ----");
            List<Equipment> equipments = ApplicationState.GetInstance().Equipments.Values.ToList();
            foreach (Equipment equipment in equipments) { Console.WriteLine($"{i}. {equipment.Name}"); i++; }
            Model.EquipmentID = equipments[JHelper.InputInt("Enter Selection: ", validator: e => InRange(e, 1, equipments.Count)) - 1].Id;

            Model.ExpectedReturnDate = DateTime.Parse(JHelper.InputString("\nEnter Expected Return Date: ", validator: ValidateReturnDate));
            Model.Reason = JHelper.InputString("Enter Reason: ", validator: e => e.Length != 0);

            //go to Response (Controller)
            Director.EquipmentBorrowingController.RequestToBorrow(Model);

            //go back to Borrowing Menu
            Director.ShowDisplay(Director.EquipmentBorrowingController.BorrowingMenu());
        }
        
        //list of equipments
        private bool InRange(int value, int min, int max)
        {
            if (value > max || value < min)
            {
                Console.WriteLine("\n>> The equipment you entered does not exist <<\n");
                return false;
            }
            return true;
        }

        //to validate time
        private bool ValidateReturnDate(string inputString)
        {
            DateTime dDate;

            if (DateTime.TryParse(inputString, out dDate))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\n>> Invalid Date Format <<\n");
                return false;
            }
        }
    }
}