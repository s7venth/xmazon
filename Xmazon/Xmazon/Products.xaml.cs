using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xmazon
{
	public partial class Products : ContentPage
	{
		public Products ()
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

			//monochrome will not appear in the list because it was added
			//after the list was populated.
			//listView.ItemsSource.Add("monochrome");
			InitializeComponent ();
		}
	}
}

