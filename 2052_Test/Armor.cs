using System;

namespace IntroCS
{
	public class Armor:Item
	{
		public int armorClass { get; set; }
		public string armorType { get; set; }

		public Armor (int id, string name, int value, int ArmorClass, string armortype):base(id,name,value)
		{
			armorClass = ArmorClass;
			armorType = armortype;
		}
	}
}

