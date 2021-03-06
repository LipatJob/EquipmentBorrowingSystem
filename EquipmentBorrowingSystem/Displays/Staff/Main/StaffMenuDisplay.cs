﻿using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.Main
{
    class StaffMenuDisplay : CliDisplay<Object>
    {
        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public StaffMenuDisplay(Object model) //<<< Replace with model class
            : base(model)
        {

        }

        public override void ShowDisplay()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(
                    "A. Manage Equipment Requests\n" +
                    "B. Manage Violations\n" +
                    "C. Manage Equipment\n" +
                    "D. Manage Accounts\n" +
                    "X. Exit");

                string selection = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "C", "D", "X"));

                if (selection == "A") { Director.ShowDisplay(Director.BorrowedEquipmentLogController.AllRequests()); }
                else if (selection == "B") { Director.ShowDisplay(Director.ViolationManagementController.SeeViolations()); } // TODO
                else if (selection == "C") { Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu()); }
                else if (selection == "D") { Director.ShowDisplay(Director.StaffAccountController.AccountMenu()); } // TODO
                else if (selection == "X") { break; }
            }
            
        }

    }

}
