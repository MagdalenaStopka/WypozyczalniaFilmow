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
   public class KlientService
    {
        public void AddKlient(string nazwisko)
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                if (dbContext.Klients.Any(x => x.Nazwisko.Equals(nazwisko, StringComparison.CurrentCultureIgnoreCase)))
                    throw new Exception("Taki klient już istnije");

                var entity = new Klient();
                entity.Nazwisko = nazwisko;
                dbContext.Klients.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void UpdateKlient(KlientDto dto)
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                var entityToUpdate = GetKlientFromDb(dbContext, dto.Identyfikator);
                entityToUpdate.Nazwisko = dto.Nazwisko;
                dbContext.SaveChanges();
            }
        }

        public KlientDto GetKlient(int id)
        {
            using (var dbContext = new WypozyczalniaEntities())
            {
                var klientEntity = GetKlientFromDb(dbContext, id);
                var dto = Mapper.Map(klientEntity);
                return dto;
            }
        }

        private Klient GetKlientFromDb(WypozyczalniaEntities dbContext, int id)
        {
            return dbContext.Klients.Single(x => x.Id == id);
        }

        internal IEnumerable<KlientDto> GetAllClients()
        {
            using (var dbc = new WypozyczalniaEntities())
            {
                var entities = dbc.Klients.ToList();
                return entities.Select(x => Mapper.Map(x));
            }
        }
        }
}
