using EquipmentBorrowingSystem.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    class StaffRepository : Repository
    {
        public StaffRepository(RepositoryState state) : base(state)
        {

        }

        public string ChangePassword(User user)
        {
            int index = RepositoryState.Users.FindIndex(e => e.Id == user.Id);
            RepositoryState.Users[index] = user;
            return "";
        }



        public string AddEquipment(Equipment equipment)
        {
            equipment.Id = RepositoryState.Equipments.OrderByDescending(e=>e.Id).First().Id + 1;
            RepositoryState.Equipments.Append(equipment);
            return "";
        }

        public string EditEquipment(Equipment equipment)
        {
            int index = RepositoryState.Equipments.FindIndex(e => e.Id == equipment.Id);
            RepositoryState.Equipments[index] = equipment;
            return "";
        }

        public string DeleteEquipment(Equipment equipment)
        {
            // Find equipment with ID
            int index = RepositoryState.Equipments.FindIndex(e => e.Id == equipment.Id);
            // Delete Equipment with ID
            RepositoryState.Equipments.RemoveAt(index);
            return "";
        }

        private Equipment EquipmentViewModelToModel(EquipmentViewModel model)
        {
            int equipmentTypeId = RepositoryState.EquipmentTypes.Where(x=>x.Name == model.equipmentType).First().Id;
            int conditionId = RepositoryState.EquipmentTypes.Where(x => x.Name == model.condition).First().Id;
            return new Equipment(
                model.Id,
                equipmentTypeId,
                conditionId,
                model.name
                );
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
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Denied").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId);
        }

        public IEnumerable<EquipmentRequest> SeeAllActiveRequests()
        {
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId);
        }

        public IEnumerable<EquipmentRequest> SeeAllCompleteRequests()
        {
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Complete").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId);
        }

        public IEnumerable<EquipmentRequest> SeeAllOverdueRequests()
        {
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            DateTime currentDay = DateTime.Now;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId && 
            (currentDay - e.ExpectedReturnDate).TotalDays > RepositoryState.EquipmentTypes.Where(f => f.Id == e.EquipmentID).First().MaximumBorrowDurationHours);
        }

        public EquipmentRequest SeeRequestInformation(int id)
        {
            return RepositoryState.EquipmentRequests.Where(e => e.Id == id).First();
        }

        public string ApproveRequest(int id)
        {
            int approvedID = RepositoryState.RequestStatuses.Where(e => e.Name == "Approved").First().Id;
            int index = RepositoryState.EquipmentRequests.FindIndex(e => e.Id == id);
            RepositoryState.EquipmentRequests[index].RequestStatusID = approvedID;
            RepositoryState.EquipmentRequests.SaveState();

            return "";
        }

        public string CreateBorrowerAccount(User user)
        {
            int id = RepositoryState.Users.OrderByDescending(e => e.Id).First().Id + 1;
            int borrowerTypeID = RepositoryState.UserTypes.Where(e => e.Name == "Borrower").First().Id;
            user.Id = id;
            user.UserTypeId = borrowerTypeID;
            RepositoryState.Users.Append(user);

            return "";
        }

    }
}
