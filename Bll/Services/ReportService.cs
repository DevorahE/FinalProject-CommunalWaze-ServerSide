using AutoMapper;
using Bll.Interfaces;
using Dal.Interfaces;
using Dal.Models;
using Dto.DTOs;

namespace Bll.Services
{
    public class ReportService : IReportService
    {
        IReportRepository repository;
        IMapper iMapper;

        public ReportService(IReportRepository repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });
            iMapper = config.CreateMapper();
        }

        public bool AddReport(ReportDto report)
        {
            report.Data = DateTime.Now.ToString();
            
            bool item = repository.AddReport(iMapper.Map<ReportDto, Report>(report));
            return item;   
        }

        public bool DeleteReport(int codeReport)
        {
            bool item = repository.DeleteReport(codeReport);
            return item;
        }

        public List<ReportDto> GetAll()
        {
            List<Report> reports = repository.GetAll();
            return iMapper.Map<List<Report>, List<ReportDto>>(reports);
        }

        public ReportDto GetReportByCode(int codeReport)
        {
            Report item = repository.GetReportByCode(codeReport);
            return iMapper.Map<Report, ReportDto>(item);
        }

        public List<ReportDto> GetReportsByUser(int user)
        {
            List<Report> reports = repository.GetReportsByUser(user);
            return iMapper.Map<List<Report>, List<ReportDto>>(reports);
        }

        public static async Task RemoveOldReports() 
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(30));

            while(await timer.WaitForNextTickAsync())
            {
                await Dal.Repositories.ReportRepository.RemoveOldReportsAsync();
            }
        }
        
        public bool UpdateReport(int codeReport, ReportDto report)
        {
            bool item = repository.UpdateReport(codeReport, iMapper.Map<ReportDto, Report>(report));
            return item;
        }

        public List<ReportDto> GetReportsByColor(int color)
        {
            List<Report> reports = repository.GetReportsByColor(color);
            return iMapper.Map<List<Report>, List<ReportDto>>(reports);
        }
    }
}
