using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Dtos
{
    public class MoviesFilterDTO
    {
        public string Title { get; set; }
        public bool BetterRated { get; set; }
        public bool MorePopulars { get; set; }
    }
}
