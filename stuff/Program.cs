using System.Text;

class Program
{

	//Управление стрелками
	static void Program1()
	{
		bool[][] field = new bool[10*3][];
		for (int i = 0; i < field.Length; i++)
		{
			field[i] = new bool[20*3];
		}
		field[5][5] = true;
		Console.CursorVisible = false;
		for (int i = 0; i < field.Length; i++)
		{
			for (int j = 0; j < field[i].Length; j++)
			{
				Console.Write((field[i][j]) ? '#' : '.');
			}
			Console.WriteLine();
		}
		
		while (true)
		{
			Console.SetCursorPosition(0, 0);
			ConsoleKey key = Console.ReadKey().Key;
			switch (key)
			{
				case ConsoleKey.LeftArrow:
				{
					bool isFound = true;
					for (int i = 0; i < field.Length && isFound; i++)
					{
						for (int j = 0; j < field[i].Length && isFound; j++)
						{
							if (field[i][j])
							{
								if (j > 0)
								{
									field[i][j - 1] = true;
									field[i][j] = false;
								}
								isFound = false;
							}
						}
					}
					break;
				}
				case ConsoleKey.RightArrow:
				{
					bool isFound = true;
					for (int i = 0; i < field.Length && isFound; i++)
					{
						for (int j = 0; j < field[i].Length && isFound; j++)
						{
							if (field[i][j])
							{
								if (j < field[i].Length - 1)
								{
									field[i][j + 1] = true;
									field[i][j] = false;
								}
								isFound = false;
							}
						}
					}
					break;
				}
				case ConsoleKey.UpArrow:
				{
					bool isFound = true;
					for (int i = 0; i < field.Length && isFound; i++)
					{
						for (int j = 0; j < field[i].Length && isFound; j++)
						{
							if (field[i][j])
							{
								if (i > 0)
								{
									field[i - 1][j] = true;
									field[i][j] = false;
								}
								isFound = false;
							}
						}
					}
					break;
				}
				case ConsoleKey.DownArrow:
				{
					bool isFound = true;
					for (int i = 0; i < field.Length && isFound; i++)
					{
						for (int j = 0; j < field[i].Length && isFound; j++)
						{
							if (field[i][j])
							{
								if (i < field.Length - 1)
								{
									field[i + 1][j] = true;
									field[i][j] = false;
								}
								isFound = false;
							}
						}
					}
					break;
				}
				default: { break; }
			}
			for (int i = 0; i < field.Length; i++)
			{
				for (int j = 0; j < field[i].Length; j++)
				{
					Console.Write((field[i][j]) ? '#' : '.');
				}
				Console.WriteLine();
			}
		}
	}
	//Круг
	static void Program2()
	{
		for (int i = 15; i >= -15; i--)
		{
			for (int j = -30; j <= 30; j++) 
			{
				double x = (double)j / 30;
				double y = (double)i / 15;
	
				char symbol = (((Math.Sin(Math.Acos(x)) - Math.Abs(y) >= 0) && (Math.Sin(Math.Acos(x)) - Math.Abs(y) <= 0.9)) && ((Math.Cos(Math.Asin(y)) - Math.Abs(x) >= 0) && (Math.Cos(Math.Asin(y)) - Math.Abs(x) <= 0.9))) ? '#' : ' ';
				Console.Write(symbol);
			}
			Console.WriteLine();
		}
	}
	//Аналоговые часы
	static void Program3()
	{
		Console.SetWindowSize(98, 50);
		Console.SetBufferSize(98, 50);
		Console.OutputEncoding = Encoding.Unicode;
		Console.CursorVisible = false;
	
		double x, y;
		DateTime now = DateTime.Now;
	
		while (true)
		{
			if (now.Millisecond % 100 != 0)
			{
				now = DateTime.Now;
				continue;
			}
			
			Console.SetWindowSize(98, 50);
			Console.OutputEncoding = Encoding.Unicode;
			Console.CursorVisible = false;
			Console.Clear();
			now = DateTime.Now;
			double step = 0.02;
	
			#region Секундная стрелка
			x = Math.Cos(((now.Second - 15) + ((double)now.Millisecond) / 1000.0) * double.Pi / 30) * 45.0;
			y = Math.Sin(((now.Second - 15) + ((double)now.Millisecond) / 1000.0) * double.Pi / 30) * 45.0 / 2;
			for (double i = 1; i <= 16 && Console.WindowWidth >= 98 && Console.WindowHeight >= 50; i += step)
			{
				Console.SetCursorPosition((int)(x / i) + 48, (int)(y / i) + 24);
				Console.Write("██");
				step *= 1.1;
			}
			step = 0.02;
			#endregion
	
			#region Минутная стрелка
			x = Math.Cos(((now.Minute - 15) + ((double)now.Second / 60)) * double.Pi / 30) * 36;
			y = Math.Sin(((now.Minute - 15) + ((double)now.Second / 60)) * double.Pi / 30) * 18;
			for (double i = 1; i <= 16 && Console.WindowWidth >= 98 && Console.WindowHeight >= 50; i += step)
			{
				Console.SetCursorPosition((int)(x / i) + 48, (int)(y / i) + 24);
				Console.Write("▒▒");
				step *= 1.1;
	
			}
			step = 0.02;
			#endregion
	
			#region Часовая стрелка
			x = Math.Cos(((now.Hour % 12 - 3) + (double)now.Minute / 60) * double.Pi / 6) * 24;
			y = Math.Sin(((now.Hour % 12 - 3) + (double)now.Minute / 60) * double.Pi / 6) * 12;
			for (double i = 1; i <= 16 && Console.WindowWidth >= 98 && Console.WindowHeight >= 50; i += step)
			{
				Console.SetCursorPosition((int)(x / i) + 48, (int)(y / i) + 24);
				Console.Write("▓▓");
				step *= 1.1;
	
			}
			step = 0.02;
			#endregion
	
			#region Центр
			Console.SetCursorPosition(46, 23);
			Console.Write("█▀▀▀▀█");
			Console.SetCursorPosition(46, 24);
			Console.Write("█ ██ █");
			Console.SetCursorPosition(46, 25);
			Console.Write("█▄▄▄▄█");

			#endregion
	
			#region Циферблат
			for (int i = 1; i <= 12 && Console.WindowWidth >= 98 && Console.WindowHeight >= 50; i++)
			{
				x = Math.Cos((i - 3) * double.Pi / 6.0) * 48;
				y = Math.Sin((i - 3) * double.Pi / 6.0) * 24;
	
				Console.SetCursorPosition((int)(x) + 48, (int)(y) + 24);
				Console.Write(i);
			}
			#endregion
	
			
		}
	}
	
