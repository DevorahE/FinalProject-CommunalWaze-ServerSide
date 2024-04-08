using AutoMapper;
using Bll.Interfaces;
using Dal.Interfaces;
using Dal.Models;
using Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class ReportCategoryService : IReportsCategoryService
    {
        IReportsCategoryRepository repository;
        IMapper iMapper;
        public ReportCategoryService(IReportsCategoryRepository repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });
            iMapper = config.CreateMapper();
        }

        public bool AddCategory(ReportsCategoryDTO category)
        {
            bool item = repository.AddCategory(iMapper.Map<ReportsCategoryDTO, ReportsCategory>(category));
            return item;
        }

        public List<ReportsCategoryDTO> GetAll()
        {
            List<ReportsCategory> categories = repository.GetAll();
            return iMapper.Map<List<ReportsCategory>, List<ReportsCategoryDTO>>(categories);
        }
    }
}
