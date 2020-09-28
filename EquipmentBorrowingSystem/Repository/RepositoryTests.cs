using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    /// <summary>
    /// Author: Job Lipat
    /// Date: September 27, 2020
    /// </summary>
    class RepositoryTests
    {
        static void StartTest()
        {
            
            string tempMessage = "";
            Debug.Assert(User.ValidatePassword("AB13!#", out tempMessage), "Valid password invalidated");
            Debug.Assert(!User.ValidatePassword("ABCDE!@#", out tempMessage), "Test Case without number must be false");
            Debug.Assert(!User.ValidatePassword("ABCDE123", out tempMessage), "Test Case without special characters must be false");
            Debug.Assert(!User.ValidatePassword("A1@", out tempMessage), "Test Case that's less than 6 characters must be false");
            Debug.Assert(!User.ValidatePassword("ABCDEFGHIJKLMNO#1", out tempMessage), "Test Case that's more than 17 characters must be false");

        }
    }
}
