using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.RequestModels.Acitivity
{
    public class UpdateActivityRequestModel
    {
        public string? Name { get; set; }
        public bool? Important { get; set; }
    }
}
