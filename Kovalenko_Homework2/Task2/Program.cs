using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Create Lecture");
        var lecture1 = new Lecture("test1 lecture", "test");
        var lecture2 = new Lecture("test2 lecture", null);
        var lecture3 = new Lecture(null, "test3 topic");

        var lecturesTestArray = new object[] { lecture1, lecture2, lecture3 };
        var testTraining1 = new Training("test training description", lecturesTestArray);
        Console.WriteLine($"Test training 1:");
        testTraining1.ShowInfo();

        Console.WriteLine($"\n\nIs the test training1 practical? {testTraining1.IsPractical()}");

        Console.WriteLine("Add 1 practicum...");
        testTraining1.Add(new Practicum("practicum", "https://www.tasklink", "http://www.tasksolution"));

        Console.WriteLine($"Is the testtraining1 practical now? {testTraining1.IsPractical()}");
        Console.WriteLine("\n\nCurrent info:");
        testTraining1.ShowInfo();

        Console.WriteLine("\n\nTest Clone() method..");
        var clone = testTraining1.Clone();
        Console.WriteLine("Checking clone information:\n");
        clone.ShowInfo();

        Console.WriteLine("Creating practical training...");
        var practicalTraining = new Training(null, new Practicum(null, "tasklink", "solutionLink"), new Practicum("", "link2", ""));
        Console.WriteLine($"Is this training practical? {practicalTraining.IsPractical()}");
        practicalTraining.Add(new Lecture("", "test"));
        Console.WriteLine($"Is it practical now? {practicalTraining.IsPractical()}");
        practicalTraining.ShowInfo();

    }
}
