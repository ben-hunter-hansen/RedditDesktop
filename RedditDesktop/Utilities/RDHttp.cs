using System;
using Gtk;
using System.Net;
using System.IO;

namespace RedditDesktop
{
	public static class RDHttp
	{
		public static Stream HttpImageStream(string url)
		{
			Console.WriteLine (url);
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			return response.GetResponseStream ();
		}
	}
}

