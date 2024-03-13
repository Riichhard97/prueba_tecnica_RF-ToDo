using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.RequestModels.Acitivity
{
    public class SetCompleteActivitiesRequestModel
    {
        public List<int> Ids { get; set; }
        public bool isComplete { get; set; }
    }
}
