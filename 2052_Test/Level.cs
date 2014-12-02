using System;

namespace IntroCS
{
	public class Level
	{
		public static void LevelUp(Player player1)
		{
			int level = 0;

			if (player1.experience >= 0 && player1.experience < 20) {
				level = 1;
			}
			else if (player1.experience >= 20 && player1.experience < 60) {
				level = 2;
			}
			else if (player1.experience >= 60 && player1.experience < 120) {
				level = 3;
			}
			else if (player1.experience >= 120 && player1.experience < 200) {
				level = 4;
			}

			if (level != player1.level) {
				player1.level = level;
				if (player1.playerClass == "Scientist") {
					player1.INT += 4;
					player1.STR += 2;
					player1.DEX += 2;
					player1.CON += 2;

					player1.maximumHealth += 5;
					player1.currentHealth = player1.maximumHealth;

					player1.willpower += 10;
					player1.initiative += 5;
				}
				else if (player1.playerClass == "Brawler") {
					player1.INT += 2;
					player1.STR += 4;
					player1.DEX += 2;
					player1.CON += 2;

					player1.maximumHealth += 7;
					player1.currentHealth = player1.maximumHealth;

					player1.willpower += 3;
					player1.initiative += 3;
				}
				else if (player1.playerClass == "Sniper") {
					player1.INT += 2;
					player1.STR += 2;
					player1.DEX += 4;
					player1.CON += 2;

					player1.maximumHealth += 5;
					player1.currentHealth = player1.maximumHealth;

					player1.willpower += 3;
					player1.initiative += 8;
				}
				Console.WriteLine ("You leveled up to level " + player1.level + "!");
			}
		}
	}
}

