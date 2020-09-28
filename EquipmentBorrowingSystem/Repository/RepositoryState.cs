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
        SerializedList<User> Borrowers { get; }
        SerializedList<BorrowerViolation> BorrowerViolations { get; }
        SerializedList<Equipment> Equipments { get; }
        SerializedList<EquipmentCondition> EquipmentConditions { get; }
        SerializedList<EquipmentRequest> EquipmentRequests { get; }
        SerializedList<EquipmentType> EquipmentTypes { get; }
        SerializedList<Violation> Violations { get; }

        public RepositoryState()
        {
            Borrowers           = new SerializedList<User>(RepositoryValues.BORROWERS_FILE_NAME, User.GetSerializer());
            BorrowerViolations  = new SerializedList<BorrowerViolation>(RepositoryValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            Equipments          = new SerializedList<Equipment>(RepositoryValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            EquipmentConditions = new SerializedList<EquipmentCondition>(RepositoryValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            EquipmentRequests   = new SerializedList<EquipmentRequest>(RepositoryValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            EquipmentTypes      = new SerializedList<EquipmentType>(RepositoryValues.EQUIPMENT_TYPES_FILE_NAME, EquipmentType.GetSerializer());
            Violations          = new SerializedList<Violation>(RepositoryValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
        }
    }
}
