using Microsoft.AspNetCore.Mvc.Rendering;
using Palkkasovellus.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Palkkasovellus.Services
{
    public interface IHenkiloService
    {
        Task CreateAsync(Henkilo newHenkilo);
        Henkilo GetById(int henkiloId);
        Task UpdateAsync(Henkilo henkilo);
        Task UpdateAsync(int id);
        Task Delete(int henkiloId);
        decimal Jasenmaksut(int id);
        IEnumerable<Henkilo> GetAll();

        IEnumerable<SelectListItem> GetAllHenkilotPalkkatietoihin();
    }
}
