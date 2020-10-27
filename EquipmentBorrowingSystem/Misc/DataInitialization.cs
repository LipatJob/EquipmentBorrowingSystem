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
            users.Add(new User(1, 1, "borrower@mcl.edu.ph", "qwerty"));

            var equipmentTypes = new SerializedList<EquipmentType>(ModelValues.EQUIPMENT_TYPES_FILE_NAME, EquipmentType.GetSerializer());
            equipmentTypes.Add(new EquipmentType(0, "Chair", 1));
            equipmentTypes.Add(new EquipmentType(1, "Table", 1));
            equipmentTypes.Add(new EquipmentType(2, "Arnis", 2));
            equipmentTypes.Add(new EquipmentType(3, "Volleyball", 1));
            equipmentTypes.Add(new EquipmentType(4, "Soccer Ball", 1));
            equipmentTypes.Add(new EquipmentType(5, "Basketball", 1));


            var equipmentConditions = new SerializedList<EquipmentCondition>(ModelValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            equipmentConditions.Add(new EquipmentCondition(0, "Ok"));
            equipmentConditions.Add(new EquipmentCondition(1, "Broken"));

            var equipments = new SerializedList<Equipment>(ModelValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            equipments.Add(new Equipment(0, 0, 0));
            equipments.Add(new Equipment(1, 0, 0));
            equipments.Add(new Equipment(2, 0, 0));
            equipments.Add(new Equipment(3, 0, 0));
            equipments.Add(new Equipment(4, 0, 0));
            equipments.Add(new Equipment(5, 0, 0));



            var requestStatuses = new SerializedList<RequestStatus>(ModelValues.EQUIPMENT_STATUSES_FILE_NAME, RequestStatus.GetSerializer());
            requestStatuses.Add(new RequestStatus(0, "Pending"));
            requestStatuses.Add(new RequestStatus(1, "Denied"));
            requestStatuses.Add(new RequestStatus(2, "Active"));
            requestStatuses.Add(new RequestStatus(3, "Complete"));

            var violations = new SerializedList<Violation>(ModelValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
            violations.Add(new Violation(0, "Overdue"));
            violations.Add(new Violation(1, "Broken"));

            var equipmentRequets = new SerializedList<EquipmentRequest>(ModelValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            equipmentRequets.Add(new EquipmentRequest(0, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, "Hello World 1", new[] { 1 }.ToList()));
            equipmentRequets.Add(new EquipmentRequest(1, 1, 1, DateTime.Now, DateTime.Now, DateTime.Now, "Hello World 2", new[] { 2 }.ToList()));
            equipmentRequets.Add(new EquipmentRequest(2, 1, 3, DateTime.Now, DateTime.Now, DateTime.Now, "Hello World 3", new[] { 3 }.ToList()));
            equipmentRequets.Add(new EquipmentRequest(3, 1, 2, DateTime.Now, DateTime.Now.AddMinutes(5), DateTime.Now, "Hello World 4", new[] { 4, 5 }.ToList()));


            var borrowerViolations = new SerializedList<BorrowerViolation>(ModelValues.BORROWER_VIOLATIONS_FILE_NAME, BorrowerViolation.GetSerializer());
            borrowerViolations.Add(new BorrowerViolation(0, 0, 0, 0, false));
            borrowerViolations.Add(new BorrowerViolation(1, 1, 0, 0, false));
            borrowerViolations.Add(new BorrowerViolation(2, 2, 1, 0, true));
            borrowerViolations.Add(new BorrowerViolation(3, 3, 1, 0, false));



        }
    }
}
