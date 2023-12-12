using System;
using System.Collections.Generic;

public class CustomTask
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public List<string> Tags { get; set; }
    public DateTime Deadline { get; set; }

    public CustomTask(string title, string description, int priority, DateTime deadline)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Tags = new List<string>();
        Deadline = deadline;
    }
}
