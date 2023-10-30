﻿namespace ShoppingModelLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double Rating { get; set; }
        public float Discount { get; set; }

        public Product()
        {
            Price = 0.0f;
            Discount = 0.5f;
            Quantity = 1;
            Rating = 0;
        }

        /// <summary>
        /// Construct the essential object properties
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="name">Name of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <param name="price"> price of the product</param>
        /// <param name="picture">Image of the product</param>
        /// <param name="description">Description of the product</param>
        /// <param name="rating">Rating of the product</param>
        /// <param name="discount">Discount on the product</param>

        public Product(int id, string name, int quantity, float price, string picture, string description, double rating, float discount)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Picture = picture;
            Description = description;
            Rating = rating;
            Discount = discount;
        }
        public override string ToString()
        {
            float netPrice = Price - (Price * Discount / 100);
            return $"Product Id : {Id}\nProduct Name : {Name}\nProduct Price : Rs. {Price}\nProduct Quantity In Hand : {Quantity}" +
                $"\nDiscount offered : {Discount}%\nRating : {Rating}\nNet Price : {netPrice}";
        }
    }
}