using System;

namespace IntroCS
{
	public class Source
	{
		public static void Main()
		{
			Help.HelpTips ();

			bool x = Load.WillLoad (); //determines if the user will load a game or not.

			var player1 = new Player ();
			if (x == false) {
				player1.name = Player.GetName ();
				Console.Clear ();
				player1.playerClass = Player.GetClass ();
				Console.Clear ();
				player1.maximumHealth = Player.GetMaximumHealth (player1.playerClass);
				player1.currentHealth = player1.maximumHealth;
				player1.STR = Player.GetAttribute (player1.playerClass, "STR");
				System.Threading.Thread.Sleep (5);
				player1.DEX = Player.GetAttribute (player1.playerClass, "DEX");
				System.Threading.Thread.Sleep (5);
				player1.INT = Player.GetAttribute (player1.playerClass, "INT");
				System.Threading.Thread.Sleep (5);
				player1.CON = Player.GetAttribute (player1.playerClass, "CON");
				player1.willpower = 10 + player1.INT / 4;
				player1.level = 1;
				player1.experience = 0;
				player1.salve = (Salve)World.ItemByID (201);

			}
			if (x == true) {
				Load.LoadGame (player1);
				Console.Clear ();
				Console.WriteLine ("Your character has been loaded.");
				Console.WriteLine ("Press enter to continue...");
				Console.ReadLine ();
				Console.Clear ();
			}

			Player.PlayerSummary (player1); //a brief summary of the characters stats.

			Save.SaveGame (player1); //saves the game. Writes to a .txt file named after the character.

			//story elements are within if statements such that if a player continues a saved game, they can be directed back to the most recent room.
			if (player1.progress <= 1) {
				Story.Sequence1 (player1);
			}
			if (player1.progress == 2) {
				Story.Sequence2 (player1);
			}
			if (player1.progress == 3) {
				Story.Sequence3 (player1);
			}
			if (player1.progress == 4) {
				return;
			}




		}
	}
}

