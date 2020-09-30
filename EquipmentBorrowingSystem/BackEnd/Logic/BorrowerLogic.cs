using EquipmentBorrowingSystem.BackEnd.Logic.Helpers;
using EquipmentBorrowingSystem.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.BackEnd.Logic
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
            return RepositoryState.Users.Where(e => e.Email == user.Email && e.Password == user.Password).FirstOrDefault();
        }

        public IEnumerable<EquipmentRequest> SeeBorrowHistory()
        {
            return RepositoryState.EquipmentRequests.Where(e => e.BorrowerID == RepositoryState.LoggedInUser.Id);
        }


        public Response ChangePassword(string newPassword)
        {
            int index = RepositoryState.Users.FindIndex(e => e.Id == RepositoryState.LoggedInUser.Id);
            RepositoryState.Users[index].Password = newPassword;
            return new Response(true, "Success");
        }

        public Response RequestToBorrowEquipment(EquipmentRequest request)
        {
            int id = RepositoryState.EquipmentRequests.OrderByDescending(e=>e.Id).First().Id + 1;
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            request.Id = id;
            request.BorrowerID = RepositoryState.LoggedInUser.Id;
            request.RequestStatusID = pendingId;
            RepositoryState.EquipmentRequests.Add(request);
            return new Response(true, "Success");
        }

        public IEnumerable<EquipmentRequest> SeeCurrentRequests()
        {
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            int activeId = RepositoryState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId || e.RequestStatusID == activeId);
        }

        public Response ReturnEquipment(int id)
        {
            int index = RepositoryState.EquipmentRequests
                .FindIndex(e => e.Id == id);
            int returnedStatusID = RepositoryState.RequestStatuses
                .Where(e => e.Name == "Complete")
                .First()
                .Id;
            EquipmentRequest request = RepositoryState.EquipmentRequests[index];
            RepositoryState.EquipmentRequests[index].RequestStatusID = returnedStatusID;
            RepositoryState.EquipmentRequests[index].DateReturned = DateTime.Now;
            RepositoryState.EquipmentRequests.SaveState();

            double daysBorrowed = (DateTime.Now - request.DateBorrowed).TotalHours;
            Equipment equipment = RepositoryState.Equipments
                .Where(e => e.Id == request.EquipmentID)
                .First();
            int maximumBorrowHours = RepositoryState.EquipmentTypes
                .Where(e => e.Id == equipment.EquipmentTypeID)
                .First()
                .MaximumBorrowDurationHours;
            if (daysBorrowed > maximumBorrowHours)
            {
                int borrowerViolationId = RepositoryState.BorrowerViolations.
                    OrderByDescending(e => e.Id)
                    .First().
                    Id + 1;
                int lateViolationId = RepositoryState.Violations
                    .Where(e => e.name == "Overdue")
                    .First()
                    .Id;
                RepositoryState.BorrowerViolations.Add(new BorrowerViolation(
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
            return RepositoryState.BorrowerViolations
                .Where(e => !e.Resolved && RepositoryState.EquipmentRequests
                    .Any(f => f.BorrowerID == RepositoryState.LoggedInUser.Id || f.Id == e.RequestId));
        }

        public IEnumerable<BorrowerViolation> SeeViolationHistory()
        {
            return RepositoryState.BorrowerViolations
                .Where(e => RepositoryState.EquipmentRequests
                    .Any(f => f.BorrowerID == RepositoryState.LoggedInUser.Id || f.Id == e.RequestId));
        }

    }
}
