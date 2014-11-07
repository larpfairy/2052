using System;
using System.Collections.Generic;

namespace IntroCS
{
	public class Enemy
	{
		public int level { get; set; }
		public int health { get; set; }
		public string name { get; set; }
		public int weaponMax { get; set; }
		public int weaponMin{ get; set; }
		public int ID { get; set; }
		public int initiative { get; set; }
		public int experience { get; set; }
		public int attackModifier { get; set; }
		public int armorClass { get; set; }
		public int willPower { get; set; }

		public Enemy (int id, int Level, int Health, string Name, int attackmodifier, int weaponmax, int weaponmin, int armorclass, int willpower, int Initiative, int Experience)
		{
			ID = id;
			level = Level;
			health = Health;
			name = Name;
			attackModifier = attackmodifier;
			weaponMax = weaponmax;
			weaponMin = weaponmin;
			armorClass = armorclass;
			initiative = Initiative;
			experience = Experience;
			willPower = willpower;

		}
		public Enemy GetRandomEnemyByLevel (Player player1)
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
	}
}

