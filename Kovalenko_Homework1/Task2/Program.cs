using System;

Console.Write("Input string(9 digits): ");
var ISBNCode = Console.ReadLine();

var sum = 0;
for(int i = 0, multiplier = 10; i < 9; i++, multiplier--)
{
    sum += multiplier * (int)Char.GetNumericValue(ISBNCode[i]);
}

var checkDigit = 0;
for(;checkDigit < 11; checkDigit++)
{
    if((sum + checkDigit) % 11 == 0)
    {
        break;
    }
}

ISBNCode += (checkDigit == 10) ? "X" : checkDigit.ToString();
Console.WriteLine(ISBNCode);