int num = 0,
sum = 0,
count = 0,
min = int.MaxValue,
max = int.MinValue,
average;
Console.WriteLine("Введите числа. Закончите ввод числом -999");


while (true)
{
	if (int.TryParse(Console.ReadLine(), out num))
	{
		if (num == -999)
		{
			break;
		}
		sum += num;
		count++;
		min = (min > num) ? num : min;
		max = (max < num) ? num : max;
        average = sum / count;
        Console.WriteLine(	$"Минимальная температура = {min},\n" +
                            $"Максимальная температура = {max},\n" +
                            $"Средняя температура = {average}");
    }
	else
	{
		Console.WriteLine("Ошибка! Это не число, либо число слишком большое!");
	}
}
