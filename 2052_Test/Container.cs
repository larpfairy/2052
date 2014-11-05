using System;
using System.Collections.Generic;

namespace IntroCS
{
	public static class Container
	{
		public static List<Item> chestList;

		public static void StartingChest(Player player1)
		{
			chestList = new List<Item> ();
			if (player1.playerClass == "Scientist") {
				chestList.Add (World.ItemByID (201));
				chestList.Add (World.ItemByID (1));
				chestList.Add (World.ItemByID (101));
			}
			if (player1.playerClass == "Brawler") {
				chestList.Add (World.ItemByID (201));
				chestList.Add (World.ItemByID (2));
				chestList.Add (World.ItemByID (102));
			}
			if (player1.playerClass == "Sniper") {
				chestList.Add (World.ItemByID (201));
				chestList.Add (World.ItemByID (3));
				chestList.Add (World.ItemByID (103));
			}
			for (int i = 0; i < chestList.Count; i++) {
				Console.WriteLine ((i+1) + ". " + chestList [i].name);
			}
			int j = 0;
			while(j == 0)
			{
				int input = UI.PromptIntInRange ("Please enter the number of an item you want to take. Enter 0 to leave.", 0, chestList.Count);
				if (input == 0) {
					j++;
				} 
				else if (input != 0) {
					GetItem (player1, input, chestList);
					for (int i = 0; i < chestList.Count; i++) {
						Console.WriteLine ((i + 1) + ". " + chestList [i].name);
					}
				}
			}

		}
		public static void GetItem(Player player1, int input, List<Item> chestList)
		{
			Player.inventory.Add (chestList [input-1]);
			Console.Clear ();
			Console.WriteLine (chestList [input-1].name + " has been added to your inventory.");
			chestList.RemoveAt (input-1);
		}
	}
}

