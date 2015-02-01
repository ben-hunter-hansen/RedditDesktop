using System;
using System.Collections.Generic;
using Gtk;
using RedditDesktop;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		PopulateSubscribed();
		PopulateListings ();

	}

	private void PopulateSubscribed()
	{
		HBox browseBtnBox = this.BrowseBtnBox;
		ComboBox subscribedBox = this.mySubredditsBox;

		SubscribedBuilder sb = new SubscribedBuilder
			(new SubscribedController());

		sb.Render (browseBtnBox, subscribedBox);

	}

	private void PopulateListings()
	{
		ListingBuilder glb = new ListingBuilder
			(new ListingController());

		glb.Render(this.ListingBox);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnLogOut (object sender, EventArgs e)
	{
		LoginWindow loginWindow = new LoginWindow ();
		loginWindow.Show ();
		this.Hide ();
	}
	protected void OnFileQuit (object sender, EventArgs e)
	{
		Application.Quit ();
	}
}
