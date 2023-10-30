/*
 *  модификатор
 *   vvvvvv
    (static) возращаемый_тип имя(тип имя_аргумента, тип имя_аргумента...){
        тело
        (return значение)
    }
*/


static string Information(int a, int b)
{
    if (a - b > 0)
    {
        return "Разность положительна";
    } 
    else if (a - b < 0)
    {
        return "Разность отрицательна";
    }
    else
    {
        return "Разность равна нулю";
    }
}
Console.Write("Введите первое число: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите второе число: ");
int b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Информация о разности {a} и {b} - " + Information(a, b));

