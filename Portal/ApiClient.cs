using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Portal
{
	public static class ApiClient
	{
		public static HttpClient httpClient = new HttpClient();

		static ApiClient()
		{

		}

	}
}