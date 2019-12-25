using  ProGM.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGM.Client.View.GoiDo
{
    public interface CartItemCallback
    {
        void deleteItem(int index, Food food);
    }
}
