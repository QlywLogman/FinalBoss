using FinalBoss.Models.Abstrac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBoss.Models.Context
{
    public class VacansiaClass : Entity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string ContactEmail { get; set; }

    }
}
