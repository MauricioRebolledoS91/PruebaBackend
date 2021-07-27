using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Dtos
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
    }
}
