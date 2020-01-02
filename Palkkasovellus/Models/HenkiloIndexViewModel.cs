using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palkkasovellus.Models
{
    public class HenkiloIndexViewModel
    {
        public int Id { get; set; }
        public string HenkiloNro { get; set; }
        public string Sukupuoli { get; set; }
        public string KuvaUrl { get; set; }
        public string Kokonimi { get; set; }
        public DateTime AloitusPvm { get; set; }
        public string Tehtava { get; set; }
        public string Kaupunki { get; set; }

    }
}
