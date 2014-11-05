using System;

namespace IntroCS
{
	public class Enemy
	{
		public int level { get; set; }
		public int health { get; set; }
		public string name { get; set; }
		public int attack { get; set; }
		public int damage { get; set; }
		public int ID { get; set; }


		public Enemy (int id, int Level, int Health, string Name, int Attack, int Damage)
		{
			ID = id;
			level = Level;
			health = Health;
			name = Name;
			attack = Attack;
			damage = Damage;
		}
	}
}

