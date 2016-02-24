using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xmazon
{
	public partial class Products : ContentPage
	{
		private ArrayList productsList = new ArrayList();
		private Category category;
		private String token;

		public Products (Category category, String token)
		{
			
			var listView = new ListView();
			listView.ItemsSource = new string[]{
				"mono",
				"monodroid",
				"monotouch",
				"monorail",
				"monodevelop",
				"monotone",
				"monopoly",
				"monomodal",
				"mononucleosis"
			};

			InitializeComponent ();
			this.category = category;
			initializeProductsList ();
		}
	

		private async void initializeProductsList(){

			string url = XmazonRequest.PRODUCT_LIST;
			var method = XmazonRequest.Method.GET;

			var requestObject = new XmazonRequest ();

			var headers = new Dictionary<string, string> ();
			headers.Add ("Authorization", "Bearer " + token);

			var getParams = new Dictionary<string, string> ();
			getParams.Add ("category_uid", category.uid);

			var result = await requestObject.Call (url, method, getParams, null, headers);

			if (result.ContainsKey ("result")) {
				var jsonProductsList = result ["result"];
				foreach (JsonValue product in jsonProductsList){
					Product currentProduct = Product.Deserialize(product);
					productsList.Add(currentProduct);
				}
				productList.ItemsSource = productsList;
				productList.ItemTemplate = new DataTemplate(typeof(TextCell));

			}
		}
			
	}
}

