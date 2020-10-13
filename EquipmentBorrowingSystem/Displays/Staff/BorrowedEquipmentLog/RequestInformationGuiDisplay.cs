using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    partial class RequestInformationGuiDisplay
    {
        private TextBox NameTextBox;
        private TextBox ReturnDateTextBox;
        private TextBox BorrowedDateTextBox;
        private TextBox ReasonTextBox;
        private Label NameLabel;
        private Label ReturnDateLabel;
        private Label BorrowedDateLabel;
        private Label ReasonLabel;

        public void BindModelToView()
        {
            NameTextBox.Text = Model.Borrower.ToString();
            ReturnDateTextBox.Text = Model.ExpectedReturnDate.ToString();
            BorrowedDateTextBox.Text = Model.DateBorrowed.ToString();
            ReasonTextBox.Text = Model.Reason.ToString();
            NameLabel.Text = "Name";
            ReturnDateLabel.Text = "Expected Return Date";
            BorrowedDateLabel.Text = "Date Borrowed";
            ReasonLabel.Text = "Reason";
        }
        partial void InitializeComponent()
        {
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ReturnDateTextBox = new System.Windows.Forms.TextBox();
            this.BorrowedDateTextBox = new System.Windows.Forms.TextBox();
            this.ReasonTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ReturnDateLabel = new System.Windows.Forms.Label();
            this.BorrowedDateLabel = new System.Windows.Forms.Label();
            this.ReasonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Enabled = false;
            this.NameTextBox.Location = new System.Drawing.Point(162, 42);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(179, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // ReturnDateTextBox
            // 
            this.ReturnDateTextBox.Enabled = false;
            this.ReturnDateTextBox.Location = new System.Drawing.Point(162, 81);
            this.ReturnDateTextBox.Name = "ReturnDateTextBox";
            this.ReturnDateTextBox.Size = new System.Drawing.Size(179, 20);
            this.ReturnDateTextBox.TabIndex = 0;
            // 
            // BorrowedDateTextBox
            // 
            this.BorrowedDateTextBox.Enabled = false;
            this.BorrowedDateTextBox.Location = new System.Drawing.Point(162, 121);
            this.BorrowedDateTextBox.Name = "BorrowedDateTextBox";
            this.BorrowedDateTextBox.Size = new System.Drawing.Size(179, 20);
            this.BorrowedDateTextBox.TabIndex = 0;
            // 
            // ReasonTextBox
            // 
            this.ReasonTextBox.Enabled = false;
            this.ReasonTextBox.Location = new System.Drawing.Point(162, 166);
            this.ReasonTextBox.Multiline = true;
            this.ReasonTextBox.Name = "ReasonTextBox";
            this.ReasonTextBox.Size = new System.Drawing.Size(179, 82);
            this.ReasonTextBox.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(43, 45);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.Text = "Name";
            // 
            // ReturnDateLabel
            // 
            this.ReturnDateLabel.AutoSize = true;
            this.ReturnDateLabel.Location = new System.Drawing.Point(43, 84);
            this.ReturnDateLabel.Name = "ReturnDateLabel";
            this.ReturnDateLabel.Size = new System.Drawing.Size(113, 13);
            this.ReturnDateLabel.Text = "Expected Return Date";
            // 
            // BorrowedDateLabel
            // 
            this.BorrowedDateLabel.AutoSize = true;
            this.BorrowedDateLabel.Location = new System.Drawing.Point(43, 124);
            this.BorrowedDateLabel.Name = "BorrowedDateLabel";
            this.BorrowedDateLabel.Size = new System.Drawing.Size(78, 13);
            this.BorrowedDateLabel.Text = "Date Borrowed";
            // 
            // ReasonLabel
            // 
            this.ReasonLabel.AutoSize = true;
            this.ReasonLabel.Location = new System.Drawing.Point(43, 166);
            this.ReasonLabel.Name = "ReasonLabel";
            this.ReasonLabel.Size = new System.Drawing.Size(44, 13);
            this.ReasonLabel.Text = "Reason";
            // 
            // RequestInformationGuiDisplay
            // 
            this.ClientSize = new System.Drawing.Size(401, 296);
            this.Controls.Add(this.ReasonLabel);
            this.Controls.Add(this.BorrowedDateLabel);
            this.Controls.Add(this.ReturnDateLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ReturnDateTextBox);
            this.Controls.Add(this.BorrowedDateTextBox);
            this.Controls.Add(this.ReasonTextBox);
            this.Name = "RequestInformationGuiDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //NOTE: Still need to edit this part. I can't seem to get the Close Window Event work.
        void WindowClosed(object sender, CancelEventArgs e)
        {
            Director.ShowDisplay(Director.BorrowedEquipmentLogController.RequestsMenu());
        }
    }
    partial class RequestInformationGuiDisplay : GuiDisplay<EquipmentRequest>
    {
        public RequestInformationGuiDisplay(EquipmentRequest model)
            : base(model)
        {
            InitializeComponent();
            BindModelToView();
        }
        public RequestInformationGuiDisplay()
        {

        }
        partial void InitializeComponent();
    }
}
