using AutoMapper;
using PruebaTecnica.Core.Domain.Entities;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Goals.Mappings
{
    public class GoalMapping : Profile
    {
        public GoalMapping()
        {
            CreateMap<Goal, GoalDto>(MemberList.Destination).ForMember(dest =>
                dest.ActivitiesPercentage,
                opt => opt.MapFrom(src => src.Activities.Count() >0 ? src.Activities.Count(activity => activity.Completed) *100 / src.Activities.Count() : 0));
        }
    }
}
