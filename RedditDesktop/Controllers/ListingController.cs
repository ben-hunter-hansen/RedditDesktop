using System;
using C5;

namespace RedditDesktop
{
	public class ListingController
	{
		const string PLACEHOLDER_URI = "res/data/listing2.json";

		public ListingController ()
		{

		}

		public ArrayList<ListingData> GetListingData()
		{
			ListingService listServ = new ListingService (PLACEHOLDER_URI);
			return listServ.GetListingData ();
		}
	}
}

