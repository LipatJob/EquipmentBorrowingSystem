using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository.ViewModels
{
    class EquipmentViewModel
    {
        public int Id;
        public string name;
        public string equipmentType;
        public string condition;

        public IEnumerable<string> equipmentTypes;
        public IEnumerable<string> conditions;
    }
}
