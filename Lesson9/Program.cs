static byte[]? HexToRgb(string hex)
{
    byte[] rgb = new byte[3];

    if (hex != null)
    {
        hex = hex.Replace("#", "");
        
        if (hex.Length == 3)
        {
            rgb[0] = (byte)(Convert.ToByte(hex[0].ToString(), 16) * 17);
            rgb[1] = (byte)(Convert.ToByte(hex[1].ToString(), 16) * 17);
            rgb[2] = (byte)(Convert.ToByte(hex[2].ToString(), 16) * 17);
            return rgb;
        }
        else if (hex.Length == 6)
        {
            rgb[0] = Convert.ToByte(hex[0].ToString() + hex[1].ToString(), 16);
            rgb[1] = Convert.ToByte(hex[2].ToString() + hex[3].ToString(), 16);
            rgb[2] = Convert.ToByte(hex[4].ToString() + hex[5].ToString(), 16);
            return rgb;
        } 
        else
        {
            return null;
        }
    } 
    else
    {
        return null;
    }
}
static string RgbToHex(byte red, byte green, byte blue)
{
    string hex = $"#{Convert.ToHexString(new byte[] {red, green, blue})}";
    if (hex[1] == hex[2] && hex[3] == hex[4] && hex[5] == hex[6])
    {
        hex = hex[0].ToString() + hex[1] + hex[3] + hex[5];
    }
    return hex;
}

string hex = "#f01";
Console.WriteLine(hex);
byte[] rgb = HexToRgb(hex);

for (int i = 0; i < 3 && rgb != null; i++)
{
    Console.Write(rgb[i] + " ");
}

Console.WriteLine("\n");

byte[] rgb_array = {120, 22, 55};
byte r = 0, g = 0, b = 0;
Console.WriteLine($"{r} {g} {b}");

Console.WriteLine(RgbToHex(r, g, b));