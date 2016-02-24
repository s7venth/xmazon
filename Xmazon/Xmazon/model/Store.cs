using System;

using Xamarin.Forms;

namespace Xmazon
{
	public class Store : ContentPage
	{
		public Store ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


