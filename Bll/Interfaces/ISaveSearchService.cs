using Dal.Models;
using Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface ISaveSearchService
    {
        bool AddSaveSearch(SaveSearchDto saveSearch);

        bool UpdateSaveSearch(int searchId, SaveSearchDto saveSearch, int userId);
        bool DeleteSaveSearch(int searchId);
        List<SaveSearchDto> GetAllSaveSearchByUser(int userId);
        List<SaveSearchDto> GetAllSaveSearch();
        SaveSearchDto GetByName(int searchId, int userId);
    }
}
