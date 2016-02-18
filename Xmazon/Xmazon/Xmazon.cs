using System;

using Xamarin.Forms;
using System.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;

namespace Xmazon
{
	public class App : Application
	{
		/* solution 1
		private async Task<JsonValue> FetchWeatherAsync (string url)
		{
			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					Console.Out.WriteLine("Response: {0}", jsonDoc.ToString ());

					// Return the JSON document:
					return jsonDoc;
				}
			}
		}
		*/

        //solution 2

		private void fetchNewton(String url){
			HttpClient client = new HttpClient();

			//Add DefaultRequestHeader to Json
			client.DefaultRequestHeaders.Accept.Add(new  
				MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = 
				client.GetAsync(url).Result;
			
			//Http Status code 200
			if (response.IsSuccessStatusCode)
			{
				//Read response content result into string variable
				string strJson = response.Content.ReadAsStringAsync().Result;
				//Deserialize the string to JSON object
				dynamic jObj = (JObject)JsonConvert.DeserializeObject(strJson);

                    
				var time = jObj ["result"]["time"];
				var date = jObj["result"]["date"];
				Console.WriteLine ("time is : {0}", time);
				Console.WriteLine ("date is : {0}", date);
	
			}

		}






		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new Login());

		}

		protected override void OnStart ()
		{

			//FetchWeatherAsync ("http://appspaces.fr/esgi/jsontest.php");
		    fetchNewton ("http://appspaces.fr/esgi/jsontest.php");
			// Handle when your app starts
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

