﻿using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using EquipmentBorrowingSystem.Displays.Borrower.EquipmentBorrowing;
using EquipmentBorrowingSystem.Displays.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{
    class EquipmentBorrowingController : Controller
    {
        private BorrowerLogic Logic;

        public EquipmentBorrowingController()
        {
            // Each controller must be registered in the director
            // To Register controller:
            // 1. Add controller member in director. eg. public <Name>Controller <Identifier>Controller { get; };
            // 2. Instantiate controller member in contructor. eg. <identifier> = new <Name>Controller(this);
            // See Director.cs for example
            Logic = new BorrowerLogic(ApplicationState.GetInstance());
        }

        //Borrowing Menu
        public Display BorrowingMenu()
        {
            return new BorrowingMenu(null);
        }

        //RequestToBorrow View
        public Display RequestToBorrow()
        {
            return new RequestToBorrow(new EquipmentRequest());
        }

        //Response of Inputs from View
        public Response RequestToBorrow(EquipmentRequest request)
        {
            return Logic.RequestToBorrowEquipment(request);
        }

        //temporary (ReturnEquipment View)
        public Display ReturnEquipment()
        {
            return new ReturnEquipment(new EquipmentRequest());
        }

        public Display SeeCurrentRequests()
        {
            return new SeeInfoAndStatus(Logic.SeeCurrentRequests());
        }
    }
}
