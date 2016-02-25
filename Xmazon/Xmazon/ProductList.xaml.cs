using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Json;
using System.Collections;

namespace Xmazon
{
	public partial class ProductList : ContentPage
	{
		private ArrayList productsList = new ArrayList();
		private Category category;

		public ProductList (Category category)
		{
			InitializeComponent();
			this.category = category;
			getProductList();
		}

		private async void getProductList(){

			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add ("Authorization", "Bearer " + App.token);

			Dictionary<string, string> parameter = new Dictionary<string, string> ();
			parameter.Add ("category_uid", category.uid);
			WebService webservice = new WebService ();
			JsonValue result = await webservice.Call(WebService.PRODUCT_LIST_URL, 
													   WebService.Method.GET, 
													   parameter, 
				                                       null, 
				         							   headers);
			if (result.ContainsKey("result")) {
				JsonValue productListJson = result["result"];
				foreach (JsonValue product in productListJson){productsList.Add(Product.Deserialize(product));}
				list.ItemsSource = productListJson;
				list.ItemTemplate = new DataTemplate(typeof(TextCell));
			}
		}

	}
}

