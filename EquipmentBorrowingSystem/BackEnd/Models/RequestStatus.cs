﻿using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    class RequestStatus : Keyed<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GetKey()
        {
            return Id;
        }

        public RequestStatus(){ }
        public RequestStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Serializer<RequestStatus> GetSerializer()
        {
            return new RequestStatusSerializer();
        }

        private class RequestStatusSerializer : Serializer<RequestStatus>
        {
            public override RequestStatus Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new RequestStatus(
                    int.Parse(values[0]),
                    values[1]);
            }

            public override string ToSerializable(RequestStatus item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(),
                    item.Name
                });
            }
        }
    }
}
