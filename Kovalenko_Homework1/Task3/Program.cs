using System;

Console.Write("Input array size n>=2: ");
var size = int.Parse(Console.ReadLine());
var arr = new int[size];

Console.WriteLine("Input array: ");
for(var i = 0; i < size; i++)
{
    bool isNumericUserInput = false;
    while(!isNumericUserInput)
    {
        Console.Write($"Input element #{i}: ");
        isNumericUserInput = int.TryParse(Console.ReadLine(), out arr[i]) ? true : false;
        if(!isNumericUserInput)
        {
            Console.WriteLine("Array element must be integer value! Try again:");
        }
    }
}

var minIndex = 0;
var maxIndex = size - 1;
for(int i = 0, max = arr[maxIndex], min = arr[minIndex]; i < size; i++)
{
    if(arr[^(i + 1)] > max)
    {
        max = arr[^(i + 1)];
        maxIndex = size - i - 1;
    }
    if(arr[i] < min)
    {
        min = arr[i];
        minIndex = i;
    }
}

Range subarrayRange = minIndex < maxIndex ? minIndex..(maxIndex + 1) : maxIndex..(minIndex + 1);
var subarray = arr[subarrayRange];
var sum = 0;
foreach(var element in subarray)
{
    sum += element;
}

Console.WriteLine($"Sum of elements between maximun and minimum: {sum}");
