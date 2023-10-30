while (true)
{
    int first_num, second_num;
    Console.Write("Введите первое число: ");
    if (!int.TryParse(Console.ReadLine(), out first_num))
    {
        Console.WriteLine("Ошибка! Это не является числом, либо число слишком большое!");
        continue;
    }
    Console.Write("Введите второе число: ");
    if (!int.TryParse(Console.ReadLine(), out second_num))
    {
        Console.WriteLine("Ошибка! Это не является числом, либо число слишком большое!");
        continue;
    }

    if (first_num == second_num)
    {
        Console.WriteLine($"Числа равны и кратны друг другу\n");
    } 
    else if (first_num % second_num == 0) {
        Console.WriteLine($"Число {first_num} кратно числу {second_num}\n");
    }
    else if (second_num % first_num == 0)
    {
        Console.WriteLine($"Число {second_num} кратно числу {first_num}\n");
    }
    else
    {
        Console.WriteLine($"Числа не кратны друг другу\n");
    }
}