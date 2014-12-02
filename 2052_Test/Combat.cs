using System;

namespace IntroCS
{
	public class Combat
	{
		public int defend {get;set;}
		public int defendcounter{ get; set;}

		public Combat()
		{
			defend = 0;
			defendcounter = 1;
		}

		public static void DoCombat(Player player1, Enemy enemy)
		{
			int playerd20;
			int enemyd20;
			string x;

			Random random = new Random ();

			Combat combat = new Combat ();

			playerd20 = random.Next (1, 21);

			enemyd20 = random.Next (1, 21);

			int playerinitiative = playerd20 + player1.initiative;
			int enemyinitiative = enemyd20 + enemy.initiative;

			Console.Clear ();
			Console.WriteLine ("Combat Encounter!!");
			Console.WriteLine ("An enemy " + enemy.name + " has appeared!");

			Console.WriteLine ("Press enter to continue...");
			Console.ReadLine ();

			int i = 0;
			while (i == 0) {
				if (playerinitiative > enemyinitiative) {
					if (enemy.health > 0) {
						Combat.PlayerCombat (player1, enemy, combat);
					
						x = Check (player1, enemy);
						if (x == "TRUE") {
							Enemy.Loot (player1, enemy);
							Console.Clear ();
							i++;

						}
					}
					if (enemy.health > 0) {
						Combat.EnemyCombat (player1, enemy, combat);
						x = Check (player1, enemy);
						if (x == "FALSE") {
							Combat.GameOver (player1);
						} else if (x == "TRUE") {
							Enemy.Loot (player1, enemy);
							Console.Clear ();
							i++;
						}
					}

				} 
				else if (enemyinitiative >= playerinitiative) {
					if (enemy.health > 0) {
						Combat.EnemyCombat (player1, enemy, combat);
						x = Combat.Check (player1, enemy);
						if (x == "FALSE") {
							Combat.GameOver (player1);
						}
						Combat.PlayerCombat (player1, enemy, combat);
					}
					x = Combat.Check (player1, enemy);
					if (x == "TRUE") {
						Enemy.Loot (player1, enemy);
						Console.Clear ();
						i++;
					}
				}
			}
			enemy.health = enemy.maxhealth;
		}

		public static void PlayerCombat(Player player1, Enemy enemy, Combat combat)
		{
			Console.Clear ();
			int playerd20;

			Random random = new Random ();
			int j = 0;
			while (j == 0) {
				Combat.CombatStats (player1, enemy);

				Console.WriteLine ("ATTACK");
				Console.WriteLine ("DEFEND");
				Console.WriteLine ("INVENTORY");
				Console.WriteLine ("AC" + (player1.armor.armorClass + combat.defend));
				string input = UI.PromptLine ("What would you like to do?");
				input = input.ToUpper ();

				if (input == "ATTACK") {
					j++;
					if (player1.weapon.Type == "STR") {
						playerd20 = random.Next (1, 21);
						int playerattack = playerd20 + (player1.STR / 4);

						if (playerattack >= enemy.armorClass) {
							Console.Clear ();
							Console.WriteLine ("You hit the enemy with your " + player1.weapon.name + "!");
							int damage = random.Next (player1.weapon.minDamage, player1.weapon.maxDamage + 1);
							enemy.health -= damage + (player1.STR / 4);
							Console.WriteLine ("It does " + (damage + (player1.STR / 4)) + " damage!");
							Console.ReadLine ();
						} else if (playerattack < enemy.armorClass) {
							Console.Clear ();
							Console.WriteLine ("Your attack missed :(");
							Console.ReadLine ();
						}

					}
					if (player1.weapon.Type == "DEX") {
						playerd20 = random.Next (1, 21);
						int playerattack = playerd20 + (player1.DEX / 4);

						if (playerattack >= enemy.armorClass) {
							Console.Clear ();
							Console.WriteLine ("You hit the enemy with your " + player1.weapon.name + "!");
							int damage = random.Next (player1.weapon.minDamage, player1.weapon.maxDamage + 1);
							enemy.health -= damage + (player1.DEX / 4);
							Console.WriteLine ("It does " + (damage + (player1.DEX / 4)) + " damage!");
							Console.ReadLine ();
						} else if (playerattack < enemy.armorClass) {
							Console.Clear ();
							Console.WriteLine ("Your attack missed :(");
							Console.ReadLine ();
						}
					}
					if (player1.weapon.Type == "INT") {
						playerd20 = random.Next (1, 21);
						int playerattack = playerd20 + (player1.INT / 4);

						if (playerattack >= enemy.willPower) {
							Console.Clear ();
							Console.WriteLine ("You hit the enemy with your " + player1.weapon.name + "!");
							int damage = random.Next (player1.weapon.minDamage, player1.weapon.maxDamage + 1);
							enemy.health -= (damage + (player1.INT / 4));
							Console.WriteLine ("It does " + (damage + (player1.INT / 4)) + " damage!");
							Console.ReadLine ();
						} else if (playerattack < enemy.willPower) {
							Console.Clear ();
							Console.WriteLine ("Your attack was negated :(");
							Console.ReadLine ();
						}
					}

				} else if (input == "DEFEND") {
					j++;
					combat.defend += (4 / combat.defendcounter);
					Console.WriteLine ("Your defense has been raised!");
					combat.defendcounter++;
					Console.ReadLine ();
				} else if (input == "INVENTORY") {
					Console.Clear ();
					j++;
					Inventory.DoInventory (player1);
				} else {
					Console.Clear ();
					Console.WriteLine ("I can't understand you");
					Console.ReadLine ();
					Console.Clear ();
				}
			}
		}


