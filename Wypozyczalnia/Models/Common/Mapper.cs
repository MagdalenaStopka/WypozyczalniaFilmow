using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Models.Common.Dtos;
using Wypozyczalnia.Models.DB;

namespace Wypozyczalnia.Models.Common
{
   public class Mapper
    {
        
        public static AutorDto Map(Autor autor)
        {
            if (autor == null)
                return null;

            return new AutorDto
            {
                Identyfikator = autor.Id,
                Nazwisko = autor.Nazwisko
            };
        }
    }
}
