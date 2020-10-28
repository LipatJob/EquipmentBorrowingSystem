using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.EquipmentManagement
{
    class EquipmentListDisplay : CliDisplay<IEnumerable<Equipment>>
    {
        public EquipmentListDisplay(IEnumerable<Equipment> model) : base(model)
        {
        }

        public override void ShowDisplay()
        {
            Console.Clear();
            foreach (Equipment equipment in Model)
            {
                Console.WriteLine("" +
                $"Id: {equipment.Id}\n"+
                $"Code: {equipment.Code}\n" +
                $"Equipment Type: {ApplicationState.GetInstance().EquipmentTypes[equipment.EquipmentTypeID].Name}\n" +
                $"Condition: {ApplicationState.GetInstance().EquipmentConditions[equipment.ConditionID].Name}");
                Console.WriteLine();
            }

            int id = JHelper.InputInt("Enter Id of equipment to select(-1 to go back): ", validator: e => e == -1 || ApplicationState.GetInstance().Equipments.ContainsKey(e));

            if(id == -1)
            {
                return;
            }

            Director.ShowDisplay(Director.EquipmentManagementController.ViewEquipment(id));
        }
    }
}
