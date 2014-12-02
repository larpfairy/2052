using System;
using System.Collections.Generic;

namespace IntroCS
{
	public class Player
	{
		public static List<Item> inventory { get; set; }
		public static List<int> storylist { get; set; }
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
		public Armor armor { get; set; }
		public int willpower { get; set; }
		public int initiative { get; set; }
		public Salve salve { get; set; }
		public int progress { get; set;}
		public int Value { get; set; }


		public Player()
		{
			inventory = new List<Item>();
			storylist = new List<int> ();
			weapon = (Weapon)World.ItemByID (4);
			armor = (Armor)World.ItemByID (104);
			progress = 1;
			initiative = 10 + (DEX/4);
			Value = 0;
		}
		public static string GetName()
		{
			string NAME = UI.PromptLine ("Please enter your name: ");
			return NAME;
		}

		public static string GetClass()
		{
			Console.WriteLine ("Class Selection");
			Console.WriteLine ("Each class has a unique playstyle and uses different key abilities. Additionally, each class has differnt values for their defenses and attacks.");
			Console.WriteLine ("A scientist uses intelligence to hit against an enemies willpower. Has a higher willpower but lower armor class. Has less health for more attack.");
			Console.WriteLine ("A brawler uses strength to bash his foes to pieces. Has a higher armor class but lower willpower. Has more health for less attack.");
			Console.WriteLine ("A sniper uses dexterity to shoot his foes with various guns. Has an average armor class and willpower, has average health and good attack.");

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
					att = random.Next (1, 7) + random.Next (1, 7) + random.Next (1, 7) + 4;;
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
		public static void PlayerSummary (Player player1)
		{
			Console.WriteLine ("Name: " + player1.name);
			Console.WriteLine ("Class: " + player1.playerClass);
			Console.WriteLine ("Level: " + player1.level);
			Console.WriteLine ("Strength: " + player1.STR);
			Console.WriteLine ("Dexterity: " + player1.DEX);
			Console.WriteLine ("Intelligence: " + player1.INT);
			Console.WriteLine ("Constitution: " + player1.CON);
			Console.WriteLine ("Health: " + player1.maximumHealth);
			Console.WriteLine ("Experience: " + player1.experience);
			Console.WriteLine ("Weapon: " + player1.weapon.name);
			Console.WriteLine ("Armor: " + player1.armor.name);
			Console.WriteLine ("Inventory: ");
			if (Player.inventory.Count > 1) {
				for (int i = 0; i < Player.inventory.Count; i++) {
					Console.WriteLine ("\t\t" + Player.inventory [i].name);
				}
			} else if (Player.inventory.Count < 1) {
				Console.WriteLine ("empty");
			}
			Console.WriteLine ("Press enter to continue...");
			Console.ReadLine ();
			Console.Clear ();


		}
	}
}

