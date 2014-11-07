using System;

namespace IntroCS
{
	public class Salve:Item
	{
		public int healingvalue;

		public Salve (int id, string name, int Value, int HealingValue):base(id,name,Value)
		{
			healingvalue = HealingValue;
		}
	}
}

