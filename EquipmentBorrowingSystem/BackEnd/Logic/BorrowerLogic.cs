using EquipmentBorrowingSystem.Backend.Logic.Helpers;
using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Logic
{
    class BorrowerLogic : BusinessLogic
    {
        public BorrowerHelper Helper { get; }
        public BorrowerLogic(ApplicationState state) : base(state)
        {
            this.Helper = new BorrowerHelper(state);
        }

        public User Login(User user)
        {
            return ApplicationState.Users.Where(e => e.Email == user.Email && e.Password == user.Password).FirstOrDefault();
        }

        public IEnumerable<EquipmentRequest> SeeBorrowHistory()
        {
            return ApplicationState.EquipmentRequests.Where(e => e.BorrowerID == ApplicationState.LoggedInUser.Id);
        }


        public Response ChangePassword(string newPassword)
        {
            int index = ApplicationState.Users.FindIndex(e => e.Id == ApplicationState.LoggedInUser.Id);
            ApplicationState.Users[index].Password = newPassword;
            return new Response(true, "Success");
        }

        public Response RequestToBorrowEquipment(EquipmentRequest request)
        {
            int id = ApplicationState.EquipmentRequests.OrderByDescending(e=>e.Id).First().Id + 1;
            int pendingId = ApplicationState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            request.Id = id;
            request.BorrowerID = ApplicationState.LoggedInUser.Id;
            request.RequestStatusID = pendingId;
            ApplicationState.EquipmentRequests.Add(request);
            return new Response(true, "Success");
        }

        public IEnumerable<EquipmentRequest> SeeCurrentRequests()
        {
            int pendingId = ApplicationState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            int activeId = ApplicationState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            return ApplicationState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId || e.RequestStatusID == activeId);
        }

        public Response ReturnEquipment(int id)
        {
            int index = ApplicationState.EquipmentRequests
                .FindIndex(e => e.Id == id);
            int returnedStatusID = ApplicationState.RequestStatuses
                .Where(e => e.Name == "Complete")
                .First()
                .Id;
            EquipmentRequest request = ApplicationState.EquipmentRequests[index];
            ApplicationState.EquipmentRequests[index].RequestStatusID = returnedStatusID;
            ApplicationState.EquipmentRequests[index].DateReturned = DateTime.Now;
            ApplicationState.EquipmentRequests.SaveState();

            double daysBorrowed = (DateTime.Now - request.DateBorrowed).TotalHours;
            Equipment equipment = ApplicationState.Equipments
                .Where(e => e.Id == request.EquipmentID)
                .First();
            int maximumBorrowHours = ApplicationState.EquipmentTypes
                .Where(e => e.Id == equipment.EquipmentTypeID)
                .First()
                .MaximumBorrowDurationHours;
            if (daysBorrowed > maximumBorrowHours)
            {
                int borrowerViolationId = ApplicationState.BorrowerViolations.
                    OrderByDescending(e => e.Id)
                    .First().
                    Id + 1;
                int lateViolationId = ApplicationState.Violations
                    .Where(e => e.name == "Overdue")
                    .First()
                    .Id;
                ApplicationState.BorrowerViolations.Add(new BorrowerViolation(
                               id: borrowerViolationId,
                        requestId: request.Id,
                      violationID: lateViolationId,
                    amountCharged: 0,
                         resolved: false));
            }
            return new Response(true, "Success");
        }

        public IEnumerable<BorrowerViolation> SeeUnresolvedViolations()
        {
            return ApplicationState.BorrowerViolations
                .Where(e => !e.Resolved && ApplicationState.EquipmentRequests
                    .Any(f => f.BorrowerID == ApplicationState.LoggedInUser.Id || f.Id == e.RequestId));
        }

        public IEnumerable<BorrowerViolation> SeeViolationHistory()
        {
            return ApplicationState.BorrowerViolations
                .Where(e => ApplicationState.EquipmentRequests
                    .Any(f => f.BorrowerID == ApplicationState.LoggedInUser.Id || f.Id == e.RequestId));
        }

    }
}
