using System;
using System.Collections.Generic;

namespace IntroCS
{
	public class Enemy
	{
		public int level { get; set; }
		public int health { get; set; }
		public int maxhealth { get; set; }
		public string name { get; set; }
		public int weaponMax { get; set; }
		public int weaponMin{ get; set; }
		public string weaponName { get; set; }
		public string weaponType{ get; set; }
		public int ID { get; set; }
		public int initiative { get; set; }
		public int experience { get; set; }
		public int attackModifier { get; set; }
		public int armorClass { get; set; }
		public int willPower { get; set; }
		public int Value { get; set; }

		public Enemy (int id, int Level, int Health, int MaxHealth, string Name, int attackmodifier, int weaponmax, int weaponmin, string weaponname, string weapontype, int armorclass, int willpower, int Initiative, int Experience, int value)
		{
			ID = id;
			level = Level;
			health = Health;
			maxhealth = MaxHealth;
			name = Name;
			attackModifier = attackmodifier;
			weaponMax = weaponmax;
			weaponMin = weaponmin;
			armorClass = armorclass;
			initiative = Initiative;
			experience = Experience;
			willPower = willpower;
			weaponName = weaponname;
			weaponType = weapontype;
			Value = value;

		}
		public static Enemy GetRandomEnemyByLevel (Player player1)
		{
			var enemylist = new List<Enemy> ();
			for (int i = 0; i < World.Enemies.Count; i++) {
				if (World.Enemies [i].level == 1) {
					enemylist.Add (World.Enemies [i]);
				}
			}
			Random random = new Random ();
			return enemylist [random.Next (0, enemylist.Count)];
		}

		public static void Loot(Player player1, Enemy enemy)
		{
			Console.Clear ();
			Console.WriteLine ("You killed the " + enemy.name + "!");
			player1.experience += enemy.experience;
			Console.WriteLine ("You gain " + enemy.experience + " experience!");
			Console.WriteLine ("You find " + enemy.Value + " credits on the " + enemy.name + ".");
			player1.Value += enemy.Value;

			Level.LevelUp (player1);

			Console.WriteLine ("Press enter to continue...");
			Console.ReadLine ();
		}
	}
}

