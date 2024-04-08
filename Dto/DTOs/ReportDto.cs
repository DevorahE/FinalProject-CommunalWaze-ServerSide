using Dal.models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dto.DTOs
{
    public class ReportDto
    {
        public int CodeReport { get; set; }

        public string? Data { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; } = null!;

        public int IdCategory { get; set; }

        public string Lng { get; set; } = null!;

        public string Lat { get; set; } = null!;

        public string? FormattedAddress { get; set; }
        public bool Temporary { get; set; }

        public DateTime? DateStart { get; set; } 

        public DateTime? DateEnd { get; set; }

        public string? ColorCategory { get; set; }

        public string? NameCategory { get; set; }

    }
}
