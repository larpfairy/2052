using System;

namespace IntroCS
{
	public class Weapon:Item
	{
		public int maxDamage { get; set;}
		public int minDamage { get; set;}
		public string Type { get; set;}

		public Weapon (int id, string Name, int Value, int mindamage, int maxdamage, string type) : base(id, Name, Value)
		{
			maxDamage = maxdamage;
			minDamage = mindamage;
			Type = type;
		}
	}
}

