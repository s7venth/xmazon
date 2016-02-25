using System;
using System.Json;

namespace Xmazon
{
	public class Category
	{
		public string uid {get;set;}
		public string name {get;set;}

		public Category(){}

		public Category(string uid, string name)
		{
			this.uid = uid;
			this.name = name;
		}

		public static Category Deserialize(JsonValue value)
		{
			Category category = new Category(value ["uid"], 
											 value ["name"]);
			return category;
		}
	}
}
