using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IReportRepository
    {
        List<Report> GetAll();  
        Report GetReportByCode(int codeReport);
        List<Report> GetReportsByUser(int user);
        List<Report> GetReportsByColor(int color);
        bool AddReport(Report report);

        bool DeleteReport(int codeReport);
        bool UpdateReport(int codeReport, Report report);
    }
}
