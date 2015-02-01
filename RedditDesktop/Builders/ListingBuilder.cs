using System;
using C5;
using Gtk;

namespace RedditDesktop
{
	public class ListingBuilder
	{
		private ArrayList<ListingData> listingData { get; set; }

		public ListingBuilder (ListingController lc)
		{
			listingData = lc.GetListingData ();
		}

		private HBox CreateChildWrapper(int spacing)
		{
			HBox child = new HBox ();
			child.Spacing = spacing;
			return child;
		}

		private Image CreateThumbnail(string url, int w, int h)
		{
			Image thumbNail = new Image ();
			if (url.Equals ("default") || url.Equals("self")) {
				var thumbBuff = new Gdk.Pixbuf ("res/img/default.png");
				thumbBuff = thumbBuff.ScaleSimple (w, h, Gdk.InterpType.Bilinear);
				thumbNail.Pixbuf = thumbBuff;
			} else {
				var thumbBuff = new Gdk.Pixbuf(RDHttp.HttpImageStream(url));
				thumbBuff = thumbBuff.ScaleSimple (w, h, Gdk.InterpType.Bilinear);
				thumbNail.Pixbuf = thumbBuff;
			}

			return thumbNail;
		}

		private VBox CreateContentWrapper(int spacing)
		{
			VBox contentWrapper = new VBox ();
			contentWrapper.Spacing = spacing;
			return contentWrapper;
		}

		private HBox CreateTitleContainer(string title)
		{
			HBox container = new HBox ();
			Label titleLabel = new Label (title);
			titleLabel.ModifyFont (RDFont.LargeFont);
			Button titleBtn = new Button (titleLabel);
			titleBtn.Relief = ReliefStyle.None;
			container.PackStart (titleBtn, false, false, 0);
			return container;
		}

		private HBox CreateDetailsBox(int points, int comments, string author, double created, int spacing)
		{
			HBox detailsBox = new HBox ();
			detailsBox.Spacing = spacing;

			//Upvote (points) Downvote
			Button upVoteBtn = new Button ();
			upVoteBtn.Image = new Image (Stock.GoUp, IconSize.Button);
			Label pointsLabel = new Label (points.ToString());
			Button downVoteBtn = new Button ();
			downVoteBtn.Image = new Image (Stock.GoDown, IconSize.Button);

			upVoteBtn.Relief = ReliefStyle.None;
			downVoteBtn.Relief = ReliefStyle.None;

			detailsBox.PackStart (upVoteBtn, false, false, 0);
			detailsBox.PackStart (pointsLabel, false, false, 0);
			detailsBox.PackStart (downVoteBtn, false, false, 0);
			detailsBox.PackStart (new VSeparator(), false, false, 0);

			//Comments Button
			Label commentLabel = new Label (comments.ToString() + " Comments");
			Button commentBtn = new Button (commentLabel);
			commentBtn.Relief = ReliefStyle.None;

			detailsBox.PackStart (commentBtn, false, false, 0);
			detailsBox.PackStart (new VSeparator (), false, false, 0);

			//Posted by and elapsed time
			DateTime postedOn = RDDateTime.DateTimeFromUnix (created);
			Label postedByLabel = new Label (author);
			Label timePostedLabel = new Label (postedOn.ToString("HH:mm:ss"));

			detailsBox.PackStart (postedByLabel, false, false, 0);
			detailsBox.PackStart (new VSeparator (), false, false, 0);
			detailsBox.PackStart (timePostedLabel, false, false, 0);

			return detailsBox;
		}

		public void Render(VBox container)
		{
			foreach (ListingData childData in listingData) {
				HBox childWrapper = CreateChildWrapper (6);
				Image thumbNail = CreateThumbnail (childData.thumbnail, 85, 85);
				childWrapper.PackStart (thumbNail, false, false, 0);

				VBox contentWrapper = CreateContentWrapper (0);

				HBox titleContainer = CreateTitleContainer (childData.title);
				contentWrapper.PackStart (titleContainer, false, false, 0);

				HBox detailsBox = CreateDetailsBox 
					(childData.score,childData.num_comments,
					 childData.author,childData.created, 6);

				contentWrapper.PackStart (detailsBox, false, false, 0);
				childWrapper.PackStart (contentWrapper, false, false, 0);
				container.PackStart (childWrapper,false,false,0);
				container.PackStart(new HSeparator (), false, false, 0);
			}
			container.ShowAll ();
		}
	}
}

