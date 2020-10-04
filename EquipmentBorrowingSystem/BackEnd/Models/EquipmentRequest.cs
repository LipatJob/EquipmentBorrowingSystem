using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class EquipmentRequest : Keyed<int>
    {
        public EquipmentRequest() { }

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


        // Foreign Models
        public User Borrower { get { return ApplicationState.GetInstance().Users[BorrowerID]; } }
        public Equipment Equipment { get { return ApplicationState.GetInstance().Equipments[EquipmentID]; } }
        public RequestStatus RequestStatus { get { return ApplicationState.GetInstance().RequestStatuses[RequestStatusID]; } }

        // Reference Models
        public IEnumerable<BorrowerViolation> BorrowerViolations 
            { get { return ApplicationState.GetInstance().BorrowerViolations.Values.Where(e => e.RequestId == Id); } }


        public int GetKey()
        {
            return Id;
        }

        public static Serializer<EquipmentRequest> GetSerializer()
        {
            return new EquipmentRequestSerializer();
        }

        private class EquipmentRequestSerializer : Serializer<EquipmentRequest>
        {

            public override EquipmentRequest Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new EquipmentRequest(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    int.Parse(values[3]),
                    DateTime.ParseExact(values[4], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(values[5], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(values[6], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture),
                    values[7]
                    );
            }

            public override string ToSerializable(EquipmentRequest item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.BorrowerID.ToString(),
                    item.EquipmentID.ToString(),
                    item.RequestStatusID.ToString(),
                    item.ExpectedReturnDate.ToString("yyyyMMdd-HHmmss"),
                    item.DateBorrowed.ToString("yyyyMMdd-HHmmss"),
                    item.DateReturned.ToString("yyyyMMdd-HHmmss"),
                    item.Reason
                });
            }
        }
    }
}
