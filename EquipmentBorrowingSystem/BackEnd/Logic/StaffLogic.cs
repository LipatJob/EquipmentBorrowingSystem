using EquipmentBorrowingSystem.BackEnd.Logic.Helpers;
using EquipmentBorrowingSystem.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.BackEnd.Logic
{
    class StaffLogic : BusinessLogic
    {
        public StaffHelper Helper { get; }
        public StaffLogic(ApplicationState state) : base(state)
        {
            Helper = new StaffHelper(state);
        }

        public Response ChangePassword(User user)
        {
            int index = RepositoryState.Users.FindIndex(e => e.Id == user.Id);
            RepositoryState.Users[index] = user;
            return new Response(true, "Success");
        }

        public Response AddEquipment(Equipment equipment)
        {
            equipment.Id = RepositoryState.Equipments.OrderByDescending(e=>e.Id).First().Id + 1;
            RepositoryState.Equipments.Add(equipment);
            return new Response(true, "Success");
        }

        public Response EditEquipment(Equipment equipment)
        {
            int index = RepositoryState.Equipments.FindIndex(e => e.Id == equipment.Id);
            RepositoryState.Equipments[index] = equipment;
            return new Response(true, "Success");
        }

        public Response DeleteEquipment(Equipment equipment)
        {
            int index = RepositoryState.Equipments.FindIndex(e => e.Id == equipment.Id);
            RepositoryState.Equipments.RemoveAt(index);
            return new Response(true, "Success");
        }

        public IEnumerable<Equipment> SeeAllEquipments()
        {
            return RepositoryState.Equipments.AsEnumerable();
        }

        public IEnumerable<EquipmentRequest> SeeAllRequests()
        {
            return RepositoryState.EquipmentRequests;
        }

        public IEnumerable<EquipmentRequest> SeeAllPendingRequests()
        {
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId);
        }

        public IEnumerable<EquipmentRequest> SeeAllDeniedRequests()
        {
            int deniedId = RepositoryState.RequestStatuses.Where(e => e.Name == "Denied").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == deniedId);
        }

        public IEnumerable<EquipmentRequest> SeeAllActiveRequests()
        {
            int activeId = RepositoryState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == activeId);
        }

        public IEnumerable<EquipmentRequest> SeeAllCompleteRequests()
        {
            int completeId = RepositoryState.RequestStatuses.Where(e => e.Name == "Complete").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == completeId);
        }

        public IEnumerable<EquipmentRequest> SeeAllOverdueRequests()
        {
            int activeId = RepositoryState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            DateTime currentDay = DateTime.Now;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == activeId && 
            (currentDay - e.ExpectedReturnDate).TotalDays > RepositoryState.EquipmentTypes.Where(f => f.Id == e.EquipmentID).First().MaximumBorrowDurationHours);
        }

        public EquipmentRequest SeeRequestInformation(int id)
        {
            return RepositoryState.EquipmentRequests.Where(e => e.Id == id).First();
        }

        public Response ApproveRequest(int id)
        {
            int approvedID = RepositoryState.RequestStatuses.Where(e => e.Name == "Approved").First().Id;
            int index = RepositoryState.EquipmentRequests.FindIndex(e => e.Id == id);
            RepositoryState.EquipmentRequests[index].RequestStatusID = approvedID;
            RepositoryState.EquipmentRequests.SaveState();

            return new Response(true, "Success");
        }

        public Response CreateBorrowerAccount(User user)
        {
            int id = RepositoryState.Users.OrderByDescending(e => e.Id).First().Id + 1;
            int borrowerTypeID = RepositoryState.UserTypes.Where(e => e.Name == "Borrower").First().Id;
            user.Id = id;
            user.UserTypeId = borrowerTypeID;
            RepositoryState.Users.Add(user);

            return new Response(true, "Success");
        }

        public IEnumerable<BorrowerViolation> SeeUnresolvedViolations()
        {
            return RepositoryState.BorrowerViolations.Where(e => !e.Resolved);
        }

        public IEnumerable<BorrowerViolation> SeeAllViolations()
        {
            return RepositoryState.BorrowerViolations;
        }

    }
}
