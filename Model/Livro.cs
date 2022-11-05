using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Autor { get; set; }
        public String Genero { get; set; }
        public String Ano { get; set; }
    }
}