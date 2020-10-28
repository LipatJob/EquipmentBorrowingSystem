using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Logic
{
    class BorrowerLogic : BusinessLogic
    {
        public BorrowerLogic(ApplicationState state) : base(state)
        {
        }

        public User Login(User user)
        {
            int usertypeId = ApplicationState.UserTypes.Values.Where(e => e.Name == "Borrower").FirstOrDefault().Id;
            return ApplicationState.Users.Values.Where(e =>
               e.Email.ToUpper() == user.Email.ToUpper() &&
               e.Password == user.Password &&
               e.UserTypeId == usertypeId).FirstOrDefault();
        }

        public IEnumerable<EquipmentRequest> SeeBorrowHistory()
        {
            return ApplicationState.EquipmentRequests.Values.Where(e => e.BorrowerID == ApplicationState.LoggedInUser.Id);
        }

        public EquipmentRequest GetEquipmentRequest(int id)
        {
            return ApplicationState.EquipmentRequests[id];
        }


        public Response ChangePassword(string newPassword)
        {
            int index = ApplicationState.Users.Values.Where(e => e.Id == ApplicationState.LoggedInUser.Id).First().GetKey();
            ApplicationState.Users[index].Password = newPassword;
            ApplicationState.Users.SaveState();
            return new Response(true, "Success");
        }

        public Response RequestToBorrowEquipment(EquipmentRequest request)
        {
            int id = 0;
            if (ApplicationState.EquipmentRequests.Count() != 0)
            {
                id = ApplicationState.EquipmentRequests.Keys.Max() + 1;
            }

            int pendingId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Pending").First().Id;
            request.Id = id;
            //request.BorrowerID = ApplicationState.LoggedInUser.Id;
            request.RequestStatusID = pendingId;
            //temp var
            request.DateReturned = DateTime.Now;
            request.DateBorrowed = DateTime.Now;
            ApplicationState.EquipmentRequests[id] = request;
            ApplicationState.EquipmentRequests.SaveState();
            return new Response(true, "Success");
        }

        internal Response RequestToBorrowEquipment(EquipmentRequest request, IDictionary<EquipmentType, int> count)
        {
            int id = 0;
            if (ApplicationState.EquipmentRequests.Count() != 0)
            {
                id = ApplicationState.EquipmentRequests.Keys.Max() + 1;
            }

            int pendingId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Pending").First().Id;
            request.Id = id;
            request.BorrowerID = ApplicationState.LoggedInUser.Id;
            request.RequestStatusID = pendingId;
            //temp var
            request.DateReturned = DateTime.Now;
            request.DateBorrowed = DateTime.Now;
            request.ExpectedReturnDate = request.ExpectedReturnDate;

            // Get Equipment Ids
            List<int> equipmentIds = new List<int>();

            foreach (var item in count)
            {
                if(item.Value > 0)
                {
                    equipmentIds.AddRange(item.Key.Equipments
                        .Where(e => e.EquipmentCondition.Name == "Ok"
                            && (e.EquipmentRequests.Count() == 0 
                                || (e.EquipmentRequests.OrderBy(f => f.DateBorrowed).LastOrDefault().RequestStatus.Name != "Active" 
                                    &&  e.EquipmentRequests.OrderBy(f => f.DateBorrowed).LastOrDefault().RequestStatus.Name != "Pending")))
                        .Take(item.Value)
                        .Select(e=>e.Id));
                }
            }
            request.EquipmentIds = equipmentIds;

            ApplicationState.EquipmentRequests[id] = request;
            ApplicationState.EquipmentRequests.SaveState();
            return new Response(true, "Success");
        }

        internal Response CanBorrow()
        {
            var last = ApplicationState.LoggedInUser.EquipmentRequests.OrderBy(e=>e.DateBorrowed).LastOrDefault();
            if(last == null)
            {
                return new Response(true, "User can borrow");
            }

            if((last.RequestStatus.Name == "Active" || last.RequestStatus.Name == "Pending"))
            {
                return new Response(true, "User can borrow");
            }
            return new Response(false, "User has existing request");
        }

        public EquipmentRequest SeeCurrentRequest()
        {
            return ApplicationState.EquipmentRequests.Values.OrderBy(e=>e.DateBorrowed).Where(e => e.BorrowerID == ApplicationState.LoggedInUser.Id).LastOrDefault();
        }

        public Response ReturnEquipment(int id)
        {
            int returnedStatusID = ApplicationState.RequestStatuses
                .Values
                .Where(e => e.Name == "Complete")
                .First()
                .Id;
            EquipmentRequest request = ApplicationState.EquipmentRequests[id];
            ApplicationState.EquipmentRequests[id].RequestStatusID = returnedStatusID;
            ApplicationState.EquipmentRequests[id].DateReturned = DateTime.Now;
            ApplicationState.EquipmentRequests.SaveState();

            double daysBorrowed = (DateTime.Now - request.DateBorrowed).TotalHours;
            int maximumBorrowHours = request.Equipments.Min(e => e.EquipmentType.MaximumBorrowDurationDays);

            if (daysBorrowed > maximumBorrowHours)
            {
                int borrowerViolationId = 0; 
                if(ApplicationState.BorrowerViolations.Count > 0) { borrowerViolationId = ApplicationState.BorrowerViolations.Keys.Max() + 1; }
                int lateViolationId = ApplicationState.Violations
                    .Values
                    .Where(e => e.name == "Overdue")
                    .First()
                    .Id;
                ApplicationState.BorrowerViolations[id] = new BorrowerViolation(
                               id: borrowerViolationId,
                        requestId: request.Id,
                      violationID: lateViolationId,
                    amountCharged: 0,
                         resolved: false);
            }
            return new Response(true, "Success");
        }

        public IEnumerable<BorrowerViolation> SeeUnresolvedViolations()
        {
            return ApplicationState.BorrowerViolations.Values
                .Where(e => !e.Resolved && ApplicationState.EquipmentRequests.Values
                    .Any(f => f.BorrowerID == ApplicationState.LoggedInUser.Id && f.Id == e.RequestId));
        }

        public IEnumerable<BorrowerViolation> SeeViolationHistory()
        {
            return ApplicationState.BorrowerViolations.Values
                .Where(e => ApplicationState.EquipmentRequests.Values
                    .Any(f => f.BorrowerID == ApplicationState.LoggedInUser.Id && f.Id == e.RequestId));
        }

    }
}
