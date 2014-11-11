using System;
using System.IO;
using System.Collections.Generic;

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
				Console.WriteLine ("INVENTORY || SAVE || STATUS");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "CHEST") {
					Console.Clear ();
					if (player1.playerClass == "Scientist") {
						Container.DoContainer (player1, World.ContainerByID (401));
					} else if (player1.playerClass == "Brawler") {
						Container.DoContainer (player1, World.ContainerByID (402));
					} else if (player1.playerClass == "Sniper") {
						Container.DoContainer (player1, World.ContainerByID (403));
					}
				} else if (input == "DOOR") {
					Combat.DoCombat (player1, Enemy.GetRandomEnemyByLevel (player1));
					i++;
					player1.progress++;
					Save.SaveGame (player1);
				} else if (input == "INVENTORY") {
					Console.Clear ();
					Inventory.DoInventory (player1);
				} else if (input == "SAVE") {
					Console.Clear ();
					Save.SaveGame (player1);
				} else if (input == "STATUS") {
					Console.Clear ();
					Player.PlayerSummary (player1);
				}
			}

			
		}
		public static void Sequence2 (Player player1)
		{
			var reader = new StreamReader ("Story.txt");

			string[] storyArray = GetStory (reader, "sequence2");

			Console.WriteLine (storyArray [0]);

			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine (storyArray[1]);
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE || STATUS");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "") {
					Console.Clear ();

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
				} else if (input == "STATUS") {
					Console.Clear ();
					Player.PlayerSummary (player1);
				}
			}
		}
		public static string[] GetStory(StreamReader reader, string sequence)
		{
			string[] array = new string[2];

			while (!reader.EndOfStream) {
				string x = reader.ReadLine ();
				if (x == sequence) {
					int i = 0;
					while (i == 0) {
						string y = reader.ReadLine ();
						if (y == "~") {
							int j = 0;
							while (j == 0) {
								string z = reader.ReadLine ();
								if (z == "~") {
									j++;
									i++;
								} else {
									array [1] += z;
								}
							}
						} 
						else {
							array [0] += y;
						}
					}
				}
			}
			return array;
		}
	}
}

