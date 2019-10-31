using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promos.Models
{
    public class LojaViewModel
    {
        public int id {get; set;}
        public string cnpj { get; set; }
        public string matriz { get; set; }
        public string nome { get; set; }
        public Boolean funciona { get; set; }

    }
}
