using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Models.Common.Dtos
{
   public class AutorDto
    {
        public int Identyfikator { get; set; }
        public string Nazwisko { get; set; }

        public override string ToString()
        {
            return Nazwisko;
        }
    }
}
