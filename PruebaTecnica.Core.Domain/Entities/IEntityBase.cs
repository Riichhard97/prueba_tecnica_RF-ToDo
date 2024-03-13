using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Domain.Entities
{
    public interface IEntityBase
    {
        int? Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}
