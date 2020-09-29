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
    class EquipmentRequest
    {
        public EquipmentRequest(int id, int borrowerID, int equipmentID, int requestStatusID, DateTime expectedReturnDate, DateTime dateBorrowed, DateTime dateReturned, string reason)
        {
            Id = id;
            BorrowerID = borrowerID;
            EquipmentID = equipmentID;
            RequestStatusID = requestStatusID;
            ExpectedReturnDate = expectedReturnDate;
            DateBorrowed = dateBorrowed;
            DateReturned = dateReturned;
            Reason = reason;
        }

        public int Id { get; set; }
        public int BorrowerID { get; set; }
        public int EquipmentID { get; set; }
        public int RequestStatusID { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
        public string Reason { get; set; }

        public static Serializer<EquipmentRequest> GetSerializer()
        {
            return new EquipmentRequestSerializer();
        }

        private class EquipmentRequestSerializer : Serializer<EquipmentRequest>
        {
            public override EquipmentRequest Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(RepositoryValues.DELIMITERC);
                return new EquipmentRequest(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    int.Parse(values[3]),
                    DateTime.Parse(values[4]),
                    DateTime.Parse(values[5]),
                    DateTime.Parse(values[6]),
                    values[7]
                    );
            }

            public override string ToSerializable(EquipmentRequest item)
            {
                return string.Join(RepositoryValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.BorrowerID.ToString(),
                    item.EquipmentID.ToString(),
                    item.ExpectedReturnDate.ToString(),
                    item.DateBorrowed.ToString(),
                    item.DateReturned.ToString(),
                    item.Reason
                });
            }
        }
    }
}
