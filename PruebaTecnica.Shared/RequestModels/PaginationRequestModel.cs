using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.RequestModels
{
    public class PaginationRequestModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

}
