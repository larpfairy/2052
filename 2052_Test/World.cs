﻿using System;
using System.Collections.Generic;

namespace IntroCS
{
	public static class World
	{
		public static List<Item> Items = new List<Item>();
		public static List<Enemy> Enemies = new List<Enemy>();
		public static List<Container> Containers = new List<Container> ();

		//Container Lists
		private static List<Item> scientist_chest_list = new List<Item> ();
		private static List<Item> brawler_chest_list = new List<Item> ();
		private static List<Item> sniper_chest_list = new List<Item> ();

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

		//containers 401 -500
		public const int scientist_chest = 401;
		public const int brawler_chest = 402;
		public const int sniper_chest = 403;

		static World ()
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
		}
		private static void PopulateItems()
		{
			Items.Add (new Weapon (telekinesis_gloves, "Telekinesis Gloves", 5, 5, 11, "INT"));
			Items.Add (new Weapon (brass_knuckles, "Brass Knuckles", 5, 5, 10, "STR"));
			Items.Add (new Weapon (slingshot, "Slingshot", 5, 5, 10, "DEX"));
			Items.Add (new Weapon (starting_weapon, "Stick", 5, 0, 0, "STR"));
			Items.Add (new Armor (lab_coat, "Lab Coat", 5, 10, "Light"));
			Items.Add (new Armor (fighter_regalia, "Fighter Regalia", 5, 10, "Heavy"));
			Items.Add (new Armor (unimpressionable_clothing, "Unimpressionable Clothing", 5, 10, "Light"));
			Items.Add (new Armor (kakis_and_tshirt, "Kakis and t-shirt", 5, 0, "Light"));
			Items.Add (new Salve (medi_gel, "Medi-Gel", 10, 10));
		}
		private static void PopulateEnemies()
		{
			Enemies.Add (new Enemy (raider, 1, 10, "Raider", 5, 10, 5, "Laser Pistol", "STR",15, 10, 10, 10, 10));
			Enemies.Add (new Enemy (raider_commander, 1, 15, "Raider Commander", 6, 10, 7, "Plasma Rifle", "STR", 16, 15, 10, 20, 10));
		}
		private static void PopulateContainers()
		{
			Containers.Add(new Container(scientist_chest, scientist_chest_list));
			Containers.Add (new Container (brawler_chest, brawler_chest_list));
			Containers.Add (new Container (sniper_chest, sniper_chest_list));
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

