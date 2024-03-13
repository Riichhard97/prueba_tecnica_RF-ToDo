using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Domain.Entities
{
    public class Goal : EntityBase
    {
        public string Name { get; set; }

        public virtual IEnumerable<Activity> Activities { get; set; }
    }
}
