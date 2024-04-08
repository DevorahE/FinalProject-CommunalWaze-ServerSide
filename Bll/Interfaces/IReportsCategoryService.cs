using Dal.Models;
using Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IReportsCategoryService
    {
        List<ReportsCategoryDTO> GetAll();
        bool AddCategory(ReportsCategoryDTO category);
    }
}
