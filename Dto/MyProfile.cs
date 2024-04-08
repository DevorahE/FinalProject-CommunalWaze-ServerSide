using AutoMapper;
using Dal.Models;
using Dto.DTOs;

namespace Bll
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<SaveSearch, SaveSearchDto>().ReverseMap();

            CreateMap<ReportsCategory, ReportsCategoryDTO>().ReverseMap();

            CreateMap<Report, ReportDto>().ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data.ToString("dd-MM-yyyy")))
                .ForMember(dest => dest.ColorCategory, opt => opt.MapFrom(src => src.IdCategoryNavigation.ColorCategory))
                .ForMember(dest => dest.NameCategory, opt => opt.MapFrom(src => src.IdCategoryNavigation.NameCategory));

            CreateMap<ReportDto, Report>().ForMember(dest => dest.Data, opt => opt.MapFrom(src => DateTime.Parse(src.Data)));


        }
    } 
    }