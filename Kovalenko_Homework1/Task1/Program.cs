using System;

Console.Write("Input a = ");
var a = int.Parse(Console.ReadLine());
Console.Write("Input b = ");
var b = int.Parse(Console.ReadLine());

Console.WriteLine("Result:");
for(var i = a; i <= b; i++)
{
    var ternaryNumber = String.Empty;
    var decimalNumber = i < 0 ? -i : i;
    do
    {
        ternaryNumber = (decimalNumber % 3) + ternaryNumber;
        decimalNumber /= 3;
    } 
    while (decimalNumber > 0);

    var twosCounter = 0;
    foreach(var numberDigit in ternaryNumber)
    {
        if (numberDigit == '2') 
        {
            twosCounter++;
        }
    }

    if (twosCounter == 2)
    {
        Console.WriteLine($"{i}");
    }
}
