using  ProGM.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGM.Client.View.GoiDo
{
    public interface FoodItemCallback
    {
        void buyNow(Food food);
        void addToCart(Food food);
    }
}
