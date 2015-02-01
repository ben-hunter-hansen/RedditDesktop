using System;
using C5;
using Gtk;

namespace RedditDesktop
{
	public class SubscribedBuilder
	{
		private ArrayList<SubReddit> subReddits { get; set;}

		public SubscribedBuilder (SubscribedController sc)
		{
			subReddits = sc.GetSubscribed ();
		}

		private void GenerateButton(HBox container, Label label)
		{
			HBox hb = container;
			label.ModifyFont (RDFont.DefaultFont);
			Button abtn = new Button (label);
			abtn.Relief = ReliefStyle.None;
			label.Show ();

			hb.PackStart (abtn, true, true, 0);
			abtn.Show ();

			VSeparator vs = new VSeparator ();
			hb.PackStart (vs, true, true, 0);
			vs.Show ();
		}

		public void Render(HBox browseBtnBox, ComboBox subscribedBox)
		{
			foreach(SubReddit subreddit in subReddits) {
				Label labelObj = new Label (subreddit.name);
				subscribedBox.AppendText (subreddit.name);
				GenerateButton (browseBtnBox, labelObj);
			}
		}
	}
}

