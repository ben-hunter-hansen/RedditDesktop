using System;

namespace RedditDesktop
{
	public static class RDDateTime
	{
		public static DateTime DateTimeFromUnix(double timeStamp)
		{
			System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds( timeStamp ).ToLocalTime();
			return dtDateTime;
		}
	}
}

