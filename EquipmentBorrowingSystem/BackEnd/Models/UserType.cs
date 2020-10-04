using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    class UserType : Keyed<int>
    {
        public UserType() { }
        public UserType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }


        // Reference Models
        public IEnumerable<User> Users
            { get { return ApplicationState.GetInstance().Users.Values.Where(e => e.UserTypeId == Id); } }


        public int GetKey()
        {
            return Id;
        }

        public static Serializer<UserType> GetSerializer()
        {
            return new UserTypeSerializer();
        }

        private class UserTypeSerializer : Serializer<UserType>
        {
            public override UserType Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new UserType(
                    int.Parse(values[0]),
                    values[1]);
            }

            public override string ToSerializable(UserType item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.Name
                });
            }
        }
    }
}
