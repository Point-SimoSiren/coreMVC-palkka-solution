using Palkkasovellus.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Palkkasovellus.Models
{
    public class MaksuIndexViewModel
    {
        public int Id { get; set; }

        public int HenkiloId { get; set; }

        public Henkilo Henkilo { get; set; }

        [Display(Name ="Nimi")]
        public string Kokonimi { get; set; }

        [Display(Name ="Maksupäivä")]
        public DateTime Maksupaiva { get; set; }

        [Display(Name ="Kuukausi")]
        public string Maksukuukausi { get; set; }

        public string Vuosi { get; set; }

        [Display(Name ="Ansiotulo yhteensä")]
        public decimal PalkkaYhteensa { get; set; }

        [Display(Name ="Pidätykset yhteensä")]
        public decimal VahennuksetYhteensa { get; set; }

        public decimal Nettopalkka { get; set; }
    }
}
