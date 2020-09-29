using JobLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class EquipmentType
    {
        public EquipmentType(int id, string name, int maximumBorrowDurationHours)
        {
            Id = id;
            Name = name;
            MaximumBorrowDurationHours = maximumBorrowDurationHours;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumBorrowDurationHours {get;set;}

        public static Serializer<EquipmentType> GetSerializer()
        {
            return new EquipmentTypeSerializer();
        }

        private class EquipmentTypeSerializer : Serializer<EquipmentType>
        {
            public override EquipmentType Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(RepositoryValues.DELIMITERC);
                return new EquipmentType(
                    int.Parse(values[0]),
                    values[1],
                    int.Parse(values[2])
                    );
            }

            public override string ToSerializable(EquipmentType item)
            {
                return string.Join(RepositoryValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.Name,
                    item.MaximumBorrowDurationHours.ToString()
                });
            }
        }

    }
}
