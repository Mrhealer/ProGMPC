using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGM.Client.Model
{
    public class Food
    {
        private String id;
        private String name;
        private Image image;
        private int price;
        private String category;
        private bool isHot;

        public Food()
        {
        }

        public Food(string name, Image image, int price)
        {
            this.name = name;
            this.image = image;
            this.price = price;
        }

        public Food(string name, Image image, int price, bool isHot)
        {
            this.name = name;
            this.image = image;
            this.price = price;
            this.isHot = isHot;
        }

        public Food(string id, string name, Image image, int price, bool isHot)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.price = price;
            this.isHot = isHot;
        }

        public Food(string id, string name, Image image, int price, string category, bool isHot)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.price = price;
            this.category = category;
            this.isHot = isHot;
        }

        public string Name { get => name; set => name = value; }
        public Image Image { get => image; set => image = value; }
        public int Price { get => price; set => price = value; }
        public bool IsHot { get => isHot; set => isHot = value; }
        public string Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
    }
}
