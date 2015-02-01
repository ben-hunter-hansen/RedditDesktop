using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using C5;

namespace RedditDesktop
{
	public abstract class PlaceholderService
	{
		public abstract string SourceUri { get; set;}

		public PlaceholderService ()
		{

		}

		public abstract RedditModel  GetObjectModel();
	}

	public class SubscribedService : PlaceholderService
	{
		public override string SourceUri { get; set; }

		public SubscribedService (string sourceUri)
		{
			SourceUri = sourceUri;
		}

		public override RedditModel GetObjectModel()
		{
			Subscribed sObj;
			using (StreamReader sr = new StreamReader(SourceUri))
			using (JsonReader reader = new JsonTextReader(sr)) 
			{
				//Get full json object content
				var fullJsonObj = JObject.ReadFrom (reader);

				//Select only subscribed objects
				var subsToken = fullJsonObj.SelectToken ("subscribed");

				sObj = subsToken.ToObject<Subscribed> ();
			}

			return sObj;
		}
	}

	public class ListingService : PlaceholderService
	{
		public override string SourceUri { get; set; }

		public ListingService(string sourceUri)
		{
			SourceUri = sourceUri;
		}

		//Gets the data associated with each listing child node (title, author, comments, etc)
		public ArrayList<ListingData> GetListingData()
		{
			ArrayList<ListingData> theData = new ArrayList<ListingData> ();
			Listing objectModel = (Listing) GetObjectModel ();

			foreach (ListingChild child in objectModel.children) {
				theData.Add (child.data);
			}

			return theData;
		}

		//Fully mapped listing object model
		public override RedditModel GetObjectModel()
		{
			Listing listings;

			using (StreamReader sr = new StreamReader(SourceUri))
			using (JsonReader reader = new JsonTextReader(sr)) 
			{
				//Get full json object content
				var fullJsonObj = JObject.ReadFrom (reader);

				//Parse the response data
				listings = fullJsonObj.SelectToken ("data").ToObject<Listing>();
			}

			return listings;
		}
	}
}

