using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Staff.EquipmentManagement
{
    class EquipmentMenu : CliDisplay<Object>
    {
        public EquipmentMenu(Object model) : base(model)
        {

        }
        public override void ShowDisplay()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(
                    "A. View/Edit/Delete Equipment\n" +
                    "B. Add Equipment\n" +
                    "X. Exit");

                string selection = JHelper.InputString("Enter a Selection: ", toUpper: true, validator: e => JHelper.In(e, "A", "B", "X"));

                if (selection == "A") { Director.ShowDisplay(Director.EquipmentManagementController.EquipmentList()); }
                else if (selection == "B") { Director.ShowDisplay(Director.EquipmentManagementController.AddEquipment()); }
                else if (selection == "X") { break; }
            }
        }
    }
}
