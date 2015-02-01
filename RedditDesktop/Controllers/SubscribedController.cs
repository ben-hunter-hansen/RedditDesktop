using System;
using C5;

namespace RedditDesktop
{
	public class SubscribedController
	{
		const string PLACEHOLDER_URI = "res/data/subscribed.json";

		public SubscribedController ()
		{

		}

		public ArrayList<SubReddit> GetSubscribed()
		{
			SubscribedService sserv = new SubscribedService (PLACEHOLDER_URI);
			Subscribed subscribedObj = (Subscribed) sserv.GetObjectModel ();

			return subscribedObj.subreddits;
		}
	}
}

