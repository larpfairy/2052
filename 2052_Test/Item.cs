using System;

namespace IntroCS
{
	public class Item
	{
		public string name { get; set; }
		public int ID { get; set; }
		public int value { get; set; }

		public Item (int id, string Name, int Value)
		{
			name = Name;
			ID = id;
			value = Value;
		}
	}
}

