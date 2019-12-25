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
    public partial class uctrItem : UserControl
    {
        private Food food;
        FoodItemCallback foodItemCallback;
        public uctrItem(Food food)
        {
            InitializeComponent();
            this.food = food;
            ptImage.Image = food.Image;
            lbName.Text = food.Name;
            String price = food.Price.ToString();
            if (price.Length > 3)
            {
                price = price.Insert(price.Length - 3, ".");
            }
            lbPrice.Text = price;
            label2.Parent = ptImage;
            label2.BackColor = Color.Transparent;
            if (!food.IsHot)
            {
                label2.Visible = false;
            }
        }
        public void SetCallback(FoodItemCallback foodItemCallback)
        {
            this.foodItemCallback = foodItemCallback;
        }


        public Food Food { get => food; }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            foodItemCallback.buyNow(food);
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            foodItemCallback.addToCart(food);
        }
    }
}
