using  ProGM.Client.View.GoiDo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGM.Client.View.Custom
{
    public class ButtonCustom : System.Windows.Forms.Label
    {
        private CategoryItemCallback categoryItemCallback;

        public CategoryItemCallback CategoryItemCallback { get => categoryItemCallback; set => categoryItemCallback = value; }

        public ButtonCustom()
        {
            this.BackColor = Constant.ColorBackGround;
            this.TextAlign = ContentAlignment.MiddleLeft;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Constant.ColorMouseEnter;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Constant.ColorBackGround;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Constant.ColorBorder, ButtonBorderStyle.Solid);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(categoryItemCallback != null)
                categoryItemCallback.onCategoryItem_Click(this.Text);
        }
    }
}
