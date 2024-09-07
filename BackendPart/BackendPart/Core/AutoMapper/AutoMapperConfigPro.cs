using AutoMapper;
using BackendPart.Core.Dtos.Candidate;
using BackendPart.Core.Dtos.Company;
using BackendPart.Core.Dtos.Job;
using BackendPart.Core.Entities;

namespace BackendPart.Core.AutoMapper
{
    public class AutoMapperConfigPro : Profile
    {
        public AutoMapperConfigPro() {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest => dest.JobTitel, opt => opt.MapFrom(src => src.Job.Title));
        }
    }
}
