using System;
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
				Console.WriteLine ("INVENTORY || SAVE || STATUS || HELP");
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
				} else if (input == "HELP") {
					Console.Clear ();
					Help.HelpTips ();
				}else if (input == "STATUS") {
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

			if (!Player.storylist.Contains (26)) {
				Console.WriteLine (storyArray [0]);
			} else if (Player.storylist.Contains (26)) {
				Console.WriteLine ("You are back in the circular computer room.");
			}


			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine (storyArray[1]);
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE || STATUS || HELP || BACK");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "GUARD") {
					Console.Clear ();
					if (!Player.storylist.Contains (29)) {
						if (!Player.storylist.Contains (22)) {
							Console.WriteLine (player1.name + "! I'm so glad you made it out of there, I was sure the stasis ward was lost entirely. If you made it this far, you might have a chance to get us out of this mess, well at least for a little bit. I'm going to need you to make your way to the utilities room and shut off the power, that should give us some time to regroup. It won't solve the problem permanently but it's worth a shot. Quickly! I'll hold them off while you search for the power grid.");
							Player.storylist.Add (22);
							Console.ReadLine ();
							Console.Clear ();
						} else if (Player.storylist.Contains (22)) {
							Console.WriteLine ("I'm not sure talking to me is the best use of your time...");
							Console.ReadLine ();
							Console.Clear ();
						}
					}
					if (Player.storylist.Contains (29)) {
						Console.WriteLine (player1.name + " you've done it! The power is out. Quick, down the HALLWAY we will attempt to escape to the roof. There should be a helicopter we can use to escape.");
						Console.ReadLine ();
						Console.Clear ();
					}
				} else if (input == "HALLWAY") {
					Console.Clear ();
					if (!Player.storylist.Contains (29)) {
						if (!Player.storylist.Contains (23)) {
							Console.WriteLine ("As you scurry down the hallway, dead bodies litter the floor, looking up from the carnage you realize that  3 mechs are running you down!");
							Console.ReadLine ();
							Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
							Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
							Combat.DoCombat (player1, (Enemy)World.EnemyByID (304));
							Player.storylist.Add (23);
							Console.WriteLine ("After fighting off the mechs, you search for the utility room, but it doesn't appear to be in this part of the building. :(");
							Console.ReadLine ();
							Console.Clear ();
						} else if (Player.storylist.Contains (23)) {
							Console.WriteLine ("You walk down the hallway and find the remains of some slaughtered mechs. You find nothing else of value here.");
							Console.ReadLine ();
							Console.Clear ();
						}
					}
					if (Player.storylist.Contains (29)) {
						Save.SaveGame (player1);
						player1.progress++;
						Story.Sequence4 (player1);
					}
				} else if (input == "DOCUMENT") {
					Console.Clear ();
					if (!Player.storylist.Contains (24)) {
						Console.WriteLine ("You pick up the document...");
						Player.inventory.Add ((Document)World.ItemByID (501));
						Player.storylist.Add (24);
						Console.ReadLine ();
						Console.Clear ();
					} else if (Player.storylist.Contains (24)) {
						Console.WriteLine ("You already picked that up...");
						Console.ReadLine ();
						Console.Clear ();
					}
				} else if (input == "DOOR") {
					i++;
					player1.progress++;
					Player.storylist.Add (26);
					Save.SaveGame (player1);
					Console.Clear ();
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
				} else if (input == "HELP") {
					Console.Clear ();
					Help.HelpTips (); 
				}else if (input == "STATUS") {
					Console.Clear ();
					Player.PlayerSummary (player1);
				} else {
					Console.Clear ();
				}
			}
		}
		public static void Sequence3 (Player player1)
		{
			var reader = new StreamReader ("Story.txt");

			string[] storyArray = GetStory (reader, "sequence3");

			if (!Player.storylist.Contains (30)) {
				Console.WriteLine (storyArray [0]);
				Player.storylist.Add (30);
			} else if (Player.storylist.Contains (30)) {
				Console.WriteLine ("You are back in the utility room.");
			}


			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine (storyArray [1]);
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE || STATUS || HELP || BACK");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "BOX") {
					Console.Clear ();
					if (!Player.storylist.Contains (31)) {
						Console.WriteLine ("You open the utility box and find the power switch. With one smooth motion you shut off the power and the room goes dark.");
						Player.storylist.Add (31);
						Player.storylist.Add (29);
						Console.ReadLine ();
						Console.Clear ();
					} else if (Player.storylist.Contains (31)) {
						Console.WriteLine ("The power switch is off, better leave it that way.");
						Console.ReadLine ();
						Console.Clear ();
					}

				} else if (input == "CHEST") {
					Console.Clear ();
					Console.WriteLine ("You open up the chest.");
					Container.DoContainer (player1, World.ContainerByID (404));
				} else if (input == "BACK") {
					player1.progress--;
					Console.Clear ();
					Story.Sequence2 (player1);
				} else if (input == "INVENTORY") {
					Console.Clear ();
					Inventory.DoInventory (player1);
				} else if (input == "HELP") {
					Console.Clear ();
					Help.HelpTips ();
				}else if (input == "SAVE") {
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
		public static void Sequence4 (Player player1)
		{
			var reader = new StreamReader ("Story.txt");

			string[] storyArray = GetStory (reader, "sequence4");

			if (!Player.storylist.Contains (40)) {
				Console.WriteLine (storyArray [0]);
				Console.ReadLine ();
				Console.Clear ();
				Console.WriteLine ("From the far side of the building you can see multiple enemies emerge, prepare for combat!");
				Console.ReadLine ();

				Combat.DoCombat(player1, Enemy.GetRandomEnemyByLevel(player1));
				Combat.DoCombat(player1, Enemy.GetRandomEnemyByLevel(player1));
				Combat.DoCombat(player1, Enemy.GetRandomEnemyByLevel(player1));

				Player.storylist.Add (40);

			} else if (Player.storylist.Contains (40)) {
				Console.WriteLine ("You are back on the roof");
			}

			int i = 0;
			string input = "";
			while (i == 0) {
				Console.WriteLine (storyArray[1]);
				Console.WriteLine ("What would you like to do?");
				Console.WriteLine ("INVENTORY || SAVE || STATUS || HELP || BACK");
				input = Console.ReadLine ();
				input = input.ToUpper ();
				if (input == "HELICOPTER") {
					Console.Clear ();
					Console.WriteLine ("You hastily run towards the helicopter and enter as the guard prepares to take off. After flying for about 4 hours you arrive at your destination.");
					Console.WriteLine ("Thanks for playing!");
					Console.ReadLine ();
				} else if (input == "DOCUMENT") {
					Console.Clear ();
					if (!Player.storylist.Contains (42)) {
						Console.WriteLine ("You walk over and pick up the document...");
						Player.inventory.Add ((Document)World.ItemByID (502));
						Player.storylist.Add (42);
						Console.ReadLine ();
						Console.Clear ();
					} else if (Player.storylist.Contains (42)) {
						Console.WriteLine ("You already picked that up...");
						Console.ReadLine ();
						Console.Clear ();
					}
				} else if (input == "BACK") {
					player1.progress--;
					Console.Clear ();
					Story.Sequence1 (player1);
				} else if (input == "INVENTORY") {
					Console.Clear ();
					Inventory.DoInventory (player1);
				} else if (input == "HELP") {
					Console.Clear ();
					Help.HelpTips ();
				}else if (input == "SAVE") {
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

