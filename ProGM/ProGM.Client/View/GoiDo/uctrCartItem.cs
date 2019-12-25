using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  ProGM.Client.Model;

namespace  ProGM.Client.View.GoiDo
{
    public partial class uctrCartItem : UserControl
    {
        private Food food;
        private CartItemCallback cartItemCallback;
        private int index;
        public uctrCartItem(Food food)
        {
            InitializeComponent();
            this.food = food;
            lbName.Text = food.Name;
        }

        public int Index { get => index; set => index = value; }

        public void setCallback(CartItemCallback cartItemCallback)
        {
            this.cartItemCallback = cartItemCallback;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cartItemCallback.deleteItem(index, food);
        }
    }
}
