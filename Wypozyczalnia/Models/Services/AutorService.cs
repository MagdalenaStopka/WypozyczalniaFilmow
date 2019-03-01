using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Models.Common;
using Wypozyczalnia.Models.Common.Dtos;
using Wypozyczalnia.Models.DB;

namespace Wypozyczalnia.Models.Services
{
   public class AutorService
    {
        public void AddAutor(string nazwisko)
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                if (dbContext.Autors.Any(x => x.Nazwisko.Equals(nazwisko, StringComparison.CurrentCultureIgnoreCase)))
                    throw new Exception("Taki autor już istnije");
                var entity = new Autor();
                entity.Nazwisko = nazwisko;
                dbContext.Autors.Add(entity);
                dbContext.SaveChanges();

            }


        }
        public void UpdateAutor(AutorDto dto)
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                var entityToUpdate = GetAutorFromDb(dbContext, dto.Identyfikator);
                entityToUpdate.Nazwisko = dto.Nazwisko;
                dbContext.SaveChanges();

            }
        }

        private Autor GetAutorFromDb(WypozyczalniaEntities dbContext, int id)
        {
            return dbContext.Autors.Single(x => x.Id == id);
        }

        public Autor GetAutor(int id)
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                return GetAutorFromDb(dbContext, id);
            }
        }

        public AutorDto[] GetAllAuthors()
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                var entities = dbContext.Autors.ToArray();
                return entities.Select(x => Mapper.Map(x)).ToArray();
            }
        }

        private Autor GetAuthorFromDb(WypozyczalniaEntities dbContext, int id)
        {
            return dbContext.Autors.Single(x => x.Id == id);
        }

    }
}
