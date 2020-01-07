using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services
{
    public interface IElakemaksuService
    {
        decimal ElakemaksunMaara(decimal kokonaisAnsio, decimal elakemaksuProsentti);
    }
}
