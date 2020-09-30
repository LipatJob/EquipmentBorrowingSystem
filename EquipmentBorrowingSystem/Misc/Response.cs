using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.BackEnd.Logic
{
    class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
