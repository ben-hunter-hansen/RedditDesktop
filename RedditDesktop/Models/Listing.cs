using System;
using C5;

namespace RedditDesktop
{
	public class Listing : RedditModel
	{
		public string after { get; set; }
		public string before { get; set; }
		public ArrayList<ListingChild> children { get; set; }
	}

	public class ListingChild : RedditModel
	{
		public ListingData data { get; set; }
		public string kind { get; set; }
	}

	public class ListingData : RedditModel
	{
		public string author { get; set; }
		public bool clicked { get; set; }
		public double created { get; set; }
		public string domain { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public int num_comments { get; set; }
		public bool over_18 { get; set; }
		public string selftext{ get; set; }
		public string selftext_html { get ;set; }
		public string permalink { get; set; }
		public int score { get; set; }
		public string subreddit { get; set; }
		public string subreddit_id { get; set; }
		public string thumbnail { get; set; }
		public string title { get; set; }
		public int ups { get; set; }
		public string url { get; set;}
		public bool visited { get; set; }
	}
}

