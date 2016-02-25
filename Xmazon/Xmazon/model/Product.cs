using System;
using System.Json;

namespace Xmazon
{
	public class Product
	{
		public string uid {get;set;}
		public string name {get;set;}
		public float price {get;set;}
		public bool available {get;set;}

		public Product(){}

		public Product(string uid, string name, float price, bool available)
		{
			this.uid = uid;
			this.name = name;
			this.price = price;
			this.available = available;
		}

		public static Product Deserialize(JsonValue value)
		{
			Product product = new Product(value ["uid"],
										  value ["name"],
								(float) value["price"],
								   (bool) value["available"]);
			return product;

		}
	}
}