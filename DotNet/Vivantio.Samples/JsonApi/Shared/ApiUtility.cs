using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Vivantio.Samples.JsonApi.Shared
{
	public class ApiUtility
	{
		public string ApiUrl { get; set; }
		public string ApiUser { get; set; }
		public string ApiPassword { get; set; }

		public ApiUtility(string url, string user, string password)
		{
			ApiUrl = url;
			ApiUser = user;
			ApiPassword = password;
		}

		public TResponse SendRequest<TResponse>(string path)
		{
			return SendRequest<TResponse, object>(path, null);
		}

		public TResponse SendRequest<TResponse, TRequest>(string path, TRequest request)
			where TRequest : class
		{
			var httpRequest = (HttpWebRequest)WebRequest.Create(ApiUrl + path);

			httpRequest.Method = "POST";
			httpRequest.ContentType = "application/json";

			AddCredentialToRequest(httpRequest);

			if (request != null)
			{
				var serialized = JsonConvert.SerializeObject(request);
				using (var sw = new StreamWriter(httpRequest.GetRequestStream()))
				{
					sw.WriteLine(serialized);
				}
			}
			else
				httpRequest.ContentLength = 0;

			var response = (HttpWebResponse)httpRequest.GetResponse();

			var rs = response.GetResponseStream();
			if (rs != null)
			{
				using (var sr = new StreamReader(rs))
				{
					var s = sr.ReadToEnd();
					return JsonConvert.DeserializeObject<TResponse>(s);
				}
			}

			return default(TResponse);
		}

		private void AddCredentialToRequest(HttpWebRequest httpRequest)
		{
			// http://stackoverflow.com/questions/1702426/httpwebrequest-not-passing-credentials
			var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiUser + ":" + ApiPassword));
			httpRequest.Headers.Add("Authorization", "Basic " + credentials);
		}
	}
}