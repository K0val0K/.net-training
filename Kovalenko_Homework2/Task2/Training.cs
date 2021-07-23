using System;

class Training
{
    private object[] _lessons = null; //change after test

    public string Description { get; set; } = null;

    public Training(string description = null, params object[] lessons)
    {
         Description ??= description;
    
        if (lessons != null)
        {
            _lessons = new object[lessons.Length];
            for(int i = 0; i < _lessons.Length; i++)
            {
                _lessons[i] = lessons[i];
            }
        }
       
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Training description: {Description}");
        Console.WriteLine($"Training contains {_lessons.Length} lessons.\n\nList of lessons:");
        foreach(var lesson in _lessons)
        {
            if(lesson is Practicum practicum)
            {
                Console.WriteLine($"Practicum.\n" +
                    $"Description: {practicum.Description}\n" +
                    $"Solution Link:{practicum.SolutionLink}\n" +
                    $"Task Link: {practicum.TaskLink}\n");
            }
            if (lesson is Lecture lecture)
            {
                Console.WriteLine($"Lecture.\n" +
                    $"Description: {lecture.Description}\n" +
                    $"Topic: {lecture.Topic}\n");
            }
        }
    }

    public void Add(object lesson)
    {
        if(lesson is Lecture || lesson is Practicum)
        {
            object[] newLessonsArray = new object[_lessons.Length + 1];
            for(int i = 0; i < newLessonsArray.Length - 1; i++)
            {
                newLessonsArray[i] = _lessons[i];
            }
            newLessonsArray[newLessonsArray.Length - 1] = lesson;

            _lessons = newLessonsArray;
        }
    }

    public bool IsPractical()
    {
        foreach(var lesson in _lessons)
        {
            if (lesson is Lecture) return false;
        }
        return true;
    }

    public Training Clone()
    {
        var clonedTraining = new Training();
        clonedTraining._lessons = new object[_lessons.Length];
        for(int i = 0; i < _lessons.Length; i++)
        {
            if(_lessons[i] is Practicum practicum)
            {
                clonedTraining._lessons[i] = new Practicum(practicum.Description, practicum.TaskLink, practicum.SolutionLink);
            }
            if(_lessons[i] is Lecture lecture)
            {
                clonedTraining._lessons[i] = new Lecture(lecture.Description,lecture.Topic);
            }
        }
        clonedTraining.Description = new string(Description);
        return clonedTraining;
    }
}

