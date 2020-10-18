using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using JobLib;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.StaffAccount
{
    

    class BorrowersListDisplay : CliDisplay<IEnumerable<User>>
    {
        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public BorrowersListDisplay(IEnumerable<User> model) //<<< Replace with model class
            : base(model)
        {

        }

        public override void ShowDisplay()
        {
            while(true)
            {
                int i = 1;
                Console.WriteLine();
                Console.WriteLine("Select Borrower):");
                foreach (User user in Model) { Console.WriteLine($"{i}. {user.Email}"); i++; }
                int selection = JHelper.InputInt("Enter Selection(-1 to Go Back): ", validator: e => e == -1 || InRange(e, 1, Model.Count()));
                if (selection == -1) { break; }

                int id = Model.ToArray()[selection - 1].Id;
                
                Director.ShowDisplay(Director.StaffAccountController.SeeBorrowerHistory(id));
            }

        }
        private bool InRange(int value, int min, int max)
        {
            if (value > max || value < min)
            {
                if (max == min)
                {
                    Console.WriteLine($"> Enter {min}");
                }
                else
                {
                    Console.WriteLine($"> Enter a value from {min} to {max}");
                }
                return false;
            }

            return true;
        }

    }
}

