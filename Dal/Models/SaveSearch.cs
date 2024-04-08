using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class SaveSearch
{
    public int SearchId { get; set; }

    public int UserId { get; set; }

    public string Lat { get; set; } = null!;

    public string Lng { get; set; } = null!;

    public string NameSearch { get; set; } = null!;

    public string? FormattedAddress { get; set; }

    public virtual User User { get; set; } = null!;
}