	//Цифровые часы
	static void Program4()
	{
		string[,] symbol_set = new string[11, 8];
		string[] input = new string[8];
		//Console.OutputEncoding = Encoding.Unicode;
	
		input = File.ReadAllLines("numbers.set");
	
		for (int i = 0; i < 11; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				symbol_set[i, j] = input[j].Substring(12 * i, 12);
			}
		}
	
		Console.SetWindowSize(12 * 8 + 2 * 3 + 4, 10);
		Console.SetBufferSize(12 * 8 + 2 * 3 + 4, 10);
		Console.CursorVisible = false;
	
		DateTime now = DateTime.Now;
		int[] time_numbers = new int[6];
	
		while (true)
		{
			if (now.Second == DateTime.Now.Second)
			{
				continue;
			}
			Console.SetWindowSize(12 * 8 + 2 * 3 + 4, 10);
			Console.SetBufferSize(12 * 8 + 2 * 3 + 4, 10);
			Console.CursorVisible = false;
	
	
			now = DateTime.Now;
	
			time_numbers[0] = now.Hour / 10;
			time_numbers[1] = now.Hour % 10;
			time_numbers[2] = now.Minute / 10;
			time_numbers[3] = now.Minute % 10; 
			time_numbers[4] = now.Second / 10;
			time_numbers[5] = now.Second % 10;
	
			for (int i = 0, k = 0; i < 6; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (i % 2 == 0 && i != 0)
					{
						if (j == 0)
						{
							k++;
						}
						Console.SetCursorPosition(12 * i + 2 * (i - k + 1) + (k - 1) * 12, j + 1);
						Console.Write(symbol_set[10, j]);
					}
					Console.SetCursorPosition(12 * i + 2 * (i + 1 - k) + k * 12, j + 1);
					Console.Write(symbol_set[time_numbers[i], j]);
				}
			}
		}
	}

	enum TicTacToeSymbols
	{
		Cross = 0,
		Ring = 1,
		None = 2
	};
	//Крестики-Нолики
	static void Program5()
	{
		TicTacToeSymbols[,] field = {
			{TicTacToeSymbols.None, TicTacToeSymbols.None, TicTacToeSymbols.None},
			{TicTacToeSymbols.None, TicTacToeSymbols.None, TicTacToeSymbols.None},
			{TicTacToeSymbols.None, TicTacToeSymbols.None, TicTacToeSymbols.None}
		};

        bool isRingTurn = true;
        int[] cursor_pos = new int[2];
        byte turnCount = 0;
        while (true)
		{
			Console.SetCursorPosition(0, 0);
			Console.CursorVisible = true;
			Console.Clear();

			#region Отрисовываем поле
			for (int i = 0; i < 3; i++)
			{
				char[] symbol_char = new char[3];
				for (int j = 0; j < 3; j++)
				{
					if (field[i,j] == TicTacToeSymbols.None)
					{
						symbol_char[j] = ' ';
					} 
					else if (field[i, j] == TicTacToeSymbols.Ring)
					{
						symbol_char[j] = 'O';
					}
					else if (field[i, j] == TicTacToeSymbols.Cross)
					{
						symbol_char[j] = 'X';
					}
				}
				Console.WriteLine("-------");
				Console.WriteLine($"|{symbol_char[0]}|{symbol_char[1]}|{symbol_char[2]}|");
			}
			Console.WriteLine("-------");
			Console.SetCursorPosition(cursor_pos[0], cursor_pos[1]);
			#endregion

			#region Обрабатываем ход
			cursor_pos[0] = Console.GetCursorPosition().Left;
			cursor_pos[1] = Console.GetCursorPosition().Top;

			bool isEnter = false;

			while (!isEnter)
			{
				ConsoleKey key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.LeftArrow:
						{
							if (cursor_pos[0] > 0)
							{
								cursor_pos[0]--;
								Console.SetCursorPosition(cursor_pos[0], cursor_pos[1]);
							}
							break;
						}
					case ConsoleKey.RightArrow:
						{
							if (cursor_pos[0] < 6)
							{
								cursor_pos[0]++;
								Console.SetCursorPosition(cursor_pos[0], cursor_pos[1]);
							}
							break;
						}
					case ConsoleKey.UpArrow:
						{
							if (cursor_pos[1] > 0)
							{
								cursor_pos[1]--;
								Console.SetCursorPosition(cursor_pos[0], cursor_pos[1]);
							}
							break;
						}
					case ConsoleKey.DownArrow:
						{
							if (cursor_pos[1] < 6)
							{
								cursor_pos[1]++;
								Console.SetCursorPosition(cursor_pos[0], cursor_pos[1]);
							}
							break;
						}
					case ConsoleKey.Enter:
						{
							Console.SetCursorPosition(cursor_pos[0], cursor_pos[1]);
							if (cursor_pos[0] % 1 == 1 && cursor_pos[1] % 1 == 1)
							{
								break;
							}
							isEnter = true;
							break;
						}
					default:
						{
							break;
						}
				}
			}
			#endregion
			if (field[cursor_pos[1] / 2, (cursor_pos[0]) / 2] == TicTacToeSymbols.None)
			{
				field[cursor_pos[1] / 2, (cursor_pos[0]) / 2] = (isRingTurn) ? TicTacToeSymbols.Ring : TicTacToeSymbols.Cross;
				isRingTurn = !isRingTurn;
			}
			#region Проверяем поле на победителя
			TicTacToeSymbols winner = TicTacToeSymbols.None;



			TicTacToeSymbols symbol = field[0, 0];
			if (symbol != TicTacToeSymbols.None)
			{
				if (field[0, 1] == symbol && field[0, 2] == symbol)
				{
					winner = symbol;
				}
				if (field[1, 0] == symbol && field[2, 0] == symbol)
				{
					winner = symbol;
				}
			}

            symbol = field[2, 2];
			if (symbol != TicTacToeSymbols.None)
			{
				if (field[2, 1] == symbol && field[2, 0] == symbol)
				{
					winner = symbol;
				}
				if (field[1, 2] == symbol && field[0, 2] == symbol)
				{
					winner = symbol;
				}
			}
			
			symbol = field[1, 1];
			if (symbol != TicTacToeSymbols.None)
			{
				if (field[0, 0] == symbol && field[2, 2] == symbol)
				{
					winner = symbol;
				}
				if (field[2, 0] == symbol && field[0, 2] == symbol)
				{
					winner = symbol;
				}

				if (field[1, 0] == symbol && field[1, 2] == symbol)
				{
				    winner = symbol;
				}
				if (field[2, 1] == symbol && field[0, 1] == symbol)
				{
				    winner = symbol;
				}
			}
            if (winner == TicTacToeSymbols.None && turnCount++ >= 8)
            {
				turnCount = 0;
                Console.SetCursorPosition(0, 7);
                Console.Write("Ничья");
                Console.ReadKey();
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        field[i, j] = TicTacToeSymbols.None;
                    }
                }
            }
            #endregion

            #region Действие, если есть победитель
            if (winner != TicTacToeSymbols.None)
			{
                turnCount = 0;
                Console.SetCursorPosition(0, 7);
				Console.Write("Победитель - " + ((winner == TicTacToeSymbols.Ring) ? "Нолики" : "Крестики"));
				Console.ReadKey();
                for (int i = 0; i < field.GetLength(0); i++)
				{
					for (int j = 0; j < field.GetLength(1); j++)
					{
						field[i, j] = TicTacToeSymbols.None;
					}
				}
            }
			#endregion
		}
	}

	//The Life Game
	static byte field_w = 80, field_h = 40;
	static void Program6()
	{
        Console.SetBufferSize(field_w * 2 * 4, field_h * 4);

		bool[,] field_prev = new bool[field_h, field_w];
        bool[,] field = new bool[field_h, field_w];
		int[] cursor_pos = new int[] { 0, 0 };

		//bool isPause = false;
		//int waitTime = 1000;

        while (true)
		{
			#region Отрисовка поля
			Console.CursorVisible = false;
			Console.SetCursorPosition(0, 0);
            for (int i = 0; i < field_w + 2; i++)
            {
                Console.Write("██");
            }
            Console.WriteLine();

            for (int i = 1; i < field_h + 1; i++)
            {
                Console.Write("██");
                for (int j = 1; j < field_w + 1; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine("██");
            }

            for (int i = 0; i < field_w + 2; i++)
            {
                Console.Write("██");
            }
            Console.WriteLine();
            #endregion

            #region Отрисовка клеток
            Console.CursorVisible = false;
            for (int i = 0; i < field_h; i++)
            {
                for (int j = 0; j < field_w; j++)
                {
                    if (field[i, j])
                    {
                        Console.SetCursorPosition(j * 2 + 2, i + 1);
                        Console.Write((field[i, j]) ? "██" : "  ");
                    }
                }
            }
            #endregion

            #region Ввод пользователя
            bool isWaitForKey = true;

				ConsoleKey key;
				Console.SetCursorPosition(cursor_pos[1]*2 + 2, cursor_pos[0] + 1);
				Console.Write("▒{0}", field[cursor_pos[0], cursor_pos[1]] ? "█" : " ");
				Console.SetCursorPosition(field_h + 3, 0);
				key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.Enter:
						{
							field[cursor_pos[0], cursor_pos[1]] = !field[cursor_pos[0], cursor_pos[1]];
							break;
                        }
					case ConsoleKey.LeftArrow:
						{
                            Console.SetCursorPosition(cursor_pos[1] * 2 + 2, cursor_pos[0] + 1);
                            Console.Write((field[cursor_pos[0], cursor_pos[1]]) ? "██" : "  ");
                            cursor_pos[1]--;
							if (cursor_pos[1] < 0)
							{
								cursor_pos[1]++;
							}
							break;
						}
                    case ConsoleKey.RightArrow:
                        {
                            Console.SetCursorPosition(cursor_pos[1] * 2 + 2, cursor_pos[0] + 1);
                            Console.Write((field[cursor_pos[0], cursor_pos[1]]) ? "██" : "  ");
                            cursor_pos[1]++;
                            if (cursor_pos[1] == field_w)
                            {
                                cursor_pos[1]--;
                            }
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            Console.SetCursorPosition(cursor_pos[1] * 2 + 2, cursor_pos[0] + 1);
                            Console.Write((field[cursor_pos[0], cursor_pos[1]]) ? "██" : "  ");
                            cursor_pos[0]--;
                            if (cursor_pos[0] < 0)
                            {
                                cursor_pos[0]++;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            Console.SetCursorPosition(cursor_pos[1] * 2 + 2, cursor_pos[0] + 1);
                            Console.Write((field[cursor_pos[0], cursor_pos[1]]) ? "██" : "  ");
                            cursor_pos[0]++;
                            if (cursor_pos[0] == field_h)
                            {
                                cursor_pos[0]--;
                            }
                            break;
                        }
                    case ConsoleKey.Spacebar:
						{
							isWaitForKey = false;
							break;
						}
				}

            #endregion

            #region Логика
			if (!isWaitForKey)
			{
				for (int i = 0; i < field_h; i++)
				{
				    for (int j = 0; j < field_w; j++)
				    {
				        field_prev[i, j] = field[i, j];
				    }
				}

				for (int i = 0; i < field_h; i++)
				{
					for (int j = 0; j < field_w; j++)
					{
						bool isAlive = false;
						byte nearAlive = 0;
						for (int k = -1; k <= 1; k++)
						{
							for (int l = -1; l <= 1; l++)
							{
								int x, y;
								if (k == 0 && l == 0)
								{
									continue;
								}

								if (k + i < 0)
								{
									y = field_h - 1;
								} 
								else if(k + i >= field_h)
								{
									y = 0;
								}
								else
								{
									y = i + k;
								}
				                if (l + j < 0)
				                {
				                    x = field_w - 1;
				                }
				                else if (l + j >= field_w)
				                {
				                    x = 0;
				                }
								else
								{
									x = j + l;
								}

								if (field_prev[y, x])
								{
									nearAlive++;
								}
				            }
						}
						if (nearAlive == 3)
						{
							isAlive = true;
						} 
						else if (nearAlive == 2 && field_prev[i, j])
						{
							isAlive = true;
						}

						field[i, j] = isAlive;
					}
				}
			}
            #endregion

        }
    }

    static void Main(string[] args)
	{

		Console.WriteLine(	"Выберите программу:\n" +
							"1 - Управление стрелками\n" +
							"2 - Круг\n" +
							"3 - Аналоговые часы\n" +
							"4 - Цифровые часы\n" +
							"5 - Крестики-Нолики\n" +
                            "6 - The Life Game\n");

		char choice = Console.ReadKey().KeyChar;
		Console.Clear();
		switch (choice)
		{
		case '1':
			{
				Program1();
				break;
			}
		case '2':
			{
				Program2();
				break;
			}
		case '3':
			{
				Program3();
				break;
			}
		case '4':
			{
				Program4();
				break;
			}
		case '5':
			{
				Program5();
				break;
			}
        case '6':
            {
                Program6();
                break;
            }
            default:
			{
				Main(args);
				break;
			}
		}
	}
}