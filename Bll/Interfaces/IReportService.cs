using Dal.Models;
using Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IReportService
    {
        List<ReportDto> GetAll();
        ReportDto GetReportByCode(int codeReport);
        List<ReportDto> GetReportsByUser(int user);
        List<ReportDto> GetReportsByColor(int color);
        bool AddReport(ReportDto report);
        bool DeleteReport(int codeReport);
        bool UpdateReport(int codeReport, ReportDto report);

    }
}
