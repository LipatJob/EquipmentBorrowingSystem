using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class BorrowerViolation
    {
        public BorrowerViolation(int id, int borrowedEquipmentID, int violationID, decimal amountCharged, bool resolved)
        {
            Id = id;
            BorrowedEquipmentID = borrowedEquipmentID;
            ViolationID = violationID;
            AmountCharged = amountCharged;
            Resolved = resolved;
        }

        public int Id { get; set; }
        public int BorrowedEquipmentID { get; set; }
        public int ViolationID { get; set; }
        public decimal AmountCharged { get; set; }
        public bool Resolved { get; set; }

        public static Serializer<BorrowerViolation> GetSerializer()
        {
            return new BorrowerViolationSerializer();
        }

        private class BorrowerViolationSerializer : Serializer<BorrowerViolation>
        {
            public override BorrowerViolation Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(RepositoryValues.DELIMITERC);
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
                return string.Join(RepositoryValues.DELIMITER, new string[] {
                    item.Id.ToString(), 
                    item.BorrowedEquipmentID.ToString(), 
                    item.ViolationID.ToString(),
                    item.AmountCharged.ToString(), 
                    item.Resolved.ToString() 
                });
            }
        }
    }
}
