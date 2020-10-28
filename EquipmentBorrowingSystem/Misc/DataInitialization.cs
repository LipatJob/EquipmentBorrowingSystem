using EquipmentBorrowingSystem.Backend.Models;
using JobLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EquipmentBorrowingSystem.Misc
{
    class DataInitialization
    {

        public void ResetData()
        {
            DirectoryInfo di = new DirectoryInfo(ModelValues.ROOT_FOLDER);
            if (di.Exists)
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
        }

        public void Run(bool reset = false)
        {
            if (reset)
            {
                ResetData();
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(ModelValues.ROOT_FOLDER);
                if (di.Exists)
                {
                    return;
                }
            }
            


            // Build Data
            var userTypes = new SerializedList<UserType>(ModelValues.USER_TYPES_FILE_NAME, UserType.GetSerializer());
            userTypes.Add(new UserType(0, "Staff"));
            userTypes.Add(new UserType(1, "Borrower"));

            var users = new SerializedList<User>(ModelValues.ACCOUNT_FILE_NAME, User.GetSerializer());
            users.Add(new User(0, 0, "staff@mcl.edu.ph", "qwerty"));
            users.Add(new User(1, 0, "csorisantos@mcl.edu.ph", "qwerty"));
            users.Add(new User(2, 0, "kgkikuchi@mcl.edu.ph", "qwerty"));
            users.Add(new User(3, 0, "alilao.edu.ph", "qwerty"));
            users.Add(new User(4, 0, "danielmanaay@mcl.edu.ph", "qwerty"));
            users.Add(new User(5, 1, "borrower@mcl.edu.ph", "qwerty"));
            users.Add(new User(6, 1, "magmamauag@mcl.edu.ph", "qwerty"));
            users.Add(new User(7, 1, "jjlipat@mcl.edu.ph", "qwerty"));
            users.Add(new User(8, 1, "vedelica@mcl.edu.ph", "qwerty"));
            users.Add(new User(9, 1, "demmanaay@mcl.edu.ph", "qwerty"));
            users.Add(new User(10, 1, "cjjmoleno@mcl.edu.ph", "qwerty"));
            users.Add(new User(11, 1, "vlnuevaesp@mcl.edu.ph", "qwerty"));

            var equipmentTypes = new SerializedList<EquipmentType>(ModelValues.EQUIPMENT_TYPES_FILE_NAME, EquipmentType.GetSerializer());
            equipmentTypes.Add(new EquipmentType(0, "Chair", 2));
            equipmentTypes.Add(new EquipmentType(1, "Table", 5));
            equipmentTypes.Add(new EquipmentType(2, "Arnis", 1));
            equipmentTypes.Add(new EquipmentType(3, "Volleyball", 1));
            equipmentTypes.Add(new EquipmentType(4, "Soccer Ball", 3));
            equipmentTypes.Add(new EquipmentType(5, "Basketball", 4));
            equipmentTypes.Add(new EquipmentType(6, "Badminton Racket", 2));
            equipmentTypes.Add(new EquipmentType(7, "Ping Pong Ball", 1));
            equipmentTypes.Add(new EquipmentType(8, "Yoga Mat", 2));
            equipmentTypes.Add(new EquipmentType(9, "CD Player", 3));
            equipmentTypes.Add(new EquipmentType(10, "Test Tube", 4));

            var equipmentConditions = new SerializedList<EquipmentCondition>(ModelValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            equipmentConditions.Add(new EquipmentCondition(0, "Ok"));
            equipmentConditions.Add(new EquipmentCondition(1, "Broken"));
            equipmentConditions.Add(new EquipmentCondition(2, "Lost"));

            var equipments = new SerializedList<Equipment>(ModelValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            equipments.Add(new Equipment(0, 0, 0));
            equipments.Add(new Equipment(1, 0, 0));
            equipments.Add(new Equipment(2, 0, 0));
            equipments.Add(new Equipment(3, 0, 0));
            equipments.Add(new Equipment(4, 0, 0));
            equipments.Add(new Equipment(5, 1, 0));
            equipments.Add(new Equipment(6, 1, 0));
            equipments.Add(new Equipment(7, 1, 0));
            equipments.Add(new Equipment(8, 1, 0));
            equipments.Add(new Equipment(9, 2, 0));
            equipments.Add(new Equipment(10, 2, 0));
            equipments.Add(new Equipment(11, 2, 0));
            equipments.Add(new Equipment(12, 2, 0));
            equipments.Add(new Equipment(13, 3, 0));
            equipments.Add(new Equipment(14, 3, 0));
            equipments.Add(new Equipment(15, 3, 0));
            equipments.Add(new Equipment(16, 3, 0));
            equipments.Add(new Equipment(16, 4, 0));
            equipments.Add(new Equipment(17, 4, 0));
            equipments.Add(new Equipment(18, 4, 0));
            equipments.Add(new Equipment(19, 4, 0));
            equipments.Add(new Equipment(20, 5, 0));
            equipments.Add(new Equipment(21, 5, 0));
            equipments.Add(new Equipment(22, 5, 0));
            equipments.Add(new Equipment(23, 5, 0));
            equipments.Add(new Equipment(24, 6, 0));
            equipments.Add(new Equipment(25, 6, 0));
            equipments.Add(new Equipment(26, 6, 0));
            equipments.Add(new Equipment(27, 6, 0));
            equipments.Add(new Equipment(28, 6, 0));
            equipments.Add(new Equipment(29, 7, 0));
            equipments.Add(new Equipment(30, 7, 0));
            equipments.Add(new Equipment(31, 7, 0));
            equipments.Add(new Equipment(32, 7, 0));
            equipments.Add(new Equipment(33, 8, 0));
            equipments.Add(new Equipment(34, 8, 0));
            equipments.Add(new Equipment(33, 8, 0));
            equipments.Add(new Equipment(34, 8, 0));
            equipments.Add(new Equipment(35, 9, 0));
            equipments.Add(new Equipment(36, 9, 0));
            equipments.Add(new Equipment(37, 9, 0));
            equipments.Add(new Equipment(38, 9, 0));
            equipments.Add(new Equipment(39, 10, 0));
            equipments.Add(new Equipment(39, 10, 0));
            equipments.Add(new Equipment(39, 10, 0));
            equipments.Add(new Equipment(30, 10, 0));


            int PENDING_STATUS = 0;
            int DENIED_STATUS = 1;
            int ACTIVE_STATUS = 2;
            int COMPLETE_STATUS = 3;

            var requestStatuses = new SerializedList<RequestStatus>(ModelValues.EQUIPMENT_STATUSES_FILE_NAME, RequestStatus.GetSerializer());
            requestStatuses.Add(new RequestStatus(PENDING_STATUS, "Pending"));
            requestStatuses.Add(new RequestStatus(DENIED_STATUS, "Denied"));
            requestStatuses.Add(new RequestStatus(ACTIVE_STATUS, "Active"));
            requestStatuses.Add(new RequestStatus(COMPLETE_STATUS, "Complete"));

            int OVERDUE_VIOLATION = 0;
            int BROKEN_VIOLATION = 1;
            int LOST_VIOLATION = 2;

            var violations = new SerializedList<Violation>(ModelValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
            violations.Add(new Violation(0, "Overdue"));
            violations.Add(new Violation(1, "Broken"));
            violations.Add(new Violation(2, "Lost"));

            var equipmentRequests = new SerializedList<EquipmentRequest>(ModelValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            equipmentRequests.Add(new EquipmentRequest(0, 5, COMPLETE_STATUS, DateTime.Parse("10/2/2020"), DateTime.Parse("10/1/2020"), DateTime.Parse("10/1/2020"), "SSC Meeting", new[] { 1, 2, 3, 5 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(1, 5, COMPLETE_STATUS, DateTime.Parse("10/4/2020"), DateTime.Parse("10/3/2020"), DateTime.Parse("10/3/2020"), "Peer Mentoring", new[] { 6 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(2, 5, COMPLETE_STATUS, DateTime.Parse("10/6/2020"), DateTime.Parse("10/5/2020"), DateTime.Parse("10/5/2020"), "Peer Mentoring", new[] { 7 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(3, 5, COMPLETE_STATUS, DateTime.Parse("10/8/2020"), DateTime.Parse("10/7/2020"), DateTime.Parse("10/7/2020"), "Peer Mentoring", new[] { 8 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(4, 5, DENIED_STATUS, DateTime.Parse("10/10/2020"), DateTime.Parse("10/9/2020"), DateTime.Parse("10/9/2020"), "PE Activity", new[] { 9 }.ToList()));
               equipmentRequests.Add(new EquipmentRequest(5, 5, ACTIVE_STATUS, DateTime.Now.AddDays(1), DateTime.Now, DateTime.Now, "PE Activity", new[] { 10 }.ToList()));

               equipmentRequests.Add(new EquipmentRequest(6, 6, PENDING_STATUS, DateTime.Now.AddDays(1), DateTime.Now, DateTime.Now, "PE Activity", new[] { 11 }.ToList()));

            equipmentRequests.Add(new EquipmentRequest(7, 7, DENIED_STATUS, DateTime.Parse("10/11/2020"), DateTime.Parse("10/10/2020"), DateTime.Parse("10/10/2020"), "PE Activity", new[] { 12 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(8, 7, COMPLETE_STATUS, DateTime.Parse("10/13/2020"), DateTime.Parse("10/12/2020"), DateTime.Parse("10/12/2020"), "Volleyball Varsity", new[] { 13 }.ToList()));
               equipmentRequests.Add(new EquipmentRequest(9, 7, ACTIVE_STATUS, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now, "Volleyball Varsity", new[] { 14 }.ToList()));

            equipmentRequests.Add(new EquipmentRequest(10, 8, COMPLETE_STATUS, DateTime.Parse("10/15/2020"), DateTime.Parse("10/14/2020"), DateTime.Parse("10/14/2020"), "PE Activity", new[] { 15 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(11, 8, COMPLETE_STATUS, DateTime.Parse("10/17/2020"), DateTime.Parse("10/16/2020"), DateTime.Parse("10/16/2020"), "PE Activity", new[] { 16 }.ToList()));
            
            equipmentRequests.Add(new EquipmentRequest(12, 9, COMPLETE_STATUS, DateTime.Parse("10/10/2020"), DateTime.Parse("10/10/2020"), DateTime.Parse("10/10/2020"), "Football Varsity", new[] { 17 }.ToList()));
               equipmentRequests.Add(new EquipmentRequest(13, 9, ACTIVE_STATUS, DateTime.Now.AddDays(1), DateTime.Now, DateTime.Now, "Football Varsity", new[] { 18 }.ToList()));


            var borrowerViolations = new SerializedList<BorrowerViolation>(ModelValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            borrowerViolations.Add(new BorrowerViolation(0, 0, OVERDUE_VIOLATION, 0, false));
            borrowerViolations.Add(new BorrowerViolation(1, 1, BROKEN_VIOLATION, 100, false));
            borrowerViolations.Add(new BorrowerViolation(2, 10, LOST_VIOLATION, 200, true));


        }
    }
}
