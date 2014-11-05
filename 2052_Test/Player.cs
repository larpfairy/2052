using System;
using System.Collections.Generic;

namespace IntroCS
{
	public class Player
	{
		public static List<Item> inventory { get; set; }
		public int currentHealth { get; set; }
		public int maximumHealth { get; set; }
		public int experience { get; set;}
		public int STR { get; set;}
		public int DEX { get; set;}
		public int INT { get; set;}
		public int CON { get; set;}
		public string name { get; set;}
		public string playerClass { get; set;}
		public int level { get; set;}
		public Weapon weapon { get; set; }
		public Salve salve { get; set; }


		public Player()
		{
			inventory = new List<Item>();
			weapon = (Weapon)World.ItemByID (4);
		}
		public static string GetName()
		{
			string NAME = UI.PromptLine ("Please enter your name: ");
			return NAME;
		}

		public static string GetClass()
		{
			string[] classes = new string[3];
			classes [0] = "Scientist";
			classes [1] = "Brawler";
			classes [2] = "Sniper";
			Console.WriteLine ("Please choose a class");
			for (int i = 0; i < classes.Length; i++) {
				Console.Write ((i + 1) + ". ");
				Console.WriteLine (classes [i]);
			}
			int classNumber = UI.PromptIntInRange ("", 1, 3);
			string playerclass = classes [classNumber - 1];
			return playerclass;
		}
		public static int GetMaximumHealth(string playerClass)
		{
			if (playerClass == "Scientist") {
				return 10;
			}
			if (playerClass == "Brawler") {
				return 15;
			}
			if (playerClass == "Sniper") {
				return 12;
			}
			return -1;
		}
		public static int GetAttribute(string playerClass, string attribute)
		{
			Random random = new Random ();
			int att = 0;
			if (playerClass == "Scientist") {
				if (attribute == "INT") {
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7) + 4;
				} else {
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7);
				}
			}

			else if (playerClass == "Brawler") {
				if (attribute == "STR") {
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7) + 4;
				} else {
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7);
				}
			}

			else if (playerClass == "Sniper") {
				if (attribute == "DEX") {
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7) + 4;
				} else {
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7);
				}
			}
			return att;
		}
	}
}

