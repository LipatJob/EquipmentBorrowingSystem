using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views.Staff.EquipmentManagement
{
    class EquipmentList : CliDisplay<IEnumerable<Equipment>>
    {
        public EquipmentList(Director director, IEnumerable<Equipment> model) : base(director, model)
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
                $"Equipment Type: {Director.State.EquipmentTypes[equipment.EquipmentTypeID].Name}\n" +
                $"Condition: {Director.State.EquipmentConditions[equipment.ConditionID].Name}");
                Console.WriteLine();
            }

            int id = JHelper.InputInt("Enter Id of equipment to select: ", validator: e => Director.State.Equipments.ContainsKey(e));

            Director.ShowDisplay(Director.EquipmentManagementController.ViewEquipment(id));
        }
    }
}
