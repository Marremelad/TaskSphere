using System;
using System.Collections.Generic;

namespace TaskSphere.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
