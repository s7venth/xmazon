using System;

using Xamarin.Forms;

namespace Xmazon
{
	public class Store : ContentPage
	{

		public string uid {get;set;}
		public string name {get;set;}

		public Store (string uid, string name)
		{
			this.uid = uid;
			this.name = name;
		}

		public static Store Deserialize (JsonValue jsonStore)
		{
			Store store = new Store(jsonStore ["uid"], jsonStore ["name"]);
			return store;
		}
		
	}

}


