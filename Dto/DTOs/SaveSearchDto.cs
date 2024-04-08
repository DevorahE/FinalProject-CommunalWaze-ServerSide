using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.DTOs
{
    public class SaveSearchDto
    {
        public int SearchId { get; set; }
        public int UserId { get; set; }

        public string Lat { get; set; } = null!;

        public string Lng { get; set; } = null!;

        public string? FormattedAddress { get; set; }

        public string NameSearch { get; set; } = null!;
        
    }
}
