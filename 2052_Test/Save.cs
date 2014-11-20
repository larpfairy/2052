using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class Save
	{
		public static void SaveGame(Player player1)
		{
			string filename = player1.name + ".txt";
			var writer = new StreamWriter (filename);
			writer.WriteLine (player1.name);
			writer.WriteLine (player1.playerClass);
			writer.WriteLine (player1.level);
			writer.WriteLine (player1.experience);
			writer.WriteLine (player1.currentHealth);
			writer.WriteLine (player1.maximumHealth);
			writer.WriteLine (player1.STR);
			writer.WriteLine (player1.DEX);
			writer.WriteLine (player1.INT);
			writer.WriteLine (player1.CON);
			writer.WriteLine (player1.weapon.ID);
			writer.WriteLine (player1.armor.ID);
			writer.WriteLine (player1.salve.ID);
			writer.WriteLine (player1.progress);
			for (int i = 0; i < Player.inventory.Count; i++) {
				writer.WriteLine (Player.inventory [i].ID);
			}
			writer.WriteLine ("~");
			for (int i = 0; i < Player.storylist.Count; i++) {
				writer.WriteLine (Player.storylist [i]);
			}

			Console.WriteLine ("The game has been saved :)");

			writer.Close ();


		}
	}
}

