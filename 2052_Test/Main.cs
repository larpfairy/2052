using System;

namespace IntroCS
{
	public class Source
	{
		public static void Main()
		{
			var player1 = new Player ();
			player1.name = Player.GetName ();
			player1.playerClass = Player.GetClass ();
			player1.maximumHealth = Player.GetMaximumHealth (player1.playerClass);
			player1.currentHealth = player1.maximumHealth;
			player1.STR = Player.GetAttribute (player1.playerClass, "STR");
			player1.DEX = Player.GetAttribute (player1.playerClass, "DEX");
			player1.INT = Player.GetAttribute (player1.playerClass, "INT");
			player1.CON = Player.GetAttribute (player1.playerClass, "CON");
			player1.level = 1;
			player1.experience = 0;

			Story.Sequence1 (player1);




		}
	}
}

