using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xmazon
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

		async void OnLoginClicked (object sender, EventArgs e)
		{
			string username, password;
			username = loginEntry.Text;
			password = passwordEntry.Text;

			if (!username.Equals("") && !password.Equals("")) {
				/*
				Console.WriteLine ("user infos : \n nom = {0} \n prenom = {1} \n email = {2} \n password = {3} \n password conf = {4} \n",
					nom, prenom,email,password,passwordConf);
*/

				await Navigation.PushAsync (new Products ());
			}
				
		}

		async void OnInscriptionClicked (object sender, EventArgs e)
		{
			

			await Navigation.PushAsync (new Register());


		}

	}
}

