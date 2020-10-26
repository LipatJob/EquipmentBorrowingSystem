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
    class ReturnEquipment : CliDisplay<EquipmentRequest>
    {
        public ReturnEquipment(EquipmentRequest model) : base( model)
        {

        }
        public override void ShowDisplay()
        {
            Console.Clear();
            Model.BorrowerID = 0; //to be edited later (there's still no Login Module)

            //input Equipment ID
            int i = 1;
            Console.WriteLine("Enter Equipment ID: ");
            List<Equipment> equipments = ApplicationState.GetInstance().Equipments.Values.ToList();
            //Model.EquipmentID = equipments[JHelper.InputInt("Enter Selection: ", validator: e => InRange(e, 1, equipments.Count)) - 1].Id;

            //go to Response (Controller)
            Director.EquipmentBorrowingController.RequestToBorrow(Model);

            //go back to Borrowing Menu
            Director.ShowDisplay(Director.EquipmentBorrowingController.BorrowingMenu());
        }

        //Note: I didnt delete the code below because I might ruin something. Please leave it for now.
        //(If you guys think that there's no complications, then feel free to delete the code below.)

        //list of equipments
        private bool InRange(int value, int min, int max)
        {
            if (value > max || value < min)
            {
                Console.WriteLine("> The equipment you entered does not exist <");
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
                Console.WriteLine("> Invalid Date Format <");
                return false;
            }
        }
    }
}