using System;

namespace IntroCS
{
	public class Story
	{
		public static void Sequence1(Player player1)
		{
			Console.WriteLine ("Initializing stasis defragmentation...");
			Console.WriteLine ("Welcome back " + player1.name + ", you have been in stasis for some time.");
			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine ("There is a CHEST in the corner. There is a DOOR to the North.");
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "CHEST") {
					Console.Clear ();
					Container.BasicChest (player1);
				} else if (input == "DOOR") {
					i++;
					player1.progress++;
					Save.SaveGame (player1);
				} else if (input == "INVENTORY") {
					Console.Clear ();
					Inventory.DoInventory (player1);
				} else if (input == "SAVE") {
					Console.Clear ();
					Save.SaveGame (player1);
					Console.WriteLine ("The game has been saved :)");
				}
			}

			
		}
	}
}