		public static void EnemyCombat(Player player1, Enemy enemy, Combat combat)
		{
			Console.Clear ();

			Combat.CombatStats (player1, enemy);

			int enemyd20;

			Random random = new Random ();

			Console.WriteLine (enemy.name + " is attacking...");
			Console.ReadLine ();

			enemyd20 = random.Next (1, 21);
			int enemyattack = enemyd20 + enemy.attackModifier;

			if (enemy.weaponType == "STR" || enemy.weaponType == "DEX") {
				if (enemyattack >= player1.armor.armorClass + combat.defend) {
					Console.WriteLine ("The " + enemy.name + " hits you with " + enemy.weaponName + "!");
					int damage = random.Next (enemy.weaponMin, enemy.weaponMax + 1);
					player1.currentHealth -= damage;
					Console.WriteLine ("You take " + damage + " damage!");
					Console.ReadLine ();
				} else if (enemyattack < player1.armor.armorClass + combat.defend) {
					Console.WriteLine ("The attack missed!");
					Console.ReadLine ();
				}
			} else if (enemy.weaponType == "INT") {
				if (enemyattack >= player1.willpower) {
					Console.WriteLine ("The " + enemy.name + " hits you with " + enemy.weaponName + "!");
					int damage = random.Next (enemy.weaponMin, enemy.weaponMax + 1);
					player1.currentHealth -= damage;
					Console.WriteLine ("You take " + damage + " damage!"); 
					Console.ReadLine ();
				} else if (enemyattack < player1.willpower) {
					Console.WriteLine ("The attack missed!");
					Console.ReadLine ();
				}
			}
		}
		public static string Check(Player player1, Enemy enemy)
		{
			if (player1.currentHealth < 1) {
				return "FALSE";
			} else if (enemy.health < 1) {
				return "TRUE";
			} else {
				return "NULL";
			}
		}
		public static void GameOver(Player player1)
		{
			Console.WriteLine ("You died");
			int i = 0;
			while (i == 0) {
				string input = Console.ReadLine ();
				if (input == "continue") {
					player1.currentHealth = player1.maximumHealth;
					i++;
				}
			}
		}
		public static void CombatStats(Player player1, Enemy enemy)
		{
			Console.WriteLine (player1.name + "\t\t\t" + enemy.name);
			Console.WriteLine ("Health: " + player1.currentHealth + "\t\t\t" + "Health: " + enemy.health);
		}
	}
}

