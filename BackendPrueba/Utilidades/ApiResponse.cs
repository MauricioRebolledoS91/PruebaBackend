using BackendPrueba.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Utilidades
{
    public class ApiResponse
    {
        public int Page { get; set; }

        public IEnumerable<Movie> Results { get; set; }
    }
}
