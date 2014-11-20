using System;
using System.IO;

namespace IntroCS
{
	public class Load
	{
		public static bool WillLoad()
		{
			int i = 0;
			while (i == 0) {
				Console.WriteLine ("Would you like to load a previous save?");
				Console.WriteLine ("YES || NO");
				string input = Console.ReadLine ().ToUpper ();
				if (input == "YES") {
					return true;
				} else if (input == "NO") {
					return false;
				} else {
					Console.Clear ();
					Console.WriteLine ("I can't understand you.");
				}
			}
			return false;
		}
		public static void LoadGame(Player player1)
		{
			string filename = FileCheck ();
			var reader = new StreamReader (filename);

			player1.name = reader.ReadLine ();
			player1.playerClass = reader.ReadLine ();
			player1.level = int.Parse(reader.ReadLine ());
			player1.experience = int.Parse (reader.ReadLine ());
			player1.currentHealth = int.Parse(reader.ReadLine ());
			player1.maximumHealth = int.Parse(reader.ReadLine ());
			player1.STR = int.Parse(reader.ReadLine ());
			player1.DEX = int.Parse(reader.ReadLine ());
			player1.INT = int.Parse(reader.ReadLine ());
			player1.CON = int.Parse(reader.ReadLine ());
			player1.weapon = (Weapon)World.ItemByID(int.Parse(reader.ReadLine ()));
			player1.armor = (Armor)World.ItemByID(int.Parse(reader.ReadLine ()));
			player1.salve = (Salve)World.ItemByID (int.Parse (reader.ReadLine ()));
			player1.progress = int.Parse (reader.ReadLine ());

			int input;
			string checkinput;
			int i = 0;
			while (i == 0) {
				checkinput = reader.ReadLine ();
				if (checkinput == "~") {
					break;
				}
				input = int.Parse (checkinput);

				if (input > 0 && input <= 100) {
					//weapon
					Player.inventory.Add((Weapon)World.ItemByID(input));
				} else if (input > 100 && input <= 200) {
					//armor
					Player.inventory.Add((Armor)World.ItemByID(input));
				} else if (input > 200 && input <= 300) {
					//salve
					Player.inventory.Add((Salve)World.ItemByID(input));
				}
			}
			int storyinput;
			while (!reader.EndOfStream) {
				storyinput = int.Parse(reader.ReadLine ());
				Player.storylist.Add (storyinput);
			}

			reader.Close ();

		}
		public static string FileCheck()
		{
			int i = 0;
			string input = "";
			while (i == 0) {
				input = UI.PromptLine ("Please enter the name of your character: ");
				if (File.Exists (input + ".txt")) {
					i++;
				} else {
					Console.Clear ();
					Console.WriteLine ("That file doesn't exist.");
				}
			}
			return input + ".txt";
		}
	}
}

