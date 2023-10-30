int[] startArray = {1, 2, 3, 4, 5, 6, 7, 8, 7,7,99,97};

for (int i = 0; i < startArray.Length; i++)
{
    Console.Write($"{startArray[i]} ");
}
Console.WriteLine();
Console.Write("Введите то, чем хотите заменить нечётные числа: ");

string replaceWith = Console.ReadLine();
string[] replacedArray = new string[startArray.Length];

for (int i = 0;i < replacedArray.Length; i++)
{
    replacedArray[i] = (startArray[i] % 2 == 0) ? startArray[i].ToString() : replaceWith;
}

for (int i = 0; i < replacedArray.Length; i++)
{
    Console.Write($"{replacedArray[i]} ");
}
