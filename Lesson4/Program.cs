while (true)
{
	int a, b, coef;
	bool isAGreaterThanB;
	Console.WriteLine("Введите диапазон чисел (2 числа):");

	//Единственный if
	if (!int.TryParse(Console.ReadLine(), out a) || !int.TryParse(Console.ReadLine(), out b))
	{
		Console.WriteLine("Ошибка! Это не число, либо число слишком большое!");
	}
	else
	{
		isAGreaterThanB = a > b;
		coef = (isAGreaterThanB) ? -1 : 1;

		a = (a % 2 == 0) ? a : a + coef;

		Console.Write($"Чётные числа: {a}");

		a += 2 * coef;

		for (; (isAGreaterThanB) ? (b <= a) : (a <= b); a += 2 * coef)
		{
			Console.Write($", {a}");
		}
		Console.WriteLine("\n");
	}
}