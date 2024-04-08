using Dal.Interfaces;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SaveSearchRepository : ISaveSearchRepository
    {
        public bool AddSaveSearch(SaveSearch saveSearch)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    db.SaveSearches.Add(saveSearch);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSaveSearch(int searchId)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    SaveSearch saveSearch= db.SaveSearches.First(x => x.SearchId == searchId);
                    db.SaveSearches.Remove(saveSearch);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SaveSearch> GetAllSaveSearch()
        {
            using (var db = new CommunalWazeContext())
            {
                return db.SaveSearches.ToList();
            }
        }

        public List<SaveSearch> GetAllSaveSearchByUser(int userId)
        {
            using (var db = new CommunalWazeContext())
            {
                return db.SaveSearches.Where(x => x.UserId == userId).ToList();
            }
        }

        public SaveSearch GetByName(int searchId, int userId)
        {
            using (var db = new CommunalWazeContext())
            {
                return db.SaveSearches.FirstOrDefault(r => r.SearchId == searchId && r.UserId == userId);
            }
        }

        public bool UpdateSaveSearch(int searchId, SaveSearch saveSearch, int userId)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    SaveSearch item = db.SaveSearches.FirstOrDefault(x => x.SearchId == searchId && x.UserId == userId);
                    if(item !=null)
                    {
                        item.Lat = saveSearch.Lat;
                        item.Lng = saveSearch.Lng;
                        item.FormattedAddress = saveSearch.FormattedAddress;
                        db.SaveChanges(); 
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
