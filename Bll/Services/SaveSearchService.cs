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
    public class SaveSearchService :ISaveSearchService
    {
        ISaveSearchRepository repository;
        IMapper iMapper;
        public SaveSearchService(ISaveSearchRepository repository) 
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });
            iMapper = config.CreateMapper();
        }

        public bool AddSaveSearch(SaveSearchDto saveSearch)
        {
            bool item = repository.AddSaveSearch(iMapper.Map<SaveSearchDto, SaveSearch>(saveSearch));
            return item;
        }

        public bool DeleteSaveSearch(int idSaveSearch)
        {
            bool item = repository.DeleteSaveSearch(idSaveSearch);
            return item;
        }

        public List<SaveSearchDto> GetAllSaveSearch()
        {
            List<SaveSearch> reports = repository.GetAllSaveSearch();
            return iMapper.Map<List<SaveSearch>, List<SaveSearchDto>>(reports);
        }

        public List<SaveSearchDto> GetAllSaveSearchByUser(int userId)
        {
            List<SaveSearch> reports = repository.GetAllSaveSearchByUser(userId);
            return iMapper.Map<List<SaveSearch>, List<SaveSearchDto>>(reports);
        }

        public SaveSearchDto GetByName(int searchId, int userId)
        {
            SaveSearch item = repository.GetByName(searchId, userId);
            return iMapper.Map<SaveSearch, SaveSearchDto>(item);
        }

        public bool UpdateSaveSearch(int searchId, SaveSearchDto saveSearch, int userId)
        {
            bool item = repository.UpdateSaveSearch(searchId, iMapper.Map<SaveSearchDto, SaveSearch>(saveSearch), userId);
            return item;
        }
    }
}
