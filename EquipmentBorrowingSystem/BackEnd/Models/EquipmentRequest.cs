using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class EquipmentRequest : Keyed<int>
    {
        public EquipmentRequest() { }

        public EquipmentRequest(int id, int borrowerID, int requestStatusID, DateTime expectedReturnDate, DateTime dateBorrowed, DateTime dateReturned, string reason, IEnumerable<int> equipmentIds)
        {
            Id = id;
            BorrowerID = borrowerID;
            RequestStatusID = requestStatusID;
            ExpectedReturnDate = expectedReturnDate;
            DateBorrowed = dateBorrowed;
            DateReturned = dateReturned;
            Reason = reason;
            EquipmentIds = equipmentIds;
        }

        public int Id { get; set; }
        public int BorrowerID { get; set; }
        public int RequestStatusID { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
        public string Reason { get; set; }
        public IEnumerable<int> EquipmentIds { get; set; }


        // Foreign Models
        public User Borrower { get { return ApplicationState.GetInstance().Users[BorrowerID]; } }
        public RequestStatus RequestStatus { get { return ApplicationState.GetInstance().RequestStatuses[RequestStatusID]; } }
        public IEnumerable<Equipment> Equipments { get {
                List<Equipment> equipments = new List<Equipment>();
                foreach(int id in EquipmentIds)
                {
                    equipments.Add(ApplicationState.GetInstance().Equipments[id]);
                }
                return equipments;
            } }

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
                
                string[] sids = values[7].Split(',');
                int[] ids = new int[sids.Length];
                int i = 0;
                foreach(string sid in sids)
                {
                    ids[i] = int.Parse(sid);
                }

                return new EquipmentRequest(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    DateTime.ParseExact(values[3], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(values[4], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(values[5], "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture),
                    values[6].Replace("\\n", "\n"),
                    ids
                    );
            }

            public override string ToSerializable(EquipmentRequest item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.BorrowerID.ToString(),
                    item.RequestStatusID.ToString(),
                    item.ExpectedReturnDate.ToString("yyyyMMdd-HHmmss"),
                    item.DateBorrowed.ToString("yyyyMMdd-HHmmss"),
                    item.DateReturned.ToString("yyyyMMdd-HHmmss"),
                    item.Reason.Replace("\n", "\\n"),
                    string.Join(",",item.EquipmentIds.Select(e=>e.ToString()).ToHashSet()),
                });
            }
        }
    }
}
