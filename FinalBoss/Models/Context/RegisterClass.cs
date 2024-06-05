using FinalBoss.Models.Abstrac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBoss.Models.Context
{
    public class RegisterClass : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string AccessMode { get; set; }
    }
}
