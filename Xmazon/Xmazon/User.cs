using System;
using System.Collections.Generic;
using System.Json;

namespace Xmazon
{
	public class User
	{
		private string email;
		private string password;
		private string firstname;
		private string lastname;

		public User ()
		{
			
		}

		public User(string email , string pass, string firstname, string lastname ){
			this.email = email;
			this.password = pass;
			this.firstname = pass;
			this.lastname = lastname;
		}

		public async void Rigister(){
			
			Dictionary<string, string> body = new Dictionary<string, string> ();
			body.Add ("email", this.email);
			body.Add ("password", this.password);
			body.Add ("firstname", this.firstname);
			body.Add ("lastname", this.lastname);


			Dictionary<string, string> headers = new Dictionary<string, string> ();
			body.Add ("Authorization", "Bearer "+App.token);


			WebService webservice = new WebService();

			JsonValue json = await webservice.Call (WebService.OAUTH_TOKEN, WebService.Method.POST, null, body, headers);
			var result = JsonValue.Parse (json.ToString ());

			Console.WriteLine ("\n \n \n \n========WEBSERVICE======= ");
			//Console.WriteLine ("user is created : {0}",result["uid"]);


		}
			

	}
}

