using System;

namespace IntroCS
{
	public class Armor:Item
	{
		public int armorClass { get; set; }

		public Armor (int id, string name, int ArmorClass):base(id,name)
		{
			armorClass = ArmorClass;
		}
	}
}

