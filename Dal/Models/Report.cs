using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Report
{
    public int CodeReport { get; set; }

    public DateOnly Data { get; set; }

    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    public int IdCategory { get; set; }

    public string Lng { get; set; } = null!;

    public string Lat { get; set; } = null!;

    public bool Temporary { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public string? FormattedAddress { get; set; }

    public virtual ReportsCategory IdCategoryNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
