using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Views;
using EquipmentBorrowingSystem.Views.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{
    //    Change Class Name
    //    VVVVVVVVVVVVVVV
    class EmptyController : Controller
    {
        //     Change Class Name
        //     VVVVVVVVVVVVVVV
        public EmptyController(Director director) : base(director)
        {
            // Each controller must be registered in the director
            // To Register controller:
            // 1. Add controller member in director. eg. public <Name>Controller <Identifier>Controller { get; };
            // 2. Instantiate controller member in contructor. eg. <identifier> = new <Name>Controller(this);
            // See Director.cs for example
        }

        public Display SampleDisplayFunction()
        {
            // This method is used to change the display
            // Return the Display that you want to go to next

            //                                   Replace with model
            //                                   VVVVVVVVVVVV
            return new EmptyGuiDisplay(Director, new Object());
        }

        //                                  Replace with model class
        //                                  VVVVVV
        public Response SampleActionFunction(Object obj)
        {
            // This Method does an action
            // For example, it may insert the object to the database


            //                  is action Successful
            //                  VVVV
            return new Response(true, "Your Message Here");
        }


    }
}
