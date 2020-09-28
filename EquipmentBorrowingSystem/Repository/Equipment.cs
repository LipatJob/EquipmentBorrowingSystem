using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
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

        int Id { get; set; }
        int EquipmentTypeID { get; set; }
        int ConditionID { get; set; }
        string Name { get; set; }


        public static Serializer<Equipment> GetSerializer()
        {
            return new EquipmentSerializer();
        }
        private class EquipmentSerializer : Serializer<Equipment>
        {
            public override Equipment Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(RepositoryValues.DELIMITERC);
                return new Equipment(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    values[3]
                    );
            }

            public override string ToSerializable(Equipment item)
            {
                return string.Join(RepositoryValues.DELIMITER, new string[] {
                    item.Id.ToString(), 
                    item.EquipmentTypeID.ToString(), 
                    item.ConditionID.ToString(), 
                    item.Name
                });
            }
        }
    }
}
