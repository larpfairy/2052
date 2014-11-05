using System;

namespace IntroCS
{
	public class Item
	{
		public string name { get; set; }
		public int ID { get; set; }

		public Item (int id, string Name)
		{
			name = Name;
			ID = id;
		}
	}
}

