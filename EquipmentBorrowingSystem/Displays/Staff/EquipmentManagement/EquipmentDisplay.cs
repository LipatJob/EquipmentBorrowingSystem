using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Staff.EquipmentManagement
{
    class EquipmentDisplay : CliDisplay<Equipment>
    {
        public enum ViewMode { ADD, VIEW }

        ViewMode selectedMode;

        public EquipmentDisplay(Equipment model, ViewMode mode):base(model)
        {
            selectedMode = mode;
        }

        public override void ShowDisplay()
        {
            if(selectedMode == ViewMode.ADD)
            {
                AddEquipment();
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    // Display Equipment
                    DisplayEquipment();
                    Console.WriteLine();

                    // Display Selection
                    Console.WriteLine(
                    "Actions:\n"  +
                    "A. Edit\n"   +
                    "B. Delete\n" +
                    "X. Return to Menu\n");

                    string selection = JHelper.InputString("Enter Selection: ", toUpper: true, validator: e => InSelection(e, "A", "B", "X"));
                    Console.WriteLine("\n");

                    // Choose Respective method for selection
                    if (selection == "A")
                    {
                        EditEquipment();
                        Director.ShowDisplay(Director.EquipmentManagementController.EquipmentList());
                    }
                    else if (selection == "B")
                    {
                        DeleteEquipment();
                        Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
                    }
                    else if (selection == "X") { Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu()); }
                }
            }
        }

        private void DisplayEquipment()
        {
            Console.WriteLine("" +
                $"Name: {Model.Code}\n" +
                $"Equipment Type: {Model.EquipmentType.Name}\n" +
                $"Condition: {Model.EquipmentCondition.Name}");
        }

        private void AddEquipment()
        {
            Console.Clear();
            // Create Empty Equipment to be filled out later
            Equipment equipment = new Equipment(0, 0, 0);

            // Enter Equipment Type
            int i = 1;
            Console.WriteLine();
            Console.WriteLine("Select Equipment Type");
            List<EquipmentType> types = ApplicationState.GetInstance().EquipmentTypes.Values.ToList();
            foreach (EquipmentType type in types)  { Console.WriteLine($"{i}. {type.Name}"); i++; }
            equipment.EquipmentTypeID = types[JHelper.InputInt("Enter Selection: ", validator: e => InRange(e, 1, types.Count)) - 1].Id;

            // Enter Equipment Condition
            i = 1;
            Console.WriteLine();
            Console.WriteLine("Select Equipment Condition");
            List<EquipmentCondition> conditions = ApplicationState.GetInstance().EquipmentConditions.Values.ToList();
            foreach (EquipmentCondition condition in conditions){ Console.WriteLine($"{i}. {condition.Name}"); i++; }
            equipment.ConditionID = conditions[JHelper.InputInt("Enter Selection: ", validator: e => InRange(e, 1, conditions.Count)) - 1].Id;

            // Add Equipment
            Director.EquipmentManagementController.AddEquipment(equipment);

            // Go Back to Menu
            Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
        }

        private void EditEquipment()
        {
            Console.Clear();
            while(true)
            {
                DisplayEquipment();
                Console.WriteLine();

                Console.WriteLine(
                "A. Name\n" +
                "B. Equipment Type\n" +
                "C. Condition\n" +
                "X. Save Changes and Return");
                string selection = JHelper.InputString("Enter Field to Edit", toUpper: true, validator: e => InSelection(e, "A", "B", "C", "X", "Y"));

                if (selection == "A")
                {
                    // Edit Equipment Name
                }
                else if (selection == "B")
                {
                    // Edit Equipment Type
                    int i = 1;
                    Console.WriteLine("Select Equipment Type");
                    List<EquipmentType> types = ApplicationState.GetInstance().EquipmentTypes.Values.ToList();
                    foreach (EquipmentType type in types) { Console.WriteLine($"{i}. {type.Name}"); i++; }
                    Model.EquipmentTypeID = types[JHelper.InputInt("Enter Selection: ", validator: e => InRange(e, 1, types.Count)) - 1].Id;
                }
                else if (selection == "C")
                {
                    int i = 1;
                    Console.WriteLine("Select Equipment Condition");
                    List<EquipmentCondition> conditions = ApplicationState.GetInstance().EquipmentConditions.Values.ToList();
                    foreach (EquipmentCondition condition in conditions) { Console.WriteLine($"{i}. {condition.Name}"); i++; }
                    Model.ConditionID = conditions[JHelper.InputInt("Enter Selection: ", validator: e => InRange(e, 1, conditions.Count)) - 1].Id;
                }
                else if (selection == "X") { break; }
            }

            Director.EquipmentManagementController.EditEquipment(Model);
        }

        private bool DeleteEquipment()
        {
            Console.Clear();
            Response response = Director.EquipmentManagementController.DeleteEquipment(Model.Id);
            if (response.Success)
            {
                Console.WriteLine("Successfuly Deleted");
                return true;
            }

            Console.WriteLine("> Deletion Failed");

            JHelper.ContinuePrompt();
            return false;
        }

        private bool ValidateName(string name)
        {
            if(name.Length == 0)
            {
                Console.WriteLine("> Name must not be empty");
                return false;
            }
            return true;
        }

        private bool InSelection(string value, params string[] selection)
        {
            if(!selection.Contains(value))
            {
                Console.WriteLine($"> Please Enter from the Selection: {string.Join(", ", selection)}");
                return false;
            }
            return true;
        }

        private bool InRange(int value, int min, int max)
        {
            if(value > max || value < min)
            {
                if(max == min)
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
