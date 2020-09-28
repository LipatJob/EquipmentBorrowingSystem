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
    class Violation
    {
        public int Id { get; set; }
        public string name { get; set; }

        public Violation(int id, string name)
        {
            Id = id;
            this.name = name;
        }

        public static Serializer<Violation> GetSerializer()
        {
            return new ViolationSerializer();
        }

        private class ViolationSerializer : Serializer<Violation>
        {
            public override Violation Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(RepositoryValues.DELIMITERC);
                return new Violation(
                    int.Parse(values[0]),
                    values[1]
                    );
            }

            public override string ToSerializable(Violation item)
            {
                return string.Join(RepositoryValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.name
                });
            }
        }
    }
}
