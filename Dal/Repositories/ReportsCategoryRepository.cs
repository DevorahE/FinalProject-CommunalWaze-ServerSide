using Dal.Interfaces;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class ReportsCategoryRepository : IReportsCategoryRepository
    {
        public bool AddCategory(ReportsCategory category)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    var b=db.ReportsCategories.Add(category);
                    int i= db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ReportsCategory> GetAll()
        {
            using (var db = new CommunalWazeContext())
            {
                return db.ReportsCategories.ToList();
            }
        }
    }
}
