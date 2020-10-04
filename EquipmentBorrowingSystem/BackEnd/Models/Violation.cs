using EquipmentBorrowingSystem.JobLib;
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
    class Violation : Keyed<int>
    {
        public Violation() { }
        public Violation(int id, string name)
        {
            Id = id;
            this.name = name;
        }

        public int Id { get; set; }
        public string name { get; set; }


        // Reference Models
        public IEnumerable<BorrowerViolation> BorrowerViolations
            { get { return ApplicationState.GetInstance().BorrowerViolations.Values.Where(e => e.ViolationId == Id); } }

        public int GetKey()
        {
            return Id;
        }

        public static Serializer<Violation> GetSerializer()
        {
            return new ViolationSerializer();
        }

        private class ViolationSerializer : Serializer<Violation>
        {
            public override Violation Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new Violation(
                    int.Parse(values[0]),
                    values[1]
                    );
            }

            public override string ToSerializable(Violation item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.name
                });
            }
        }
    }
}
