using System;
using System.Collections.Generic;
using System.Text;

namespace Palkkasovellus.Services.Implementations
{
    public class TyottomyysvakuutusService : ITyottomyysvakuutusService
    {
        private decimal tyottomyysvakuutuksenMaara;
        public decimal TyottomyysvakuutuksenMaara(decimal kokonaisAnsio,
            decimal tyottomyysvakuutusProsentti)
        {
            tyottomyysvakuutuksenMaara = kokonaisAnsio * tyottomyysvakuutusProsentti / 100;
            return tyottomyysvakuutuksenMaara;
        }
    }
}
