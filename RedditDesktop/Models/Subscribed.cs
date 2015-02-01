using System;
using C5;
namespace RedditDesktop
{
	public class Subscribed : RedditModel
	{
		public ArrayList<SubReddit> subreddits { get; set; }
	}

	public class SubReddit : RedditModel
	{
		public string name { get; set; }
	}
}

