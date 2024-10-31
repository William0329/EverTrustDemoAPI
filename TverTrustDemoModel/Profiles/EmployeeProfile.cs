using AutoMapper;

using TverTrustDemoModel.Dtos.Business;
using TverTrustDemoModel.Extensions;
using TverTrustDemoModel.Models;

namespace TverTrustDemoModel.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>()
           .ForMember(dest => dest.EmployeeId, opt => opt.Ignore())
           .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.BirthDate) ? DateTime.Parse(src.BirthDate) : (DateTime?)null))
           .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.HireDate) ? DateTime.Parse(src.HireDate) : (DateTime?)null))
           .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Photo) ? Convert.FromBase64String(src.Photo) : null))
           .ReverseMap()
           .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.HasValue ? src.BirthDate.Value.ToDateTimeString("/") : null))
           .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate.HasValue ? src.HireDate.Value.ToDateTimeString("/") : null))
           .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo.Length > 0 ? Convert.ToBase64String(src.Photo) : null));
            //新增
            CreateMap<AddEmployeeDto, Employee>()
           .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.BirthDate) ? DateTime.Parse(src.BirthDate) : (DateTime?)null))
           .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.HireDate) ? DateTime.Parse(src.HireDate) : (DateTime?)null))
           .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Photo) ? Convert.FromBase64String(src.Photo) : null));
            //更新
            CreateMap<UpdateEmployeeDto, Employee>()
           .ForMember(dest => dest.EmployeeId, opt => opt.Ignore())
           .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.BirthDate) ? DateTime.Parse(src.BirthDate) : (DateTime?)null))
           .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.HireDate) ? DateTime.Parse(src.HireDate) : (DateTime?)null))
           .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Photo) ? Convert.FromBase64String(src.Photo) : null));
        }
    }
}
