using System;
using Gtk;
namespace RedditDesktop
{
	public partial class LoginWindow : Gtk.Window
	{
		const int MAX_USERN_LEN = 20;
		const int MIN_USERN_LEN = 3;
		const int MIN_PWD_LEN = 6;

		public LoginWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			var logoBuff = new Gdk.Pixbuf ("res/img/reddit_alien.png");
			Image logoImg = new Image ();
			logoImg.Pixbuf = logoBuff;
			this.LogoContainer.PackStart (logoImg, false, false, 0);
			this.LogoContainer.ShowAll ();

		}
		protected void OnDelete (object o, Gtk.DeleteEventArgs args)
		{
			Application.Quit ();
			args.RetVal = true;
		}

		private bool isAccountInfoValid()
		{
			int curUserEntryLength = this.userEntry.Text.Length;
			int curUserPassLength = this.passEntry.Text.Length;

			if (curUserEntryLength >= MIN_USERN_LEN &&
			    curUserEntryLength <= MAX_USERN_LEN &&
			    curUserPassLength >= MIN_PWD_LEN) {
				return true;
			} else {
				return false;
			}
		}

		protected void OnKeyRelease (object o, KeyReleaseEventArgs args)
		{
			int curUserEntryLength = this.userEntry.Text.Length;
			int curUserPassLength = this.passEntry.Text.Length;

			if (isAccountInfoValid()) {
				this.loginBtn.Sensitive = true;
			} else {
				this.loginBtn.Sensitive = false;
			}
			args.RetVal = true;
		}

		protected void OnLoginClick (object sender, EventArgs e)
		{

			//TODO: Implement reddit API
			MainWindow main = new MainWindow ();
			main.Show ();
			this.Destroy ();
		}
	}
}

