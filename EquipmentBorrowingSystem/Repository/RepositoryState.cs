using EquipmentBorrowingSystem.Repository.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class RepositoryState
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

        public RepositoryState()
        {
            Users           = new SerializedList<User>(RepositoryValues.ACCOUNT_FILE_NAME, User.GetSerializer());
            BorrowerViolations  = new SerializedList<BorrowerViolation>(RepositoryValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            Equipments          = new SerializedList<Equipment>(RepositoryValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            EquipmentConditions = new SerializedList<EquipmentCondition>(RepositoryValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            EquipmentRequests   = new SerializedList<EquipmentRequest>(RepositoryValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            RequestStatuses = new SerializedList<RequestStatus>(RepositoryValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            EquipmentTypes = new SerializedList<EquipmentType>(RepositoryValues.EQUIPMENT_TYPES_FILE_NAME, EquipmentType.GetSerializer());
            Violations          = new SerializedList<Violation>(RepositoryValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
            UserTypes = new SerializedList<UserType>(RepositoryValues.USER_TYPES_FILE_NAME, UserType.GetSerializer());
        }
    }
}
