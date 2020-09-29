using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    class BorrowerRepository : Repository
    {
        public BorrowerRepository(RepositoryState state) : base(state)
        {

        }

        public IEnumerable<EquipmentRequest> SeeBorrowHistory()
        {
            return RepositoryState.EquipmentRequests.Where(e => e.BorrowerID == RepositoryState.LoggedInUser.Id);
        }

        public string ChangePassword(string newPassword)
        {
            int index = RepositoryState.Users.FindIndex(e => e.Id == RepositoryState.LoggedInUser.Id);
            RepositoryState.Users[index].Password = newPassword;
            return "";
        }

        public string RequestToBorrowEquipment(EquipmentRequest request)
        {
            int id = RepositoryState.EquipmentRequests.OrderByDescending(e=>e.Id).First().Id + 1;
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            request.Id = id;
            request.BorrowerID = RepositoryState.LoggedInUser.Id;
            request.RequestStatusID = pendingId;
            RepositoryState.EquipmentRequests.Append(request);
            return "";
        }

        public IEnumerable<EquipmentRequest> SeeCurrentRequests()
        {
            int pendingId = RepositoryState.RequestStatuses.Where(e => e.Name == "Pending").First().Id;
            int activeId = RepositoryState.RequestStatuses.Where(e => e.Name == "Active").First().Id;
            return RepositoryState.EquipmentRequests.Where(e => e.RequestStatusID == pendingId || e.RequestStatusID == activeId);
        }

        public string returnEquipment(int id)
        {
            int index = RepositoryState.EquipmentRequests.FindIndex(e => e.Id == id);
            int returnedStatusID = RepositoryState.RequestStatuses.Where(e => e.Name == "Complete").First().Id;
            RepositoryState.EquipmentRequests[index].RequestStatusID = returnedStatusID;
            RepositoryState.EquipmentRequests.SaveState();
            return "";
        }

    }
}
