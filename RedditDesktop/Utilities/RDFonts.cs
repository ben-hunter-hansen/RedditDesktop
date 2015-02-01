using System;
using Gtk;
namespace RedditDesktop
{
	public static class FontSize
	{
		public static int SIZE_8 = 8 * (int)Pango.Scale.PangoScale;
		public static int SIZE_10 = 10 * (int)Pango.Scale.PangoScale;
		public static int SIZE_12 = 12 * (int)Pango.Scale.PangoScale;
		public static int SIZE_14 = 14 * (int)Pango.Scale.PangoScale;
		public static int SIZE_16 = 16 * (int)Pango.Scale.PangoScale;
		public static int SIZE_18 = 18 * (int)Pango.Scale.PangoScale;
	}

	public static class RDFont
	{
		public static Pango.FontDescription DefaultFont
		{
			get {
				Pango.FontDescription defaultFd = new Pango.FontDescription ();
				defaultFd.Size = FontSize.SIZE_12;
				defaultFd.Weight = Pango.Weight.Light;
				return defaultFd;
			}
		}

		public static Pango.FontDescription LargeFont
		{
			get {
				Pango.FontDescription largeFd = new Pango.FontDescription ();
				largeFd.Size = FontSize.SIZE_14;
				largeFd.Weight = Pango.Weight.Light;
				return largeFd;
			}
		}	
	}
}

