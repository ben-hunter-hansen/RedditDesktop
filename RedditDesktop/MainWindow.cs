using System;
using System.Collections.Generic;
using Gtk;
using RedditDesktop;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

public partial class MainWindow: Gtk.Window
{	
	private Pango.FontDescription defaultFont { get; set; }
	private Pango.FontDescription largeFont { get; set; }

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Pango.FontDescription defaultFd = new Pango.FontDescription ();
		defaultFd.Size = FontSize.SIZE_12;
		defaultFd.Weight = Pango.Weight.Light;
		defaultFont = defaultFd;

		Pango.FontDescription largeFd = new Pango.FontDescription ();
		largeFd.Size = FontSize.SIZE_14;
		largeFd.Weight = Pango.Weight.Light;
		largeFont = largeFd;

		//Some placeholder values
		List<string> subscribedSubs = new List<string> ();
		subscribedSubs.Add ("DayZ");
		subscribedSubs.Add ("ProgrammerHumor");
		subscribedSubs.Add ("Programming");
		subscribedSubs.Add ("PCMasterRace");
		subscribedSubs.Add ("Gaming");
		subscribedSubs.Add ("Ask Reddit");
		subscribedSubs.Add ("InternetIsBeautiful");
		subscribedSubs.Add ("EarthPorn");

		PopulateSubscribed(subscribedSubs);
		PopulateListings ();
	}

	private void GenerateButtons(HBox container, Label label)
	{
		HBox hb = container;
		label.ModifyFont (defaultFont);
		Button abtn = new Button (label);
		abtn.Relief = ReliefStyle.None;
		label.Show ();

		hb.PackStart (abtn, true, true, 0);
		abtn.Show ();

		VSeparator vs = new VSeparator ();
		hb.PackStart (vs, true, true, 0);
		vs.Show ();
	}

	private void PopulateSubscribed(List<string> subList)
	{
		HBox browseBtnBox = this.BrowseBtnBox;
		ComboBox subscribedBox = this.mySubredditsBox;

		foreach (string label in subList) {
			Label labelObj = new Label (label);
			subscribedBox.AppendText (label);
			GenerateButtons (browseBtnBox, labelObj);
		}

		string path = "res/data/placeholders.json";
		using (StreamReader sr = new StreamReader(path))
		using (JsonReader reader = new JsonTextReader(sr)) {
			while (reader.Read()) {
				if(reader.TokenType == JsonToken.String) {
					Console.WriteLine (reader.Value);
				}
			}
		}

	}

	private void PopulateListings()
	{
		const int MAX_LISTINGS = 5;

		string[] imgs = {
			"res/img/listing1.jpg",
			"res/img/listing2.jpg",
			"res/img/listing3.jpg",
			"res/img/listing4.jpg",
			"res/img/listing5.jpg"
		};

		string[] titles = {
			"Whenever a client is surprised by how fast a change goes \"live\"",
			"Craigslist Error - Short and Stout",
			"I propose we make cat fields a new standard for API error responses.",
			"As a CS minor about to start his second class, I very much regret this decision",
			"My -2 +2 PR Was Just Merged!"
		};

		for (int i = 0; i < MAX_LISTINGS; i++) {
			int points = i * 100 + 1;
			int comments = points / 2;
			Listing aListing = new Listing 
				(imgs [i], titles [i], "/u/kerret", comments, "2 Hours ago", points, this.ListingBox);
			aListing.Render ();
		}
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
