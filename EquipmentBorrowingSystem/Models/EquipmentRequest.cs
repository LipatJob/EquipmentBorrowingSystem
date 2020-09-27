using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Models
{
    class EquipmentRequest
    {
        int Id { get; set; }
        int BorrowerID { get; set; }
        int EquipmentID { get; set; }
        DateTime ExpectedReturnDate { get; set; }
        DateTime DateBorrowed { get; set; }
        DateTime DateReturned { get; set; }
        string Reason { get; set; }
    }
}
