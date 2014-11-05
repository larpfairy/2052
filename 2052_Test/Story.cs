using System;

namespace IntroCS
{
	public class Story
	{
		public static void Sequence1(Player player1)
		{
			Console.WriteLine ("Initializing stasis defragmentation...");
			Console.WriteLine ("Welcome back " + player1.name + ", you have been in stasis for some time.");
			Console.WriteLine ("There is a CHEST in the corner. There is a DOOR to the North.");
			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine ("What would you like to do?");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "CHEST") {
					Container.StartingChest (player1);
					Console.WriteLine ("There is a CHEST in the corner. There is a DOOR to the North.");
				}
				else if (input == "DOOR") {
					i++;
				}
				else if (input == "INVENTORY") {
					Inventory.DoInventory (player1);
					Console.WriteLine ("There is a CHEST in the corner. There is a DOOR to the North.");
				}
			}

			
		}
	}
}

