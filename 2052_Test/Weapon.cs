using System;

namespace IntroCS
{
	public class Weapon:Item
	{
		public int maxDamage { get; set;}
		public int minDamage { get; set;}

		public Weapon (int id, string Name, int mindamage, int maxdamage) : base(id, Name)
		{
			maxDamage = maxdamage;
			minDamage = mindamage;
		}
	}
}

