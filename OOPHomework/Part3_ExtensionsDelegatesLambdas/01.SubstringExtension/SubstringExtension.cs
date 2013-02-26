using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubstringExtension
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("112233445566");

        Console.WriteLine(sb.Substring(0, 10).ToString());
    }

    
}

public static class Extensions
{
    public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
    {
        if (startIndex + length > sb.Length || startIndex < 0 || startIndex > sb.Length)
        {
            throw new ArgumentOutOfRangeException("Substring goes otside the bounds of the string");
        }

        char[] substring = new char[length];
        for (int i = 0; i < length; i++)
        {
            substring[i] = sb[startIndex + i];
        }
        StringBuilder newSubstring = new StringBuilder();
        newSubstring.Append(substring);

        return newSubstring;
    }
}

