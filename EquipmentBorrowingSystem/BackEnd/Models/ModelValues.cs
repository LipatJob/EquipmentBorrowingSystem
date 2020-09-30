using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.BackEnd.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class ModelValues
    {
        public const string DELIMITER = "|";
        public const char DELIMITERC = '|';
        public const string VALUE_FALSE = "False";
        public const string ACCOUNT_FILE_NAME               = "borrowers.txt";
        public const string BORROWER_VIOLATIONS_FILE_NAME   = "borrowers_violations.txt";
        public const string EQUIPMENTS_FILE_NAME            = "equipments.txt";
        public const string EQUIPMENT_CONDITIONS_FILE_NAME  = "equipment_conditions.txt";
        public const string EQUIPMENT_REQUESTS_FILE_NAME    = "equipment_requests.txt";
        public const string EQUIPMENT_TYPES_FILE_NAME       = "equipment_types.txt";
        public const string REQUEST_STAUS_FILE_NAME         = "request_status.txt";
        public const string VIOLATIONS_FILE_NAME            = "violations.txt";
        public const string USER_TYPES_FILE_NAME            = "user_types.txt";
    }
}
