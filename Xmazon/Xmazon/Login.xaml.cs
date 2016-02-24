using System;
using System.Collections.Generic;
using System.Json;

using Xamarin.Forms;

namespace Xmazon
{
	public partial class Login : ContentPage
	{
		
		public Login ()
		{
			InitializeComponent ();
		
		}

		public async void logIn(string username, string password){

			Dictionary<string, string> body = new Dictionary<string, string> ();
			body.Add ("grant_type", "password");
			body.Add ("client_id", "e99d11d1-6504-4abf-8aa0-886e4affe6a0");
			body.Add ("client_secret", "d650639e9fe3110f4024149f0d98e04cbde0305d");
			body.Add ("username", username);
			body.Add ("password", password);


			WebService webservice = new WebService();

			JsonValue json = await webservice.Call (WebService.OAUTH_TOKEN, WebService.Method.POST, null, body, null);
			if (json != null) {
				var result = JsonValue.Parse (json.ToString ());

				Console.WriteLine ("\n \n \n \n========WEBSERVICE======= ");

				if (result.ContainsKey ("code") && result ["code"].Equals ("400")) {
				
				} else {
					if ((string)result ["access_token"] != null) {
				
						Console.WriteLine ("user is loged in: {0}", result ["access_token"]);
						await Navigation.PushAsync (new Products ());

					}
				}

			}
		}

		 void OnLoginClicked (object sender, EventArgs e)
		{
			string username, password;
			username = loginEntry.Text;
			password = passwordEntry.Text;

			if (!username.Equals("") && !password.Equals("")) {
				/*Console.WriteLine ("user infos : \n nom = {0} \n prenom = {1} \n email = {2} \n password = {3} \n password conf = {4} \n",
				 /*nom, prenom,email,password,passwordConf);*/
				logIn (username,password);

			}
				
		}

		async void OnInscriptionClicked (object sender, EventArgs e)
		{
			

			await Navigation.PushAsync (new Register());


		}

	}
}

