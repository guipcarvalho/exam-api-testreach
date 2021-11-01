using AutoMapper;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Domain.Mappers
{
    public class CommandToDomainProfile : Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<ExamAttempt, CreateExamAttemptCommand>()
                .ForMember(dest => dest.ExamDate, opt => opt.MapFrom(src => src.AttemptDate))
                .ForMember(dest => dest.CandidateEmail, opt => opt.MapFrom(src => src.Candidate.Email))
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => src.Candidate.Name))
            .ReverseMap();
        }
    }
}
