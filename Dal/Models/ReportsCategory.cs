using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class ReportsCategory
{
    public int IdCategory { get; set; }

    public string NameCategory { get; set; } = null!;

    public string ColorCategory { get; set; } = null!;

    public string? NameCategoryEn { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
