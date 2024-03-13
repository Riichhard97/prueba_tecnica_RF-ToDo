using AutoMapper;
using PruebaTecnica.Core.Domain.Entities;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Application.Features.Activities.Mappings
{
    public class ActivityMapping: Profile
    {
        public ActivityMapping()
        {
            CreateMap<Activity, ActivityDto>(MemberList.Destination);
        }
    }
}
