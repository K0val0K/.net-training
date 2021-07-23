using System;


class Lecture
{
    public string Description { get; set; } = null;

    public string Topic { get; set; } = null;

    public Lecture(string description, string topic)
    {
        Description ??= description;
        Topic ??= topic;
    }
}

