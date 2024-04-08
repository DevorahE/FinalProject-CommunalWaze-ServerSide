using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.DTOs
{
    public class ReportsCategoryDTO
    {
        public int IdCategory { get; set; }

        public string NameCategory { get; set; } = null!;

        public string? NameCategoryEn { get; set; }
        public string ColorCategory { get; set; } = null!;
    }
}
