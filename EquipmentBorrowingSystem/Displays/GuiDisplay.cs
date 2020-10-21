using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays
{
    class GuiDisplay<BaseModel> : Form, Display
    {
        protected Director Director;
        protected BaseModel Model;

        public GuiDisplay()
        {

        }

        public Panel itemPanel;

        public GuiDisplay(BaseModel model)
        {
            BackColor = Color.White;
            this.Director = Director.GetInstance();
            Model = model;

            Height = 400;
            Width = 600;

            int tempWidth = Width;
            var titlePl = new Panel()
            {
                Dock = DockStyle.Top,
                Width = tempWidth,
                Height = 80,
                BackColor = Color.FromArgb(0, 33, 78),
            };

            var mclLb = new Label()
            {
                Text = "MCL Equipment Borrowing System",
                Font = new Font(FontFamily.GenericSansSerif, 18),
                Dock = DockStyle.Bottom,
                ForeColor = Color.White,
                Size = new Size(400, 40)
            };

            titlePl.Controls.Add(mclLb);
            itemPanel = new Panel() { Dock = DockStyle.Fill };
            var layout = new TableLayoutPanel() { Dock = DockStyle.Fill };
            layout.Location = new Point(0, 0);
            layout.RowCount = 2;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(titlePl, 0, 0);
            layout.Controls.Add(itemPanel, 0, 1);
            Controls.Add(layout);
        }
        
        public void ShowDisplay()
        {
            Director.ShowGuiView(this);
        }

        public virtual void BindModelToView() { }

        public virtual void BindViewToModel() { }


    }
}
