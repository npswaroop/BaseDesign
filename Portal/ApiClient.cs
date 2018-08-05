using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Portal
{
	public static class ApiClient
	{
		public static HttpClient httpClient = new HttpClient();

		static ApiClient()
		{
			httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUri"].ToString());
			httpClient.DefaultRequestHeaders.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ConfigurationManager.AppSettings["Content-Type"].ToString()));
		}

	}
}