using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.Entities;
using PensionManagementSystem.Application.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PensionManagementSystem.Domain.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // mapping request models to entities
            CreateMap<MemberRequestModel, Member>();
            CreateMap<EmployerRequestModel, Employer>();
            CreateMap<BenefitRequestModel, Benefit>();
            CreateMap<ContributionRequestModel, Contribution>();


            // mapping entities to Dtos

            CreateMap<Member, MemberDto>();
            CreateMap<Employer, EmployerDto>();
            CreateMap<Benefit, BenefitDto>();
            CreateMap<Contribution, ContributionDto>();
        }
    }
}
