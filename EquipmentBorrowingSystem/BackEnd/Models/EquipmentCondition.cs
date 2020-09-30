using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class EquipmentCondition
    {
        public EquipmentCondition(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static Serializer<EquipmentCondition> GetSerializer()
        {
            return new EquipmentConditionSerializer();
        }

        private class EquipmentConditionSerializer : Serializer<EquipmentCondition>
        {
            public override EquipmentCondition Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new EquipmentCondition(int.Parse(values[0]), values[1]);
            }

            public override string ToSerializable(EquipmentCondition item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] { item.Id.ToString(), item.Name});
            }
        }
    }
}
