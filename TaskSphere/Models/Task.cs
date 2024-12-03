using System;
using System.Collections.Generic;

namespace TaskSphere.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public bool? TaskStatus { get; set; }

    public DateOnly? TaskDeadline { get; set; }

    public string? TaskDescription { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
