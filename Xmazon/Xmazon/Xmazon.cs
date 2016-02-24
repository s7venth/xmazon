using System;

using Xamarin.Forms;
using System.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Xmazon
{
	

	public class App : Application
	{

		public static string token = null;


		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new Login());

		}


		public async void getToken(){

			Dictionary<string, string> body = new Dictionary<string, string> ();
			body.Add ("grant_type", "client_credentials");
			body.Add ("client_id", "e99d11d1-6504-4abf-8aa0-886e4affe6a0");
			body.Add ("client_secret", "d650639e9fe3110f4024149f0d98e04cbde0305d");

			WebService webservice = new WebService();
			JsonValue json = await webservice.Call (WebService.OAUTH_TOKEN, WebService.Method.POST, null, body, null);


			var result = JsonValue.Parse (json.ToString ());

			Console.WriteLine ("\n \n \n \n WEBSERVICE ");
			Console.WriteLine ("token is : {0}",result["access_token"]);

			App.token = result ["access_token"];

		}


		protected override void OnStart ()
		{
			getToken ();
		}




		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

