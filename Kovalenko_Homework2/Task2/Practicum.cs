using System;


class Practicum
{
    public string Description { get; set; } = null;

    public string TaskLink { get; set; } = null;

    public string SolutionLink { get; set; } = null;

    public Practicum(string description = null, string taskLink = null, string solutionLink = null)
    {
        Description ??= description;
        TaskLink ??= taskLink;
        SolutionLink ??= solutionLink;
    }

}

