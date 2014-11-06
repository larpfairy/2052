using System;

namespace IntroCS
{
	public class Source
	{
		public static void Main()
		{
			bool x = Load.WillLoad ();

			var player1 = new Player ();
			if (x == false) {
				player1.name = Player.GetName ();
				Console.Clear ();
				player1.playerClass = Player.GetClass ();
				Console.Clear ();
				player1.maximumHealth = Player.GetMaximumHealth (player1.playerClass);
				player1.currentHealth = player1.maximumHealth;
				player1.STR = Player.GetAttribute (player1.playerClass, "STR");
				player1.DEX = Player.GetAttribute (player1.playerClass, "DEX");
				player1.INT = Player.GetAttribute (player1.playerClass, "INT");
				player1.CON = Player.GetAttribute (player1.playerClass, "CON");
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

			Player.PlayerSummary (player1);

			Save.SaveGame (player1);

			if (player1.progress <= 1) {
				Story.Sequence1 (player1);
			}




		}
	}
}

