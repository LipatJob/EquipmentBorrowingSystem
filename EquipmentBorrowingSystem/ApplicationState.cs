using EquipmentBorrowingSystem.Backend;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Data;
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
        private static ApplicationState Instance;

        public static ApplicationState GetInstance()
        {
            if(Instance == null)
            {
                Instance = new ApplicationState();
            }
            return Instance;
        }

        private ApplicationState()
        {
            Users               = new SerializedDictionary<int, User>(ModelValues.ACCOUNT_FILE_NAME, User.GetSerializer());
            BorrowerViolations  = new SerializedDictionary<int, BorrowerViolation>(ModelValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            Equipments          = new SerializedDictionary<int, Equipment>(ModelValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            EquipmentConditions = new SerializedDictionary<int, EquipmentCondition>(ModelValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            EquipmentRequests   = new SerializedDictionary<int, EquipmentRequest>(ModelValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            RequestStatuses     = new SerializedDictionary<int, RequestStatus>(ModelValues.EQUIPMENT_STATUSES_FILE_NAME, RequestStatus.GetSerializer());
            EquipmentTypes      = new SerializedDictionary<int, EquipmentType>(ModelValues.EQUIPMENT_TYPES_FILE_NAME, EquipmentType.GetSerializer());
            Violations          = new SerializedDictionary<int, Violation>(ModelValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
            UserTypes           = new SerializedDictionary<int, UserType>(ModelValues.USER_TYPES_FILE_NAME, UserType.GetSerializer());
        
        }

        public User LoggedInUser { get; set; }
        public SerializedDictionary<int, User> Users { get; }
        public SerializedDictionary<int, BorrowerViolation> BorrowerViolations { get; }
        public SerializedDictionary<int, Equipment> Equipments { get; }
        public SerializedDictionary<int, EquipmentCondition> EquipmentConditions { get; }
        public SerializedDictionary<int, EquipmentRequest> EquipmentRequests { get; }
        public SerializedDictionary<int, RequestStatus> RequestStatuses { get; }
        public SerializedDictionary<int, EquipmentType> EquipmentTypes { get; }
        public SerializedDictionary<int, Violation> Violations { get; }
        public SerializedDictionary<int, UserType> UserTypes { get; set; }
    }
}
