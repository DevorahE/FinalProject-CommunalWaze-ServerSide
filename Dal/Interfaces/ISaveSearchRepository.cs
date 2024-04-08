using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface ISaveSearchRepository
    {
        bool AddSaveSearch(SaveSearch saveSearch);

        bool UpdateSaveSearch(int searchId, SaveSearch saveSearch, int userId);
        bool DeleteSaveSearch(int searchId);

        List<SaveSearch> GetAllSaveSearch();

        List<SaveSearch> GetAllSaveSearchByUser(int userId);
        SaveSearch GetByName(int searchId, int userId);
    }
}
