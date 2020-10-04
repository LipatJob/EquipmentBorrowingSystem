using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.EquipmentManagement
{
    class EquipmentList : CliDisplay<IEnumerable<Equipment>>
    {
        public EquipmentList(IEnumerable<Equipment> model) : base(model)
        {
        }

        public override void ShowDisplay()
        {
            Console.Clear();
            foreach (Equipment equipment in Model)
            {
                Console.WriteLine("" +
                $"Id: {equipment.Id}\n"+
                $"Name: {equipment.Name}\n" +
                $"Equipment Type: {ApplicationState.GetInstance().EquipmentTypes[equipment.EquipmentTypeID].Name}\n" +
                $"Condition: {ApplicationState.GetInstance().EquipmentConditions[equipment.ConditionID].Name}");
                Console.WriteLine();
            }

            int id = JHelper.InputInt("Enter Id of equipment to select: ", validator: e => ApplicationState.GetInstance().Equipments.ContainsKey(e));

            Director.ShowDisplay(Director.EquipmentManagementController.ViewEquipment(id));
        }
    }
}
