using System;
using System.Collections.Generic;

namespace IntroCS
{
	public class Inventory
	{
		public static void DoInventory(Player player1)
		{
			int i = 0;
			while (i == 0) {
				int j = 0;
				foreach (Item item in Player.inventory) {
					Console.WriteLine ((j+1) + ". " + item.name);
					j++;
				}
				int input = UI.PromptIntInRange ("Please enter the number of an item. Enter 0 to exit.", 0, Player.inventory.Count);

				if (input == 0) {
					i++;
					return;
				}

				if (Player.inventory [input-1].ID > 0 && Player.inventory [input-1].ID <= 100) {
					Console.Clear ();
					Console.WriteLine (player1.weapon.name + " has been replaced with " + World.ItemByID (Player.inventory [input-1].ID).name + ".");
					var inventory2 = Player.inventory [input - 1];
					Player.inventory.Add(player1.weapon);
					player1.weapon = (Weapon)World.ItemByID (Player.inventory [input-1].ID);
					Player.inventory.RemoveAt (input - 1);
				}
				if (Player.inventory [input-1].ID > 200 && Player.inventory [input-1].ID <= 300) {
					Console.Clear ();
					player1.salve = (Salve)World.ItemByID (Player.inventory [input-1].ID);
					player1.currentHealth += player1.salve.healingvalue;
					if (player1.currentHealth > player1.maximumHealth) {
						player1.currentHealth = player1.maximumHealth;
					}
					Console.WriteLine ("You have used the " + Player.inventory [input-1].name + " to heal " + player1.salve.healingvalue + " health!");
					Player.inventory.RemoveAt (input-1);
				}
				if (Player.inventory [input - 1].ID > 100 && Player.inventory [input - 1].ID <= 200) {
					Console.Clear ();
					Console.WriteLine (player1.armor.name + " has been replaced with " + World.ItemByID (Player.inventory [input - 1].ID).name + ".");
					Player.inventory.Add(player1.armor);
					player1.armor = (Armor)World.ItemByID (Player.inventory [input - 1].ID);
					Player.inventory.RemoveAt (input - 1);
				}

			}

		}
	}
}

