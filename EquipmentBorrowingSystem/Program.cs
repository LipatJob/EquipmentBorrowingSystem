﻿using EquipmentBorrowingSystem.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using JobLib;

namespace EquipmentBorrowingSystem
{
    /* PROJECT HELP AND GUIDELINES
     * - The project framework is done. The GUI and validation are the ones that must be completed
     * - Check template folders for template code. 
     * - You may check any code made by Job for reference
     * 
     * PROJECT STRUCTURE
     * - Backend     - Contains the Everything Related to Data and Storage
     *         Logic  - Queries the Data Classes
     *         Models - Data Classes with instructions how it should be stored 
     *         ** Most of this is done **
     *         
     * - Views       - the GUI of the Application
     *        Components - Any inherited controls/Custom controls
     *        Staff      - GUIs for Staff functionalities
     *        Borrower   - GUIs for Borrower functionalities
     *         
     * - Controllers - Calls the GUI witht he  
     * 
     * 
     * 
     * USING GIT
     * - Visual Studio's Git functions is found in the team explorer.
     * - Press Sync Frequently
     * - If you want to share your changes
     *      1. Make sure you are synced
     *      2. Press "Changes"
     *      3. Enter Message
     *      4. Press Commit All
     *      5. Go back to the main menu
     *      6. Got to Sync
     *      7. Press "Push"
     * - Do not panic if there are merge conflicts. Message the group if you encounter these.
     */
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //========================================
            bool flag = true;
            bool reset = false;
            //========================================

            if (flag)
            {
                DataInitialization scaffold = new DataInitialization();
                scaffold.Run(reset);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string initialize = flag ? "Yes" : "No";
            string res = reset ? "Yes" : "No";
            if (DialogResult.Yes != MessageBox.Show($"Start application as borrower?\nDEBUG:\nScaffold - {initialize}\nReset - {res}", "Starting Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Director.GetInstance().ShowDisplay(Director.GetInstance().StaffAccountController.Login());
            }
            else
            {
                Director.GetInstance().ShowDisplay(Director.GetInstance().BorrowerAccountController.Login());
            }
        }
    }
}
