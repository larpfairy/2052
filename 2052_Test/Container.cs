using System;
using System.Collections.Generic;

namespace IntroCS
{
	public  class Container
	{
		public List<Item> chestList;
		public int ID;

		public Container(int id, List<Item> chestlist)
		{
			chestList = chestlist;
			ID = id;
		}


		public static void DoContainer(Player player1, Container container)
		{
			Console.Clear ();

			var chestList = container.chestList;

			int j = 0;
			while(j == 0)
			{
				for (int i = 0; i < chestList.Count; i++) {
					Console.WriteLine ((i + 1) + ". " + chestList [i].name);
				}

				int input = UI.PromptIntInRange ("Please enter the number of an item you want to take. Enter 0 to leave.", 0, chestList.Count);
				if (input == 0) {
					Console.Clear ();
					j++;
				} 
				else if (input != 0) {
					Player.inventory.Add (chestList [input-1]);
					Console.Clear ();
					Console.WriteLine (chestList [input-1].name + " has been added to your inventory.");
					chestList.RemoveAt (input-1);
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

