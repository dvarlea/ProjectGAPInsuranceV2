using AutoMapper;
using GAPInsuranceApp.DTOs;
using GAPInsuranceApp.Models;

namespace GAPInsuranceApp.Data
{
    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            this.CreateMap<Insurance, InsuranceDTO>()
                .ReverseMap();
            this.CreateMap<RegisterUserDTO, User>();

        }
    }
}
