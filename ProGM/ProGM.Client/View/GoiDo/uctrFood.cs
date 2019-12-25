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
using  ProGM.Client.View.Custom;

namespace  ProGM.Client.View.GoiDo
{
    public partial class uctrFood : UserControl, FoodItemCallback, CartItemCallback, CategoryItemCallback
    {
        private List<Food> foods;
        private List<Food> foodsInCart = new List<Food>();
        private List<String> categorys;
        List<Food> fillterList = new List<Food>();


        public uctrFood()
        {
            InitializeComponent();
            ////
            fakeData();
            ////

            fillterList.AddRange(foods);
            for(int i=0; i < foods.Count; i++)
            {
                uctrItem item = new uctrItem(foods[i]);
                item.Visible = true;
                item.Show();
                item.SetCallback(this);
                flpFoods.Controls.Add(item);
                
            }
            flpFoods.Invalidate();
            ////
            foreach(String item in categorys)
            {
                ButtonCustom button = new ButtonCustom();
                button.Text = item;
                button.CategoryItemCallback = this;
                button.AutoSize = false;
                button.Size = new Size(240, 35);
                button.Margin = new Padding(0, 0, 0, 5);
                button.Padding = new Padding(20, 0, 0, 0);
                flpCategorys.Controls.Add(button);
                button.ForeColor = Color.White;
                button.Font = new Font(button.Font.FontFamily, 12);
            }
            flpCategorys.Invalidate();
        

        }

        private void fakeData()
        {
            categorys = new List<string>();
            categorys.Add("Đồ uống đóng chai");
            categorys.Add("Thuốc lá");
            categorys.Add("Đồ ăn");
            categorys.Add("Đồ uống pha chế");
            ////
            foods = new List<Food>();
            Random random = new Random();
            for (int i=0; i<10; i++)
            {
                String ca = categorys[random.Next(4)];
                int pri = random.Next(10000, 50000);
                bool isHot = random.Next(2) == 0;
                Food food = new Food(i.ToString(), ca+i, Image.FromFile("../../Resources/QR-code.png"), pri, ca, isHot);
                foods.Add(food);
            }
            ///
            
           
        }

        public void buyNow(Food food)
        {
            //TODO
            MessageBox.Show("Đã mua hàng", food.Name);
        }

        public void addToCart(Food food)
        {
            foodsInCart.Add(food);
            loadCartView();
            int totalAmount = 0;
            foreach (Food item in foodsInCart)
            {
                totalAmount += item.Price;
            }
            lbTotalAmount.Text = addDotToAmount(totalAmount);

        }

        public void deleteItem(int index, Food food)
        {
            foodsInCart.Remove(food);
            loadCartView();
            int totalAmount = 0;
            foreach (Food item in foodsInCart)
            {
                totalAmount += item.Price;
            }
            lbTotalAmount.Text = addDotToAmount(totalAmount);
        }

        private void loadCartView()
        {
            flpCart.Controls.Clear();
            foreach(Food item in foodsInCart)
            {
                uctrCartItem cartItem = new uctrCartItem(item);
                cartItem.Visible = true;
                cartItem.Show();
                cartItem.setCallback(this);
                flpCart.Controls.Add(cartItem);
            }
            flpCart.Invalidate();
        }
        private String addDotToAmount(int value)
        {
            String sValue = value.ToString();
            if (sValue.Length > 3)
            {
                sValue = sValue.Insert(sValue.Length - 3, ".");
            }
            return sValue;
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            foodsInCart.Clear();
            loadCartView();
            lbTotalAmount.Text = "";
        }

        public void onCategoryItem_Click(string category)
        {
            fillterList.Clear();
            foreach(Food item in foods)
            {
                if (item.Category.Equals(category))
                    fillterList.Add(item);
            }
            loadFoodsView(fillterList);
        }

        private void buttonCustom2_Click(object sender, EventArgs e)
        {
            loadFoodsView(foods);
            fillterList.Clear();
            fillterList.AddRange(foods);
        }

        private void loadFoodsView(List<Food> listFood)
        {
            flpFoods.Controls.Clear();
            for (int i = 0; i < listFood.Count; i++)
            {
                uctrItem item = new uctrItem(listFood[i]);
                item.Visible = true;
                item.Show();
                item.SetCallback(this);
                flpFoods.Controls.Add(item);
            }
            flpFoods.Invalidate();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
             
            List<Food> softList = fillterList.OrderBy(o => o.Price).ToList();
            loadFoodsView(softList);


        }

        private void btnSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            List<Food> searchList = new List<Food>();
            foreach (Food item in fillterList)
            {
                if (item.Name.Contains(btnSearch.Text))
                    searchList.Add(item);
            }
            fillterList.Clear();
            fillterList.AddRange(searchList);
            loadFoodsView(fillterList);
        }

        private void btnHotFood_Click(object sender, EventArgs e)
        {
            List<Food> hotList = new List<Food>();
            foreach (Food item in fillterList)
            {
                if (item.IsHot)
                    hotList.Add(item);
            }
            fillterList.Clear();
            fillterList.AddRange(hotList);
            loadFoodsView(fillterList);
        }

        private void btnBuyCart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trong giỏ có "+foodsInCart.Count,"Đã mua hàng");
        }
    }
}
