﻿using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return ApplicationState.Users.Values.Where(e => e.Email == user.Email && e.Password == user.Password).FirstOrDefault();
        }

        public IEnumerable<EquipmentRequest> SeeBorrowHistory()
        {
            return ApplicationState.EquipmentRequests.Values.Where(e => e.BorrowerID == ApplicationState.LoggedInUser.Id);
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
            int id = ApplicationState.EquipmentRequests.Values.OrderByDescending(e=>e.Id).First().Id + 1;
            int pendingId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Pending").First().Id;
            request.Id = id;
            request.BorrowerID = ApplicationState.LoggedInUser.Id;
            request.RequestStatusID = pendingId;
            ApplicationState.EquipmentRequests[id] = request;
            ApplicationState.EquipmentRequests.SaveState();
            return new Response(true, "Success");
        }

        public IEnumerable<EquipmentRequest> SeeCurrentRequests()
        {
            int pendingId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Pending").First().Id;
            int activeId = ApplicationState.RequestStatuses.Values.Where(e => e.Name == "Active").First().Id;
            return ApplicationState.EquipmentRequests.Values.Where(e => e.RequestStatusID == pendingId || e.RequestStatusID == activeId);
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
            Equipment equipment = ApplicationState.Equipments[request.EquipmentID];
            int maximumBorrowHours = ApplicationState.EquipmentTypes[equipment.EquipmentTypeID].MaximumBorrowDurationHours;
            if (daysBorrowed > maximumBorrowHours)
            {
                int borrowerViolationId = ApplicationState.BorrowerViolations.Keys.Max() + 1;
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
                    .Any(f => f.BorrowerID == ApplicationState.LoggedInUser.Id || f.Id == e.RequestId));
        }

        public IEnumerable<BorrowerViolation> SeeViolationHistory()
        {
            return ApplicationState.BorrowerViolations.Values
                .Where(e => ApplicationState.EquipmentRequests.Values
                    .Any(f => f.BorrowerID == ApplicationState.LoggedInUser.Id || f.Id == e.RequestId));
        }

    }
}
