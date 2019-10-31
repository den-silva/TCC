using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promos.Models
{
    public class PromocaoViewModel
    {
        public int id {get; set;}
        public DateTime criado {get; set;}
        public DateTime validade {get; set;}
        public int carimbos {get; set;}
}
}
