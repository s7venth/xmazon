using System;
using System.Threading.Tasks;
using System.Json;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Xmazon
{
	public class WebService
	{
		private HttpClient httpClient;
		public enum Method {
			GET,
			POST,
			PUT,
			DELETE
		};

		// URL 
		public const string OAUTH_TOKEN_URL =  "http://xmazon.appspaces.fr/oauth/token";
		public const string AUTH_SUBSCRIBE_URL =  "http://xmazon.appspaces.fr/auth/subscribe";
		public const string STORE_LIST_URL =  "http://xmazon.appspaces.fr/store/list";
		public const string CATEGORY_LIST_URL =  "http://xmazon.appspaces.fr/category/list";
		public const string PRODUCT_LIST_URL =  "http://xmazon.appspaces.fr/product/list";

		public WebService ()
		{
			httpClient = new HttpClient ();
		}

		public async Task<System.Json.JsonValue> Call(string url, 
			Method method, 
			Dictionary<string, string> getParams, 
			Dictionary<string, string> postParams, 
			Dictionary<string, string> headers) 
		{
			string encodedUrl = GetUrlEncoded (url, getParams);

			HttpResponseMessage response = null;

			SetHeaders (headers);
							
			switch (method) {
			case Method.GET:
				response = await httpClient.GetAsync (encodedUrl);
				break;
			case Method.POST:
				response = await httpClient.PostAsync (encodedUrl, GetUrlEncodedBody (postParams));
				break;
			case Method.PUT:
				response = await httpClient.PutAsync (encodedUrl, GetUrlEncodedBody (postParams));
				break;
			case Method.DELETE:
				response = await httpClient.DeleteAsync (encodedUrl);
				break;
			}

			if (response != null && response.StatusCode == HttpStatusCode.OK) {

				return JsonObject.Load(response.Content.ReadAsStreamAsync().Result);
			}

			if (response.StatusCode >= HttpStatusCode.BadRequest) {
				Console.WriteLine (response.Content.ReadAsStringAsync ().Result);
			}

			return null;
		}

		/**
		 * Encode les paramètres GET (dans l'url)
		 */
		private string GetUrlEncoded(string url, Dictionary<string, string> getParams)
		{
			if (getParams == null) {
				return url;
			}

			// Encode chaque paramètre au format "&key=value"
			string getParamsEncoded = string.Join(
				"&", 
				getParams.Select(param => { 
					return (param.Value != null) ? param.Key + "=" + Uri.EscapeDataString(param.Value) : "";
				})
			);

			return url + (string.IsNullOrEmpty(getParamsEncoded) ? "" : "?" + getParamsEncoded);
		}

		/**
		 * Retourne le corps (body) encodé de la requête à partir des paramètres POST
		 */
		private FormUrlEncodedContent GetUrlEncodedBody(Dictionary<string, string> postParams) 
		{
			if (postParams == null) {
				return null;
			}

			return new FormUrlEncodedContent (postParams);
		}

		/**
		 * Rempli les headers de la requête avec le dictionnaire donné.
		 */
		private void SetHeaders(Dictionary<string, string> headers)
		{
			if (headers == null) {
				return;
			}

			foreach (string headerKey in headers.Keys) {
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation(headerKey, headers[headerKey]);
			}
		}
	}
}