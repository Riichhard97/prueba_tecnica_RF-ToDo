using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Shared.Dtos
{
    public class ActivityDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public bool Completed { get; set; }
        public bool Important { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
