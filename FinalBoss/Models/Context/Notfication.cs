using FinalBoss.Models.Abstrac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBoss.Models.Context
{
    public class Notfication : Entity
    {
        public string CvName { get; set; }
        public  string Message { get; set; }
        public  string Date { get; set; }
    }
}
