using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class BorrowerViolation : Keyed<int>
    {
        public BorrowerViolation(int id, int requestId, int violationID, decimal amountCharged, bool resolved)
        {
            Id = id;
            RequestId = requestId;
            ViolationId = violationID;
            AmountCharged = amountCharged;
            Resolved = resolved;
        }

        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ViolationId { get; set; }
        public decimal AmountCharged { get; set; }
        public bool Resolved { get; set; }

        public int GetKey()
        {
            return Id;
        }

        public static Serializer<BorrowerViolation> GetSerializer()
        {
            return new BorrowerViolationSerializer();
        }

        private class BorrowerViolationSerializer : Serializer<BorrowerViolation>
        {
            public override BorrowerViolation Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new BorrowerViolation(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    decimal.Parse(values[3]),
                     values[4] == bool.TrueString
                    );
            }

            public override string ToSerializable(BorrowerViolation item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(), 
                    item.RequestId.ToString(), 
                    item.ViolationId.ToString(),
                    item.AmountCharged.ToString(), 
                    item.Resolved.ToString() 
                });
            }
        }
    }
}
