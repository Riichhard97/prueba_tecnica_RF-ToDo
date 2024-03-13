using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.Dtos
{
    public class GoalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int ActivitiesPercentage { get; set; }
        public virtual IEnumerable<ActivityDto> Activities { get; set; }

    }
}
