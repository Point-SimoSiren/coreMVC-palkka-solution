using Microsoft.AspNetCore.Mvc.Rendering;
using Palkkasovellus.Entity;
using Palkkasovellus.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palkkasovellus.Services.Implementations
{
    public class HenkiloService : IHenkiloService
    {
        private readonly ApplicationDbContext _context;
        public HenkiloService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Henkilo newHenkilo)
        {
            await _context.Henkilot.AddAsync(newHenkilo);
            await _context.SaveChangesAsync();
        }

        public Henkilo GetById(int henkiloId) =>
            _context.Henkilot.Where(h => h.Id == henkiloId).FirstOrDefault();

        public async Task Delete(int henkiloId)
        {
            var henkilo = GetById(henkiloId);
            _context.Remove(henkilo);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Henkilo> GetAll() => _context.Henkilot;

        public async Task UpdateAsync(Henkilo henkilo)
        {
            _context.Update(henkilo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var henkilo = GetById(id);
            _context.Update(henkilo);
            await _context.SaveChangesAsync();
        }

        public decimal Jasenmaksut(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetAllHenkilotPalkkatietoihin()
        {
            return GetAll().Select(henk => new SelectListItem()
            {
                Text = henk.Kokonimi,
                Value = henk.Id.ToString()
            });
        }
    }
}
