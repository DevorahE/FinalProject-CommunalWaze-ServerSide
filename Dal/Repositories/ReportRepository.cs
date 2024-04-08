using Dal.Interfaces;
using Dal. Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace Dal.Repositories
{
    public class ReportRepository : IReportRepository
    {
        public bool AddReport(Report report)
        {
            if (!report.Temporary)
            {
                report.DateStart = null;
                report.DateEnd = null;
            }
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    var b= db.Reports.Add(report);
                    int b1 = db.SaveChanges();
                }
                return true;
            }

            catch(Exception ex)
            {
                var e = ex.Message;
                return false;   
            }
        }

        public bool DeleteReport(int codeReport)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    Report report = db.Reports.First(x => x.CodeReport == codeReport);
                    db.Reports.Remove(report);
                    db.SaveChanges();
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Report> GetAll()
        {
            using (var db = new CommunalWazeContext())
            {
                List<Report> list = db.Reports.Include(x => x.IdCategoryNavigation).ToList();
                return list;
            }
        }

        public Report GetReportByCode(int codeReport)
        {
            using (var db = new CommunalWazeContext()) 
            {
                Report report = db.Reports.Include(x => x.IdCategoryNavigation).SingleOrDefault(r => r.CodeReport == codeReport);
                return report;
            }
        }
       
        public List<Report> GetReportsByUser(int user)
        {
            using (var db = new CommunalWazeContext())
            {
                List<Report> reports= db.Reports.Include(x => x.IdCategoryNavigation).Where(x => x.UserId == user).ToList();
                return reports;
            }
        }
        public static bool RemoveOldReports()
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    List<Report> list = db.Reports.Where(x => x.DateEnd != null && x.DateEnd < DateOnly.FromDateTime(DateTime.Now)).ToList();
                    ReportRepository r = new ReportRepository();
                    list.ForEach(x => r.DeleteReport(x.CodeReport));
                    Console.WriteLine("RemoveOldReports");
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            Console.ReadLine();
        }
        public static async Task RemoveOldReportsAsync()
        {
            try{ 
                using (var db = new CommunalWazeContext())
                {
                    List<Report> list = await db.Reports.Where(x => x.DateEnd!=null && x.DateEnd < DateOnly.FromDateTime(DateTime.Now)).ToListAsync();
                    ReportRepository r = new ReportRepository();
                    list.ForEach(x => r.DeleteReport(x.CodeReport));
                    await Console.Out.WriteLineAsync("RemoveOldReportsAsync");
                }
            }
            catch(Exception ex)
            {
            }
            Console.ReadLine();
        }
       
        public bool UpdateReport(int codeReport, Report report)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    Report item = db.Reports.FirstOrDefault(x => x.CodeReport == codeReport);
                    if(item != null)
                    { 
                        item.IdCategory = report.IdCategory;
                        item.DateEnd = report.DateEnd;
                        item.DateStart = report.DateStart;
                        item.Content = report.Content;
                        item.Lat = report.Lat;
                        item.Lng = report.Lng;
                        item.FormattedAddress = report.FormattedAddress;
                        item.Temporary = report.Temporary;
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Report> GetReportsByColor(int color)
        {
            using (var db = new CommunalWazeContext())
            {
                List<Report> reports = db.Reports.Include(x => x.IdCategoryNavigation).Where(x => x.IdCategory == color).ToList();
                return reports;
            }
        }
    }
}

