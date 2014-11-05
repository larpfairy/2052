using System;

namespace IntroCS
{
	public class Salve:Item
	{
		public int healingvalue;

		public Salve (int id, string name, int HealingValue):base(id,name)
		{
			healingvalue = HealingValue;
		}
	}
}

