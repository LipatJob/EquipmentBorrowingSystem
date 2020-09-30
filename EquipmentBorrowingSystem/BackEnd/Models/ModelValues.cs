using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class ModelValues
    {
        public static string ROOT_FOLDER = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data";
        public const string DELIMITER = "|";
        public const char DELIMITERC = '|';
        public const string VALUE_FALSE = "False";
        public static string ACCOUNT_FILE_NAME               = ROOT_FOLDER + "/accounts.txt";
        public static string BORROWER_VIOLATIONS_FILE_NAME   = ROOT_FOLDER + "/borrowers_violations.txt";
        public static string EQUIPMENTS_FILE_NAME            = ROOT_FOLDER + "/equipments.txt";
        public static string EQUIPMENT_CONDITIONS_FILE_NAME  = ROOT_FOLDER + "/equipment_conditions.txt";
        public static string EQUIPMENT_REQUESTS_FILE_NAME    = ROOT_FOLDER + "/equipment_requests.txt";
        public static string EQUIPMENT_TYPES_FILE_NAME       = ROOT_FOLDER + "/equipment_types.txt";
        public static string EQUIPMENT_STATUSES_FILE_NAME    = ROOT_FOLDER + "/equipment_statuses.txt";
        public static string REQUEST_STAUS_FILE_NAME         = ROOT_FOLDER + "/request_status.txt";
        public static string VIOLATIONS_FILE_NAME            = ROOT_FOLDER + "/violations.txt";
        public static string USER_TYPES_FILE_NAME            = ROOT_FOLDER + "/user_types.txt";
    }
}
