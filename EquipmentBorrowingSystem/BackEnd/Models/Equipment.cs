using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.BackEnd.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class Equipment
    {
        public Equipment(int id, int equipmentTypeID, int conditionID, string name)
        {
            Id = id;
            EquipmentTypeID = equipmentTypeID;
            ConditionID = conditionID;
            Name = name;
        }

        public int Id { get; set; }
        public int EquipmentTypeID { get; set; }
        public int ConditionID { get; set; }
        public string Name { get; set; }


        public static Serializer<Equipment> GetSerializer()
        {
            return new EquipmentSerializer();
        }
        private class EquipmentSerializer : Serializer<Equipment>
        {
            public override Equipment Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new Equipment(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    values[3]
                    );
            }

            public override string ToSerializable(Equipment item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(), 
                    item.EquipmentTypeID.ToString(), 
                    item.ConditionID.ToString(), 
                    item.Name
                });
            }
        }
    }
}
