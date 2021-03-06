﻿using EquipmentBorrowingSystem.JobLib;
using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Models
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class Equipment : Model, Keyed<int>
    {
        public Equipment() { }
        public Equipment(int id, int equipmentTypeID, int conditionID)
        {
            Id = id;
            EquipmentTypeID = equipmentTypeID;
            ConditionID = conditionID;
        }

        public int Id { get; set; }
        public int EquipmentTypeID { get; set; }
        public int ConditionID { get; set; }
        public string Code { get { return EquipmentType.Name + "-" + Id;  } }


        // Foreign Models
        public EquipmentType EquipmentType { get { return ApplicationState.GetInstance().EquipmentTypes[EquipmentTypeID]; } }
        public EquipmentCondition EquipmentCondition { get { return ApplicationState.GetInstance().EquipmentConditions[ConditionID]; } }

        // Reference Models
        public IEnumerable<EquipmentRequest> EquipmentRequests
            { get { return ApplicationState.GetInstance().EquipmentRequests.Values.Where(e => e.EquipmentIds.Contains(Id)); } }

        public int GetKey()
        {
            return Id;
        }

        public static Serializer<Equipment> GetSerializer()
        {
            return new EquipmentSerializer();
        }
        private class EquipmentSerializer : Serializer<Equipment>
        {
            public override Equipment Deserialize(string serializedItem)
            {
                string[] values = serializedItem.Split(ModelValues.DELIMITERC);
                return new Equipment(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2])
                    );
            }

            public override string ToSerializable(Equipment item)
            {
                return string.Join(ModelValues.DELIMITER, new string[] {
                    item.Id.ToString(), 
                    item.EquipmentTypeID.ToString(), 
                    item.ConditionID.ToString(), 
                });
            }
        }
    }
}
