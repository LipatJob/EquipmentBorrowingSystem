using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Models
{
    class Equipment
    {
        int Id { get; set; }
        int EquipmentTypeID { get; set; }
        int ConditionID { get; set; }
        string Name { get; set; }
    }
}
