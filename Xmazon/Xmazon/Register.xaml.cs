using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xmazon
{
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
		}


		async void OnValidClicked (object sender, EventArgs e)
		{
			string nom, prenom, email, password,passwordConf;
			nom = nomEntry.Text;
			prenom = prenomEntry.Text;
			email = emailEntry.Text;
			password = passEntry.Text;
			passwordConf = confEntry.Text;

		
			if (!nom.Equals ("") && !prenom.Equals ("") && !email.Equals ("") && !password.Equals ("") && !passwordConf.Equals ("") && password.Equals(passwordConf)) {
				
				Console.WriteLine ("user infos : \n nom = {0} \n prenom = {1} \n email = {2} \n password = {3} \n password conf = {4} \n",
					nom, prenom,email,password,passwordConf);

				await Navigation.PushAsync (new Products ());
			}
				




		}

	}
}

