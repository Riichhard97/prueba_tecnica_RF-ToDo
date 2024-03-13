using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Domain.Entities
{
    public class Activity : EntityBase
    {
        public string Name { get; set; }
        public int GoalId { get; set; }
        public bool Completed { get; set; }
        public bool Important { get; set; }
    }
}
