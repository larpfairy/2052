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
					Console.WriteLine ((j + 1) + ". " + item.name);
					Console.WriteLine("\tSell Value: " + item.value);
					if (item.ID > 0 && item.ID <= 100) {
						Weapon weapon;
						weapon = (Weapon)World.ItemByID (item.ID);
						Console.WriteLine ("\tMax Damage: " + weapon.maxDamage);
						Console.WriteLine ("\tMin Damage: " + weapon.minDamage);
						Console.WriteLine ("\tType: " + weapon.Type);
					} else if (item.ID > 200 && item.ID <= 300) {
						Salve salve;
						salve = (Salve)World.ItemByID (item.ID);
						Console.WriteLine ("\tHealing Power: " + salve.healingvalue);
					} else if (item.ID > 100 && item.ID <= 200) {
						Armor armor;
						armor = (Armor)World.ItemByID (item.ID);
						Console.WriteLine ("\tArmor: " + armor.armorClass);
						Console.WriteLine ("\tType: " + armor.armorType);
					}
					Console.WriteLine ();
					j++;
				}
				int input = UI.PromptIntInRange ("Please enter the number of an item. Enter 0 to exit, -1 to drop", -1, Player.inventory.Count);

				if (input == 0) {
					i++;
					Console.Clear ();
					return;
				} else if (input == -1) {
					int drop = UI.PromptIntInRange ("Please enter the number of an item you want to drop", 1, Player.inventory.Count);
					Console.Clear ();
					Console.WriteLine (World.ItemByID (Player.inventory [drop - 1].ID).name + " has been dropped.");
					Player.inventory.RemoveAt (drop - 1);
				} else if (Player.inventory [input - 1].ID > 0 && Player.inventory [input - 1].ID <= 100) {
					Console.Clear ();
					Console.WriteLine (player1.weapon.name + " has been replaced with " + World.ItemByID (Player.inventory [input - 1].ID).name + ".");
					var inventory2 = Player.inventory [input - 1];
					Player.inventory.Add (player1.weapon);
					player1.weapon = (Weapon)World.ItemByID (Player.inventory [input - 1].ID);
					Player.inventory.RemoveAt (input - 1);
				} else if (Player.inventory [input - 1].ID > 200 && Player.inventory [input - 1].ID <= 300) {
					Console.Clear ();
					player1.salve = (Salve)World.ItemByID (Player.inventory [input - 1].ID);
					player1.currentHealth += player1.salve.healingvalue;
					if (player1.currentHealth > player1.maximumHealth) {
						player1.currentHealth = player1.maximumHealth;
					}
					Console.WriteLine ("You have used the " + Player.inventory [input - 1].name + " to heal " + player1.salve.healingvalue + " health!");
					Player.inventory.RemoveAt (input - 1);
				} else if (Player.inventory [input - 1].ID >= 101 && Player.inventory [input - 1].ID <= 200) {
					Console.Clear ();
					Console.WriteLine (player1.armor.name + " has been replaced with " + World.ItemByID (Player.inventory [input - 1].ID).name + ".");
					Player.inventory.Add (player1.armor);
					player1.armor = (Armor)World.ItemByID (Player.inventory [input - 1].ID);
					Player.inventory.RemoveAt (input - 1);
				} else if (Player.inventory [input - 1].ID >= 501 && Player.inventory [input - 1].ID <= 600) {
					Console.Clear ();
					Document document = (Document)World.ItemByID (Player.inventory [input - 1].ID);
					Console.WriteLine (document.content);
					Console.ReadLine ();
					Console.Clear ();
				}

			}

		}
	}
}

