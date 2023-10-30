int[,] a = new int[,] {
    {11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, -24, 22, 11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, 24, 22, 11, 43, 243, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, 24, 22, 1122, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22},
    {11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22, 11, 43, 24, 22}
};

int longestInt = 0;
for (int i = 0; i < a.GetLength(0); i++)
{
    for (int j = 0; j < a.GetLength(1); j++)
    {
        longestInt = (a[i, j].ToString().Length > longestInt) ? a[i, j].ToString().Length : longestInt;
    }
}


for (int i = 0; i < a.GetLength(0); i++)
{
    for (int j = 0; j < a.GetLength(1); j++)
    {
        Console.Write("-");
        for (int k = 0; k < longestInt; k++)
        {
            Console.Write("-");
        }
    }
    Console.WriteLine("-");
    for (int j = 0; j < a.GetLength(1); j++)
    {
        Console.Write($"|{a[i, j]}");
        for (int k = 0; k < longestInt - a[i, j].ToString().Length; k++)
        {
            Console.Write(' ');
        }

    }
    Console.WriteLine("|");

}
for (int i = 0; i < a.GetLength(1); i++)
{
    Console.Write("-");
    for (int j = 0; j < longestInt; j++)
    {
        Console.Write("-");
    }
}
Console.WriteLine("-");