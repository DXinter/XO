using System;

namespace XO
{
	internal class Program
	{
		const string INPUT_FIRST_PLAYER_NAME = "Введите имя первого игрока:";
		const string INPUT_SECOND_PLAYER_NAME = "Введите имя второго игрока:";
		const string INVALID_POSITION = "Такой позиции не существует! Введите цифру (от 1 до 9)\n";
		const string INVALID_TURN = "Ход в данное место невозможен! \n";
		const string MAKE_SURE_IN_CORRECT_INPUT = "Убедитесь в правильности ввода!\n";
		const string DRAW = "У вас ничья!";

		const char FIRST_TURN = 'X';
		const char SECOND_TURN = '0';

		private static void Main()
		{
			var player1 = GetPlayerName(INPUT_FIRST_PLAYER_NAME);
			var player2 = GetPlayerName(INPUT_SECOND_PLAYER_NAME);

			Play(player1, player2);
		}

		private static string GetPlayerName(string welcomeText)
		{
			var playerName = string.Empty;

			while (string.IsNullOrEmpty(playerName))
			{
				Console.WriteLine(welcomeText);
				playerName = Console.ReadLine();
			}

			return playerName;
		}

		private static void Play(string p1, string p2)
		{
			char[] field = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };

			while (true)
			{
				Show(field);

				if (CheckWinner(field, SECOND_TURN))
				{
					Console.WriteLine($"Победил {p2}!\n");
					Console.ReadLine();
					break;
				}

				//ход первого игрока
				MakeTurn(p1, FIRST_TURN, field);

				Console.Clear();

				Show(field);

				if (CheckWinner(field, FIRST_TURN))
				{
					Console.WriteLine($"Победил {p1}!");
					Console.ReadLine();
					break;
				}

				//ход второго игрока
				MakeTurn(p2, SECOND_TURN, field);

				Draw(field);

				Console.Clear();
			}
		}

		private static void MakeTurn(string playerName, char turn, char[] field)
		{
			bool isFailureTurn = true;
			while (isFailureTurn)
			{
				Console.WriteLine($"Ход игрока {playerName}, вы ставите '{turn}'. Поставьте цифру (от 1 до 9).");
				bool parse = int.TryParse(Console.ReadLine(), out int position);
				if (parse)
				{
					if (position > field.Length || position <= 0)
					{
						Console.WriteLine(INVALID_POSITION);
						continue;
					}

					if (position <= field.Length)
					{
						if (field[position - 1] != '-')
						{
							Console.WriteLine(INVALID_TURN);
							continue;
						}

						field[position - 1] = turn;
					}
				}
				else
				{
					Console.WriteLine(MAKE_SURE_IN_CORRECT_INPUT);
					continue;
				}

				isFailureTurn = false;
			}
		}

		private static bool CheckWinner(char[] field, char turn)
		{
			return field[0].Equals(turn) && field[1].Equals(turn) && field[2].Equals(turn) ||
				   field[0].Equals(turn) && field[3].Equals(turn) && field[6].Equals(turn) ||
				   field[0].Equals(turn) && field[4].Equals(turn) && field[8].Equals(turn) ||
				   field[3].Equals(turn) && field[4].Equals(turn) && field[5].Equals(turn) ||
				   field[6].Equals(turn) && field[7].Equals(turn) && field[8].Equals(turn) ||
				   field[6].Equals(turn) && field[4].Equals(turn) && field[2].Equals(turn) ||
				   field[1].Equals(turn) && field[4].Equals(turn) && field[7].Equals(turn) ||
				   field[2].Equals(turn) && field[5].Equals(turn) && field[8].Equals(turn);
		}

		private static void Draw(char[] field)
		{
			//ничья
			int sum = 9;
			foreach (char item in field)
			{
				if (item != '-')
					sum--;
				if (sum <= 1)
				{
					Console.WriteLine(DRAW);
					Console.ReadLine();
					break;
				}
			}
		}


		private static void Show(char[] field)
		{
			Console.WriteLine("***************");
			Console.WriteLine($"== {field[0]} | {field[1]} | {field[2]} ==");
			Console.WriteLine($"== {field[3]} | {field[4]} | {field[5]} ==");
			Console.WriteLine($"== {field[6]} | {field[7]} | {field[8]} ==");
			Console.WriteLine("***************");
		}
	}
}
