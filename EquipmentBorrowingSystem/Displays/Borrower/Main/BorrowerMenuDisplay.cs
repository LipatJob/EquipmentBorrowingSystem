﻿using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Borrower.Main
{
    class BorrowerMenuDisplay : CliDisplay<Object>
    {
        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public BorrowerMenuDisplay(Object model) //<<< Replace with model class
            : base(model)
        {

        }

        public override void ShowDisplay()
        {
            // Put all Console GUI Here

            // To go to another display do:
            // Director.ShowDisplay(Director.<Your Controller>.<Your Method>());
            // Make sure <Your Method> returns a display
            // Your may pass the model to the arguments of the method
            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    "A. Manage and View Borrowed Equipment\n" +
                    "B. View Violations\n" +
                    "X. Exit");
            
                string selection = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "C", "X"));

                if (selection == "A") { Director.ShowDisplay(Director.EquipmentBorrowingController.BorrowingMenu()); }
                else if (selection == "B") { Director.ShowDisplay(Director.BorrowerViolationsController.SeeViolations()); } // TO DO
                else if (selection == "X") { break; }
            }
        }
    }

}
