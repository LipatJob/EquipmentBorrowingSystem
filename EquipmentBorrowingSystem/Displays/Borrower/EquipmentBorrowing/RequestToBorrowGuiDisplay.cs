using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Borrower.EquipmentBorrowing
{

    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class BorrowRequestGuiDisplay
    {

        public override void BindModelToView()
        {
        }

        //pwede ko ba resize yung objects ko sa design na lang?
        //would it change something sa code?
        //for example, naglagay na ako ng objects sa InitializeComponent(), tapos iniba ko yung size sa design
        //AH okay gegege

        public override void BindViewToModel()
        {
            Model.ExpectedReturnDate = expectedReturnDateDTP.Value.Date + expectedReturnTimeDTP.Value.TimeOfDay;
            Model.Reason = reasonRtb.Text;

            
        }


        ICollection<DomainUpDown> TypeUDs;
        ICollection<Label> TypLbs;

        DateTimePicker expectedReturnDateDTP;
        DateTimePicker expectedReturnTimeDTP;
        RichTextBox reasonRtb;

        Button submitButton;
        partial void InitializeComponent()
        {
            TypeUDs = new List<DomainUpDown>();
            TypLbs = new List<Label>();
            LocationHandler handler = new LocationHandler(0, 0, 100, 35);

            var titleLb = new Label() { Text = "Borrow Equipment", Location = handler.GetPosition(), AutoSize = true, Font = new Font(FontFamily.GenericSansSerif, 12)};
            handler.X = 20;

            var expectedReturnDateLb = new Label() { Text = "Return Date", Location = handler.Down().GetPosition() };
            expectedReturnDateDTP = new DateTimePicker() { Location = handler.Right().GetPosition(), Format = DateTimePickerFormat.Custom , CustomFormat = "MM/dd/yyyy", Width = 100};
            expectedReturnTimeDTP = new DateTimePicker() { Location = handler.Right().AddX(30).GetPosition(), Format = DateTimePickerFormat.Time, ShowUpDown = true, Width = 100};
            handler.Left().Left().AddX(-30);

            // Equipment Type
            var typesLabel = new Label() { Text = "Quantity", Location = handler.Down().GetPosition() };
            var typesPanel = new Panel() { AutoSize = true, Location = new Point(50, handler.Y)};
            int i = 0;
            var types = ApplicationState.GetInstance().EquipmentTypes.Values;
            LocationHandler typesHandler = new LocationHandler(0, 0, 100, 25);
            foreach (var type in types)
            {
                if (i == Math.Ceiling((double)types.Count / 2))
                {
                    typesHandler.X = 50;
                    typesHandler.Y = 0;
                    typesHandler.Right().Right();
                }
                string days = type.MaximumBorrowDurationDays > 1  ? "days" : "day";
                var typeName = new Label() { Text = $"{type.Name} ({type.MaximumBorrowDurationDays} {days})", Location = typesHandler.Down().GetPosition() };
                var typeUpDown = CreateUpDown(type);
                typeUpDown.Location = typesHandler.Right().GetPosition();
                var typeCountLb = new Label { Text = $"({typeUpDown.Items.Count - 1})", Location = new Point(typesHandler.X + 50, typesHandler.Y), Width = 40};
                typesHandler.Left();
                TypeUDs.Add(typeUpDown);
                TypLbs.Add(typeName);
                typesPanel.Controls.Add(typeCountLb);

                i++;
            }
            typesPanel.Controls.AddRange(TypeUDs.ToArray());
            typesPanel.Controls.AddRange(TypLbs.ToArray());

            handler.Y += (types.Count * typesHandler.AmountY) / 2;
            var reasonLabel = new Label() { Text = "Reason", Location = handler.Down().GetPosition() };
            handler.AmountY = 20;
            reasonRtb = new RichTextBox { Location = handler.Down().GetPosition(), Size = new Size(500,100)};

            handler.Y += reasonRtb.Height;
            submitButton = new Button() { Text = "Submit", Location = handler.Down().GetPosition()};
            submitButton.Click += SubmitAction;

            itemPanel.Controls.AddRange(new Control[] { titleLb, typesLabel, expectedReturnDateLb, expectedReturnDateDTP, expectedReturnTimeDTP, reasonRtb, reasonLabel, typesPanel, submitButton});
            
            Height = submitButton.Location.Y + 80 + titlePl.Height;

            this.AutoSizeMode = AutoSizeMode.GrowOnly; 
            this.AutoSize = true;
        }

        private void SubmitAction(object sender, EventArgs e)
        {
            if(!(ValidateQuantity() && ValidateReason() && ValidateDate())) { return; }

            if(DialogResult.Yes != MessageBox.Show("Are you sure you want to submit the request?", "Submit Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            BindViewToModel();

            var amount = new Dictionary<EquipmentType, int>();
            foreach (var item in TypeUDs)
            {
                EquipmentType type = (EquipmentType)item.Tag;
                amount[type] = int.Parse(item.SelectedItem.ToString());
            }
            var response = Director.EquipmentBorrowingController.RequestToBorrow(Model, amount);

            if(response.Success)
            {
                MessageBox.Show("Successfully made request. Please wait up to 2 business days to process your request.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentBorrowingController.BorrowingMenu());
                return;
            }
            else
            {
                MessageBox.Show("There was an error processing your reqeust. Please try again later.", "Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentBorrowingController.BorrowingMenu());
            }
        }

        private DomainUpDown CreateUpDown(EquipmentType equipmentType)
        {
            var values = new List<string>();
            int count = Director.EquipmentBorrowingController.GetEquipmentCount(equipmentType);
            for (int i = count; i >= 0; i--)    
            {
                values.Add(i.ToString());
            }
            var quantity = new DomainUpDown() { Width = 50, Tag = equipmentType, ReadOnly = true };
            quantity.Items.AddRange(values);
            quantity.SelectedItem = "0";

            ApplicationState.GetInstance().Equipments.Values.Where(e => e.EquipmentRequests.Count() < 1 || (e.EquipmentRequests.Last().RequestStatus.Name != "Active" && e.EquipmentRequests.Last().RequestStatus.Name != "Pending"));

            return quantity;
        }
    
        private bool ValidateQuantity()
        {
            foreach (var type in TypeUDs)
            {
                if(int.Parse(type.SelectedItem.ToString()) > 0)
                {
                    return true;
                }

            }

            MessageBox.Show("Please select at least one equipment", "No equipment selected");
            return false;
        }

        private bool ValidateDate()
        {
            var date = expectedReturnDateDTP.Value.Date + expectedReturnTimeDTP.Value.TimeOfDay;
            if (date.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("Return Date must be in the future", "Invalid Return Date");
                return false;
            }
            foreach (var typeUD in TypeUDs)
            {
                if (int.Parse(typeUD.SelectedItem.ToString()) > 0)
                {
                    var item = (EquipmentType)typeUD.Tag;
                    DateTime maximumDuration = DateTime.Now;
                    maximumDuration = maximumDuration.AddDays(item.MaximumBorrowDurationDays);
                    if (date.CompareTo(maximumDuration) > 0)
                    {
                        MessageBox.Show($"Return Date must not exceed {maximumDuration.ToShortDateString()} {maximumDuration.ToShortTimeString()}", "Invalid Return Date");
                        return false;
                    }

                }

            }

            return true;
        }

        private bool ValidateReason()
        {
            if (string.IsNullOrWhiteSpace(reasonRtb.Text))
            {
                MessageBox.Show("reason must not be empty", "Invalid Reason");
                return false;
            }

            return true;
        }
    }



    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class BorrowRequestGuiDisplay : GuiDisplay<EquipmentRequest>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public BorrowRequestGuiDisplay(EquipmentRequest model) // <<< Replace with model class
            : base(model)
        {
            // The GUI Stuff must be implemented in the partial class below
            // Fold this Class after initializing
            

            InitializeComponent();
        }

        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public BorrowRequestGuiDisplay()
        {
            // This Constructor allows you to use the designer. 
        }

        // put all GUI in the implementation of this method
        partial void InitializeComponent();

    }

}
