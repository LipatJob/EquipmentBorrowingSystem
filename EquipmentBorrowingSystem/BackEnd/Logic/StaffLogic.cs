using EquipmentBorrowingSystem.Backend.Logic.Helpers;
using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Logic
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
            int index = ApplicationState.Users.FindIndex(e => e.Id == user.Id);
            ApplicationState.Users[index] = user;
            return new Response(true, "Success");
        }

        public Response AddEquipment(Equipment equipment)
        {
            equipment.Id = ApplicationState.Equipments.OrderByDescending(e=>e.Id).First().Id + 1;
            ApplicationState.Equipments.Add(equipment);
            return new Response(true, "Success");
        }

        public Response EditEquipment(Equipment equipment)
        {
            int index = ApplicationState.Equipments.FindIndex(e => e.Id == equipment.Id);
            ApplicationState.Equipments[index] = equipment;
            return new Response(true, "Success");
        }

        public Response DeleteEquipment(Equipment equipment)
        {
            int index = ApplicationState.Equipments.FindIndex(e => e.Id == equipment.Id);
            ApplicationState.Equipments.RemoveAt(index);
            return new Response(true, "Success");
        }

        public IEnumerable<Equipment> SeeAllEquipments()
        {
            return ApplicationState.Equipments.AsEnumerable();
        }

        public IEnumerable<EquipmentRequest> SeeAllRequests()
        {
            return ApplicationState.EquipmentRequests;
        }

        public IEnumerable<EquipmentRequest> SeeAllPendingRequests()
        {
            int pendingId = ApplicationState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            return ApplicationState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId);
        }

        public IEnumerable<EquipmentRequest> SeeAllDeniedRequests()
        {
            int deniedId = ApplicationState.RequestStatuses.Where(e => e.Name == "Denied").First().Id;
            return ApplicationState.EquipmentRequests.Where(e => e.RequestStatusID == deniedId);
        }

        public IEnumerable<EquipmentRequest> SeeAllActiveRequests()
        {
            int activeId = ApplicationState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            return ApplicationState.EquipmentRequests.Where(e => e.RequestStatusID == activeId);
        }

        public IEnumerable<EquipmentRequest> SeeAllCompleteRequests()
        {
            int completeId = ApplicationState.RequestStatuses.Where(e => e.Name == "Complete").First().Id;
            return ApplicationState.EquipmentRequests.Where(e => e.RequestStatusID == completeId);
        }

        public IEnumerable<EquipmentRequest> SeeAllOverdueRequests()
        {
            int activeId = ApplicationState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            DateTime currentDay = DateTime.Now;
            return ApplicationState.EquipmentRequests.Where(e => e.RequestStatusID == activeId && 
            (currentDay - e.ExpectedReturnDate).TotalDays > ApplicationState.EquipmentTypes.Where(f => f.Id == e.EquipmentID).First().MaximumBorrowDurationHours);
        }

        public EquipmentRequest SeeRequestInformation(int id)
        {
            return ApplicationState.EquipmentRequests.Where(e => e.Id == id).First();
        }

        public Response ApproveRequest(int id)
        {
            int approvedID = ApplicationState.RequestStatuses.Where(e => e.Name == "Approved").First().Id;
            int index = ApplicationState.EquipmentRequests.FindIndex(e => e.Id == id);
            ApplicationState.EquipmentRequests[index].RequestStatusID = approvedID;
            ApplicationState.EquipmentRequests.SaveState();

            return new Response(true, "Success");
        }

        public Response CreateBorrowerAccount(User user)
        {
            int id = ApplicationState.Users.OrderByDescending(e => e.Id).First().Id + 1;
            int borrowerTypeID = ApplicationState.UserTypes.Where(e => e.Name == "Borrower").First().Id;
            user.Id = id;
            user.UserTypeId = borrowerTypeID;
            ApplicationState.Users.Add(user);

            return new Response(true, "Success");
        }

        public IEnumerable<BorrowerViolation> SeeUnresolvedViolations()
        {
            return ApplicationState.BorrowerViolations.Where(e => !e.Resolved);
        }

        public IEnumerable<BorrowerViolation> SeeAllViolations()
        {
            return ApplicationState.BorrowerViolations;
        }

    }
}
