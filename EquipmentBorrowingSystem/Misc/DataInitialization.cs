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


        public void Run()
        {
            // Reset Data
            DirectoryInfo di = new DirectoryInfo(ModelValues.ROOT_FOLDER);
            if(di.Exists)
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
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
            equipments.Add(new Equipment(1, 0, 1));
            equipments.Add(new Equipment(2, 0, 1));
            equipments.Add(new Equipment(3, 0, 0));
            equipments.Add(new Equipment(4, 0, 0));
            equipments.Add(new Equipment(5, 3, 0));
            equipments.Add(new Equipment(6, 7, 1));
            equipments.Add(new Equipment(7, 5, 0));
            equipments.Add(new Equipment(8, 5, 2));
            equipments.Add(new Equipment(9, 2, 0));
            equipments.Add(new Equipment(10, 1, 0));
            equipments.Add(new Equipment(11, 1, 0));
            equipments.Add(new Equipment(12, 1, 1));
            equipments.Add(new Equipment(13, 8, 0));
            equipments.Add(new Equipment(14, 9, 1));
            equipments.Add(new Equipment(15, 7, 0));
            equipments.Add(new Equipment(16, 6, 0));

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
            equipmentRequests.Add(new EquipmentRequest(0, 1, PENDING_STATUS, DateTime.Now, DateTime.Now, DateTime.Now, "Would like to borrow a table for a project presentation later for CS102-1", new[] { 1 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(1, 1, DENIED_STATUS, DateTime.Now, DateTime.Now, DateTime.Now, "To use for costume purposes", new[] { 2 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(2, 1, ACTIVE_STATUS, DateTime.Now, DateTime.Now, DateTime.Now, "For P.E. practical exam", new[] { 3 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(3, 1, COMPLETE_STATUS, DateTime.Now, DateTime.Now.AddMinutes(5), DateTime.Now, "Borrow for sports fest competition", new[] { 4, 5 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(4, 1, DENIED_STATUS, DateTime.Now, DateTime.Now, DateTime.Now, "The Yoga Mat would be used asa a prop for a video", new[] { 9 }.ToList()));
            equipmentRequests.Add(new EquipmentRequest(5, 1, PENDING_STATUS, DateTime.Now, DateTime.Now, DateTime.Now, "Basketball varsity training", new[] { 6 }.ToList()));

            var borrowerViolations = new SerializedList<BorrowerViolation>(ModelValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            borrowerViolations.Add(new BorrowerViolation(0, 0, OVERDUE_VIOLATION, 0, false));
            borrowerViolations.Add(new BorrowerViolation(1, 1, OVERDUE_VIOLATION, 0, false));
            borrowerViolations.Add(new BorrowerViolation(2, 2, BROKEN_VIOLATION, 0, true));
            borrowerViolations.Add(new BorrowerViolation(3, 3, BROKEN_VIOLATION, 0, false));
            borrowerViolations.Add(new BorrowerViolation(4, 4, LOST_VIOLATION, 0, false));
            borrowerViolations.Add(new BorrowerViolation(5, 5, LOST_VIOLATION, 0, false));

        }
    }
}
