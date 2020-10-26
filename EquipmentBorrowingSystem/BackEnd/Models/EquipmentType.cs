using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class EquipmentType : Keyed<int>
    {
        public EquipmentType() { }
        public EquipmentType(int id, string name, int maximumBorrowDurationHours)
        {
            Id = id;
            Name = name;
            MaximumBorrowDurationDays = maximumBorrowDurationHours;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumBorrowDurationDays {get;set;}

        // Reference Models
        public IEnumerable<Equipment> Equipments
            { get { return ApplicationState.GetInstance().Equipments.Values.Where(e => e.EquipmentTypeID == Id); } }


        public int GetKey()
        {
            return Id;
        }

        public static Serializer<EquipmentType> GetSerializer()
        {
            return new EquipmentTypeSerializer();
        }

        private class EquipmentTypeSerializer : Serializer<EquipmentType>
        {
            public override EquipmentType Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new EquipmentType(
                    int.Parse(values[0]),
                    values[1],
                    int.Parse(values[2])
                    );
            }

            public override string ToSerializable(EquipmentType item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.Name,
                    item.MaximumBorrowDurationDays.ToString()
                });
            }
        }

    }
}
