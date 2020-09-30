using EquipmentBorrowingSystem.BackEnd;
using EquipmentBorrowingSystem.BackEnd.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class ApplicationState
    {
        public User LoggedInUser { get; set; }
        public SerializedList<User> Users { get; }
        public SerializedList<BorrowerViolation> BorrowerViolations { get; }
        public SerializedList<Equipment> Equipments { get; }
        public SerializedList<EquipmentCondition> EquipmentConditions { get; }
        public SerializedList<EquipmentRequest> EquipmentRequests { get; }
        public SerializedList<RequestStatus> RequestStatuses { get; }
        public SerializedList<EquipmentType> EquipmentTypes { get; }
        public SerializedList<Violation> Violations { get; }
        public SerializedList<UserType> UserTypes { get; set; }

        public ApplicationState()
        {
            Users               = new SerializedList<User>(ModelValues.ACCOUNT_FILE_NAME, User.GetSerializer());
            BorrowerViolations  = new SerializedList<BorrowerViolation>(ModelValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            Equipments          = new SerializedList<Equipment>(ModelValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            EquipmentConditions = new SerializedList<EquipmentCondition>(ModelValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            EquipmentRequests   = new SerializedList<EquipmentRequest>(ModelValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            RequestStatuses     = new SerializedList<RequestStatus>(ModelValues.EQUIPMENT_REQUESTS_FILE_NAME, RequestStatus.GetSerializer());
            EquipmentTypes      = new SerializedList<EquipmentType>(ModelValues.EQUIPMENT_TYPES_FILE_NAME, EquipmentType.GetSerializer());
            Violations          = new SerializedList<Violation>(ModelValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
            UserTypes           = new SerializedList<UserType>(ModelValues.USER_TYPES_FILE_NAME, UserType.GetSerializer());
        }
    }
}
