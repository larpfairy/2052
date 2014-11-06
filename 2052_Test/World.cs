using System;
using System.Collections.Generic;

namespace IntroCS
{
	public static class World
	{
		public static List<Item> Items = new List<Item>();
		public static List<Enemy> Enemies = new List<Enemy>();

		//weapons 1-100
		public const int telekinesis_gloves = 1;
		public const int brass_knuckles = 2;
		public const int slingshot = 3;
		public const int starting_weapon = 4;
		//armor 101-200
		public const int lab_coat = 101;
		public const int fighter_regalia = 102;
		public const int unimpressionable_clothing = 103;
		public const int kakis_and_tshirt = 104;
		//salves 201-300
		public const int medi_gel = 201;

		//enemies 301 -400
		public const int raider = 301;
		public const int raider_commander = 302;
		public const int giant_rat = 303;

		static World ()
		{
			PopulateItems ();
			PopulateEnemies ();
		}
		private static void PopulateItems()
		{
			Items.Add (new Weapon (telekinesis_gloves, "Telekinesis Gloves", 5, 11));
			Items.Add (new Weapon (brass_knuckles, "Brass Knuckles", 5, 10));
			Items.Add (new Weapon (slingshot, "Slingshot", 5, 10));
			Items.Add (new Weapon (starting_weapon, "Stick", 0, 0));
			Items.Add (new Armor (lab_coat, "Lab Coat", 10));
			Items.Add (new Armor (fighter_regalia, "Fighter Regalia", 10));
			Items.Add (new Armor (unimpressionable_clothing, "Unimpressionable Clothing", 10));
			Items.Add (new Armor (kakis_and_tshirt, "Kakis and t-shirt", 0));
			Items.Add (new Salve (medi_gel, "Medi-Gel", 10));
		}
		private static void PopulateEnemies()
		{
			Enemies.Add (new Enemy (raider, 1, 10, "Raider", 10, 5));
			Enemies.Add (new Enemy (raider_commander, 1, 15, "Radier Commander", 15, 10));
			Enemies.Add (new Enemy (giant_rat, 1, 8, "Giant Rat", 8, 4)); 
		}
		public static Item ItemByID(int id)
		{
			foreach (Item item in Items) {
				if (item.ID == id) {
					return item;
				}
			}
			return null;
		}
		public static Enemy EnemyByID(int id)
		{
			foreach (Enemy enemy in Enemies) {
				if (enemy.ID == id) {
					return enemy;
				}
			}
			return null;
		}

	}
}

