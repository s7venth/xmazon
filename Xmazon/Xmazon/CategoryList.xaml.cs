using System;
using System.Collections.Generic;
using System.Json;
using Xamarin.Forms;
using System.Collections;

namespace Xmazon
{
	public partial class CategoryList : ContentPage
	{
		private ArrayList categoriesList = new ArrayList();
		private Store store;

		public CategoryList (Store store)
		{
			InitializeComponent ();
			this.store = store;
			getCategoryListFromWebService ();
		}

		private async void getCategoryListFromWebService(){

			Dictionary<string, string> headers = new Dictionary<string, string> ();
			headers.Add("Authorization", "Bearer " + App.token);
			Dictionary<string, string> parameter = new Dictionary<string, string> ();
			parameter.Add("store_uid", store.uid);

			WebService webService = new WebService();
			JsonValue result = await webService.Call (WebService.CATEGORY_LIST_URL, 
															 WebService.Method.GET, 
														     parameter, 
									                         null, 
															 headers);

			if (result.ContainsKey("result")) {
				JsonValue jsonCategoriesList = result["result"];
				foreach (JsonValue category in jsonCategoriesList){categoriesList.Add(Category.Deserialize(category));}
				list.ItemsSource = categoriesList;
				list.ItemTemplate = new DataTemplate(typeof(TextCell));
				list.ItemTemplate.SetBinding(TextCell.TextProperty, "name");
				list.ItemSelected += async (sender, e) => {
					Category selectedCategory = (Category)e.SelectedItem;
					Navigation.InsertPageBefore (new ProductList(selectedCategory), this);
					await Navigation.PopAsync ();
				};
			}
		}
	}
}