using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services.Implementations
{
    class TyottomuusvakuutusService : ITyottomuusvakuutusService
    {
        private decimal tyottomyysvakuutuksenMaara;
        public decimal TyottomuusvakuutuksenMaara(decimal kokonaisAnsio,
            decimal tyottomuusvakuutusProsentti)
        {
            tyottomyysvakuutuksenMaara = kokonaisAnsio * tyottomuusvakuutusProsentti / 100;
            return tyottomyysvakuutuksenMaara;
        }
    }
}
