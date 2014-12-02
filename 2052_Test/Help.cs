using System;

namespace IntroCS
{
	public class Help
	{
		public static void HelpTips()
		{
			Console.WriteLine ("Helpful Tips");
			Console.WriteLine ("1. If presented with multiple options with numbers next to them, enter the number of the choice you would like.");
			Console.WriteLine ("2. If presented with UPPERCASE words, type the word and hit enter to choose that option.");
			Console.WriteLine ("3. If the game stops at a screen with no UPPERCASE words or numbered options, hit enter after you have read the current screen to continue.");
			Console.WriteLine ("Press enter to continue...");
			Console.ReadLine ();
			Console.Clear ();
		}
	}
}

