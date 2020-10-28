using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
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
        public StaffLogic(ApplicationState state) : base(state)
        {
        }

        public User Login(User user)
        {
            int usertypeId = ApplicationState.UserTypes.Values.Where(e => e.Name == "Staff").FirstOrDefault().Id;
            return ApplicationState.Users.Values.Where(e => e.Email == user.Email && e.Password == user.Password && e.UserTypeId == usertypeId).FirstOrDefault();
        }


        public Response ChangePassword(User user)
        {
            ApplicationState.Users[user.Id] = user;
            return new Response(true, "Success");
        }

        public Response AddEquipment(Equipment equipment)
        {
            equipment.Id = ApplicationState.Equipments.Keys.Max() + 1;
            ApplicationState.Equipments[equipment.Id] = equipment;
            return new Response(true, "Success");
        }

        public Equipment GetEquipment(int id)
        {
            return ApplicationState.Equipments[id];
        }

        public Response EditEquipment(Equipment equipment)
        {
            ApplicationState.Equipments[equipment.Id] = equipment;
            return new Response(true, "Success");
        }

        public Response DeleteEquipment(int id)
        {
            ApplicationState.Equipments.Remove(id);
            return new Response(true, "Success");
        }

        public Response DeleteViolation(int id)
        {
            try
            {
                ApplicationState.BorrowerViolations.Remove(id);
            }
            catch (Exception)
            {
                return new Response(false, "Something went wrong. Try again");
            }
            return new Response(true, "Success");
        }


        public IEnumerable<Equipment> SeeAllEquipments()
        {
            return ApplicationState.Equipments.Values;
        }

        public Response AddViolation(BorrowerViolation model)
        {
            model.Id = JHelper.GetNewKey(ApplicationState.BorrowerViolations.Keys);
            ApplicationState.BorrowerViolations[model.Id] = model;
            return new Response(true, "Success");
        }

        public Response EditViolation(BorrowerViolation model)
        {
            ApplicationState.BorrowerViolations[model.Id] = model;
            return new Response(true, "Success");
        }

        internal Response AccomplishRequest(int idVal)
        {
            int completeId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Complete").First().Id;
            ApplicationState.EquipmentRequests[idVal].RequestStatusID = completeId;
            ApplicationState.EquipmentRequests.SaveState();
            return new Response(true, "Success");
        }

        internal Response IsRequestOverdue(int id)
        {
            int activeId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Active").First().Id;
            DateTime currentDay = DateTime.Now;
            bool isOverdue = ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == activeId &&
            e.DateBorrowed > e.ExpectedReturnDate).Any(e=>e.Id == id);

            return new Response(isOverdue, "Success");
        }

        public IEnumerable<EquipmentRequest> SeeAllRequests()
        {
            return ApplicationState.EquipmentRequests.Values.OrderByDescending(e=>e.DateBorrowed);
        }

        public IEnumerable<EquipmentRequest> SeeAllPendingRequests()
        {
            int pendingId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Pending").First().Id;
            return ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == pendingId);
        }

        public IEnumerable<EquipmentRequest> SeeAllDeniedRequests()
        {
            int deniedId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Denied").First().Id;
            return ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == deniedId);
        }

        public IEnumerable<EquipmentRequest> SeeAllActiveRequests()
        {
            int activeId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Active").First().Id;
            return ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == activeId);
        }

        public IEnumerable<EquipmentRequest> SeeAllCompleteRequests()
        {
            int completeId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Complete").First().Id;
            return ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == completeId);
        }

        public IEnumerable<EquipmentRequest> SeeAllOverdueRequests()
        {
            int activeId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Active").First().Id;
            DateTime currentDay = DateTime.Now;
            return ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == activeId &&
            e.DateBorrowed > e.ExpectedReturnDate);
        }

        public EquipmentRequest SeeRequestInformation(int id)
        {
            return ApplicationState.EquipmentRequests[id];
        }

        public Response ApproveRequest(int id)
        {
            int approvedID = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Active").First().Id;
            ApplicationState.EquipmentRequests[id].RequestStatusID = approvedID;
            ApplicationState.EquipmentRequests.SaveState();

            return new Response(true, "Success");
        }

        public Response DenyRequest(int id)
        {
            int approvedID = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Denied").First().Id;
            ApplicationState.EquipmentRequests[id].RequestStatusID = approvedID;
            ApplicationState.EquipmentRequests.SaveState();

            return new Response(true, "Success");
        }

        public Response CreateBorrowerAccount(User user)
        {
            int id = ApplicationState.Users.Keys.Max() + 1;
            int borrowerTypeID = ApplicationState.UserTypes.Values.Where(e => e.Name == "Borrower").First().Id;
            user.Id = id;
            user.UserTypeId = borrowerTypeID;
            ApplicationState.Users[id] = user;

            return new Response(true, "Success");
        }

        public IEnumerable<EquipmentRequest> SeeBorrowHistory(int id)
        {
            return ApplicationState.EquipmentRequests.Values.Where(e => e.BorrowerID == id).OrderByDescending(e => e.DateBorrowed);
        }

        public IEnumerable<BorrowerViolation> SeeUnresolvedViolations()
        {
            return ApplicationState.BorrowerViolations.Values.Where(e => !e.Resolved).OrderByDescending(e => e.EquipmentRequest.DateBorrowed);
        }

        public IEnumerable<BorrowerViolation> SeeAllViolations()
        {
            return ApplicationState.BorrowerViolations.Values.OrderByDescending(e=>e.EquipmentRequest.DateBorrowed);
        }

        public IEnumerable<User> SeeBorrowersList()
        {
            int borrowerTypeId = ApplicationState.UserTypes.Values.Where(e => e.Name == "Borrower").FirstOrDefault().Id;
            return ApplicationState.Users.Values.Where(e => e.UserTypeId == borrowerTypeId);
        }

        public BorrowerViolation GetViolation(int id)
        {
            return ApplicationState.BorrowerViolations[id];
        }

    }
}
