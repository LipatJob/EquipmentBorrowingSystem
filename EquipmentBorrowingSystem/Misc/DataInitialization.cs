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
            equipmentTypes.Add(new EquipmentType(0, "Chair", 100));

            var equipmentConditions = new SerializedList<EquipmentCondition>(ModelValues.EQUIPMENT_CONDITIONS_FILE_NAME, EquipmentCondition.GetSerializer());
            equipmentConditions.Add(new EquipmentCondition(0, "Ok"));
            equipmentConditions.Add(new EquipmentCondition(1, "Broken"));

            var equipments = new SerializedList<Equipment>(ModelValues.EQUIPMENTS_FILE_NAME, Equipment.GetSerializer());
            equipments.Add(new Equipment(0, 0, 0, "Chair 1"));
            equipments.Add(new Equipment(1, 0, 0, "Chair 2"));

            var equipmentRequets = new SerializedList<EquipmentRequest>(ModelValues.EQUIPMENT_REQUESTS_FILE_NAME, EquipmentRequest.GetSerializer());
            equipmentRequets.Add(new EquipmentRequest(0, 1, 0, 0,DateTime.Now, DateTime.Now, DateTime.Now, "Hello World"));


            var requestStatuses = new SerializedList<RequestStatus>(ModelValues.EQUIPMENT_STATUSES_FILE_NAME, RequestStatus.GetSerializer());
            requestStatuses.Add(new RequestStatus(0, "Pending"));
            requestStatuses.Add(new RequestStatus(1, "Denied"));
            requestStatuses.Add(new RequestStatus(2, "Active"));
            requestStatuses.Add(new RequestStatus(3, "Complete"));

            var violations = new SerializedList<Violation>(ModelValues.VIOLATIONS_FILE_NAME, Violation.GetSerializer());
            violations.Add(new Violation(0, "Overdue"));
            violations.Add(new Violation(1, "Broken"));


        }
    }
}
