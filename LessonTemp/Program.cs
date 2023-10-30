static byte[] ConvertHexToRGB(string hexColor)
{
    if (hexColor.Length == 4)
    {
        hexColor = "#" + hexColor[1] + hexColor[1] + hexColor[2] + hexColor[2] + hexColor[3] + hexColor[3];
    }

    byte red = Convert.ToByte(hexColor.Substring(1, 2), 16);
    byte green = Convert.ToByte(hexColor.Substring(3, 2), 16);
    byte blue = Convert.ToByte(hexColor.Substring(5, 2), 16);

    return new byte[] { red, green, blue };
}
byte[] rgb = ConvertHexToRGB("#fac");
Console.WriteLine($"RGB цвет: {rgb[0]} {rgb[1]} {rgb[2]}");
