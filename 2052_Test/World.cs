using System;
using System.Collections.Generic;

namespace IntroCS
{
	public static class World
	{
		//these lists are comprised of different items and are populated by the populate methods below.
		public static List<Item> Items = new List<Item>();
		public static List<Enemy> Enemies = new List<Enemy>();
		public static List<Container> Containers = new List<Container> ();

		//Container Lists, each container has a list of items that it has inside it.
		private static List<Item> scientist_chest_list = new List<Item> ();
		private static List<Item> brawler_chest_list = new List<Item> ();
		private static List<Item> sniper_chest_list = new List<Item> ();
		private static List<Item> utility_room_chest_list = new List<Item> ();

		//weapons 1-100
		public const int telekinesis_gloves = 1;
		public const int brass_knuckles = 2;
		public const int slingshot = 3;
		public const int starting_weapon = 4;
		public const int laser_rifle = 5;
		public const int psychic_earmuffs = 6;
		public const int baseball_bat = 7;

		//armor 101-200
		public const int lab_coat = 101;
		public const int fighter_regalia = 102;
		public const int unimpressionable_clothing = 103;
		public const int kakis_and_tshirt = 104;
		public const int power_armor_light = 105;
		public const int power_armor_heavy = 106;

		//salves 201-300
		public const int medi_gel = 201;

		//enemies 301 -400
		public const int raider = 301;
		public const int raider_commander = 302;
		public const int giant_rat = 303;
		public const int mech = 304;

		//containers 401 -500
		public const int scientist_chest = 401;
		public const int brawler_chest = 402;
		public const int sniper_chest = 403;
		public const int utility_room_chest = 404;

		//documents 501=600
		public const int computer_room_document = 501;
		public const int roof_document = 502;

		static World () // constructor creates all objects and object lists.
		{
			PopulateItems ();
			PopulateEnemies ();
			PopulateContainers ();
			PopulateChestLists ();
		}
		private static void PopulateChestLists ()
		{
			scientist_chest_list.Add (ItemByID (1)); scientist_chest_list.Add (ItemByID (101)); scientist_chest_list.Add (ItemByID (201));
			brawler_chest_list.Add (ItemByID (2)); brawler_chest_list.Add (ItemByID (102)); brawler_chest_list.Add (ItemByID (201));
			sniper_chest_list.Add (ItemByID (3)); sniper_chest_list.Add (ItemByID (103)); sniper_chest_list.Add (ItemByID (201));
			utility_room_chest_list.Add (ItemByID (5));utility_room_chest_list.Add (ItemByID (6));utility_room_chest_list.Add (ItemByID (7));utility_room_chest_list.Add (ItemByID (105));utility_room_chest_list.Add (ItemByID (106));

		}
		private static void PopulateItems()
		{
			Items.Add (new Weapon (telekinesis_gloves, "Telekinesis Gloves", 5, 5, 11, "INT"));
			Items.Add (new Weapon (brass_knuckles, "Brass Knuckles", 5, 5, 10, "STR"));
			Items.Add (new Weapon (slingshot, "Slingshot", 5, 5, 10, "DEX"));
			Items.Add (new Weapon (starting_weapon, "Stick", 5, 0, 0, "STR"));
			Items.Add (new Weapon (baseball_bat, "Baseball Bat", 10, 10, 15, "STR"));
			Items.Add (new Weapon (psychic_earmuffs, "Psychic Earmuffs", 10, 10, 15, "INT"));
			Items.Add (new Weapon (laser_rifle, "Laser Rifle", 10, 10, 15, "DEX"));
			Items.Add (new Armor (power_armor_heavy, "Heavy Power Armor", 20, 18, "Heavy"));
			Items.Add (new Armor (power_armor_light, "Light Power Armor", 20, 18, "Light"));
			Items.Add (new Armor (lab_coat, "Lab Coat", 5, 10, "Light"));
			Items.Add (new Armor (fighter_regalia, "Fighter Regalia", 5, 10, "Heavy"));
			Items.Add (new Armor (unimpressionable_clothing, "Unimpressionable Clothing", 5, 10, "Light"));
			Items.Add (new Armor (kakis_and_tshirt, "Kakis and t-shirt", 5, 0, "Light"));
			Items.Add (new Salve (medi_gel, "Medi-Gel", 10, 10));
			Items.Add (new Document (computer_room_document, "singularity document", 0, Document.GetContent ("singularity_document")));
			Items.Add (new Document (roof_document, "State of Affairs", 0, Document.GetContent("roof_document")));
		}
		private static void PopulateEnemies()
		{
			Enemies.Add (new Enemy (raider, 1, 10, 10, "Raider", 5, 10, 5, "Laser Pistol", "STR",15, 10, 10, 10, 10));
			Enemies.Add (new Enemy (raider_commander, 2, 15, 15,"Raider Commander", 6, 10, 7, "Plasma Rifle", "STR", 16, 15, 10, 20, 10));
			Enemies.Add (new Enemy (mech, 1, 10, 10, "Mech", 2, 4, 2, "Minigun", "DEX", 10, 10, 5, 10, 10));
		}
		private static void PopulateContainers()
		{
			Containers.Add(new Container(scientist_chest, scientist_chest_list));
			Containers.Add (new Container (brawler_chest, brawler_chest_list));
			Containers.Add (new Container (sniper_chest, sniper_chest_list));
			Containers.Add (new Container (utility_room_chest, utility_room_chest_list));
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
		public static Container ContainerByID(int id)
		{
			foreach (Container container in Containers) {
				if (container.ID == id) {
					return container;
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

