using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class User : Keyed<int>
    {
        public User() { }
        public User(int id, int userTypeId, string email, string password)
        {
            Id = id;
            UserTypeId = userTypeId;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int GetKey()
        {
            return Id;
        }

        public static Serializer<User> GetSerializer()
        {
            return new BorrowerSerializer();
        }

        private class BorrowerSerializer : Serializer<User>
        {
            public override User Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new User(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    values[2],
                    values[3]
                    );
            }

            public override string ToSerializable(User item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] { 
                    item.Id.ToString(), 
                    item.UserTypeId.ToString(),
                    item.Email, 
                    item.Password 
                });
            }
        }

        // ----- VALIDATORS -----
        public static bool ValidateEmail(string value, out string message)
        {

            message = "success";
            return false;
        }

        public static bool ValidatePassword(string value, out string message)
        {
            message = "success";

            return false;
        }

        
    }
}
