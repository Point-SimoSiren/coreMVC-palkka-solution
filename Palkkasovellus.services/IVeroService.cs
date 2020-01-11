using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    public interface IVeroService
    {
        decimal VeronMaara(decimal KokonaisAnsio, decimal Veroprosentti,
            decimal Tuloraja, decimal Lisaprosentti);
    }
}
