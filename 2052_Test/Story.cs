﻿using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
	public class Story
	{
		public static void Sequence1(Player player1)
		{
			var reader = new StreamReader ("Story.txt");

			string[] storyArray = GetStory (reader, "sequence1");
			if (!Player.storylist.Contains (1)) {
				Console.WriteLine (storyArray [0]);
			} else if (Player.storylist.Contains (1)) {
				Console.WriteLine ("You are back in your stasis room.");
			}
			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine (storyArray[1]);
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE || STATUS");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "CHEST") {
					Console.WriteLine ("You hobble over to the chest and open it up.");
					Console.Clear ();
					if (player1.playerClass == "Scientist") {
						Container.DoContainer (player1, World.ContainerByID (401));
					} else if (player1.playerClass == "Brawler") {
						Container.DoContainer (player1, World.ContainerByID (402));
					} else if (player1.playerClass == "Sniper") {
						Container.DoContainer (player1, World.ContainerByID (403));
					}
				} else if (input == "DOOR") {
					Console.Clear ();
					if (!Player.storylist.Contains (1)) {
						Console.WriteLine ("As you open the door, a robot mech is alerted to your presence. You immediately notice that the robot is not a friendly one, as a matter of fact, the robot is armed and has a tattoo 'born to kill' across its chest...");
						Console.ReadLine ();
						Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
						player1.progress++;
						Player.storylist.Add (1);
						Save.SaveGame (player1);
					} else if (Player.storylist.Contains (1)) {
						player1.progress++;
					}
					i++;
				} else if (input == "INVENTORY") {
					Console.Clear ();
					Inventory.DoInventory (player1);
				} else if (input == "SAVE") {
					Console.Clear ();
					Save.SaveGame (player1);
				} else if (input == "STATUS") {
					Console.Clear ();
					Player.PlayerSummary (player1);
				} else {
					Console.Clear ();
				}
			}

			
		}
		public static void Sequence2 (Player player1)
		{
			var reader = new StreamReader ("Story.txt");

			string[] storyArray = GetStory (reader, "sequence2");

			if (!Player.storylist.Contains (5)) {
				Console.WriteLine (storyArray [0]);
			} else if (Player.storylist.Contains (5)) {
				Console.WriteLine ("You are back in the circular computer room.");
			}


			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine (storyArray[1]);
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE || STATUS || BACK");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "GUARD") {
					Console.Clear ();
					if (!Player.storylist.Contains (2)) {
						Console.WriteLine (player1.name + "! I'm so glad you made it out of there, I was sure the stasis ward was lost entirely. If you made it this far, you might have a chance to get us out of this mess, well at least for a little bit. I'm going to need you to make your way to the utilities room and shut off the power, that should give us some time to regroup. It won't solve the problem permanently but it's worth a shot. Quickly! I'll hold them off while you search for the power grid.");
						Player.storylist.Add (2);
						Console.ReadLine ();
						Console.Clear ();
					} else if (Player.storylist.Contains (2)) {
						Console.WriteLine ("I'm not sure talking to me is the best use of your time...");
						Console.ReadLine ();
						Console.Clear ();
					}

				} else if (input == "HALLWAY") {
					Console.Clear ();
					if (!Player.storylist.Contains (3)) {
						Console.WriteLine ("As you scurry down the hallway, dead bodies litter the floor, looking up from the carnage you realize that  3 mechs are running you down!");
						Console.ReadLine ();
						Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
						Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
						Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
						Player.storylist.Add (3);
						Console.WriteLine ("After fighting off the mechs, you search for the utility room, but it doesn't appear to be in this part of the building. :(");
						Console.ReadLine ();
						Console.Clear ();
					} else if (Player.storylist.Contains (3)) {
						Console.WriteLine ("You walk down the hallway and find the remains of some slaughtered mechs. You find nothing else of value here.");
						Console.ReadLine ();
						Console.Clear ();
					}

				} else if (input == "DOCUMENT") {
					Console.Clear ();
					if (!Player.storylist.Contains (4)) {
						Console.WriteLine ("You pick up the document...");
						Player.inventory.Add ((Document)World.ItemByID (501));
						Player.storylist.Add (4);
						Console.ReadLine ();
						Console.Clear ();
					} else if (Player.storylist.Contains (4)) {
						Console.WriteLine ("You already picked that up...");
						Console.ReadLine ();
						Console.Clear ();
					}
				} else if (input == "DOOR") {
					Console.WriteLine ("You make your way past the door through a brief hallway and into another room.");
					i++;
					player1.progress++;
					Player.storylist.Add(5);
					Save.SaveGame (player1);
				} else if (input == "BACK") {
					player1.progress--;
					Console.Clear ();
					Story.Sequence1 (player1);
				} else if (input == "INVENTORY") {
					Console.Clear ();
					Inventory.DoInventory (player1);
				} else if (input == "SAVE") {
					Console.Clear ();
					Save.SaveGame (player1);
				} else if (input == "STATUS") {
					Console.Clear ();
					Player.PlayerSummary (player1);
				} else {
					Console.Clear ();
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

