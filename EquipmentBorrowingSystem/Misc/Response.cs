using EquipmentBorrowingSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Logic
{
    class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Display Redirect { get; }
        public Response(bool success, string message, Display redirect = null)
        {
            Success = success;
            Message = message;
            Redirect = redirect;
        }
    }
}
