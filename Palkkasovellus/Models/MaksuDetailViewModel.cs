using Palkkasovellus.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Palkkasovellus.Models
{
    public class MaksuDetailViewModel
    {
        public int Id { get; set; }        

        public int HenkiloId { get; set; }

        public Henkilo Henkilo { get; set; }

        [Display(Name = "Henkilö")]
        public string Kokonimi { get; set; }

        public string Sotu { get; set; }

        [DataType(DataType.Date), Display(Name = "Maksupäivä")]
        public DateTime Maksupaiva { get; set; }

        public string Maksukuukausi { get; set; }

        public string Vuosi { get; set; }

        public string Veronumero { get; set; } 
        
        public decimal Tuntipalkka { get; set; }

        [Display(Name = "Tehdyt tunnit")]
        public decimal TehdytTunnit { get; set; }

        [Display(Name = "Säännöllliset tunnit")]
        public decimal SaannolTunnit { get; set; }

        [Display(Name = "Ylityötunnit")]
        public decimal Ylityotunnit { get; set; }

        [Display(Name = "Ylityön tuntipalkka")]
        public decimal YlityoTuntipalkka { get; set; }

        [Display(Name = "Säännöllinen palkka")]
        public decimal SaannolPalkka { get; set; }

        [Display(Name = "Ylityön palkka")]
        public decimal Ylityopalkka { get; set; }

        public decimal Veroprosentti { get; set; }

        public decimal Tuloraja { get; set; }

        [Display(Name = "Lisäprosentti")]
        public decimal Lisaprosentti { get; set; }

        [Display(Name = "Ennakonpidätys")]
        public decimal Vero { get; set; }

        [Display(Name = "Eläkemaksu")]
        public decimal Elakemaksu { get; set; }

        [Display(Name = "Jäsenmaksu")]
        public decimal Jasenmaksu { get; set; }

        public decimal Sotumaksu { get; set; }

        [Display(Name = "Työttömyysvakuutusmaksu")]
        public decimal Tyottomyysvakuutus { get; set; }

        [Display(Name = "Palkka yhteensä")]
        public decimal PalkkaYhteensa { get; set; }

        [Display(Name = "Pidätykset yhteensä")]
        public decimal VahennuksetYhteensa { get; set; }

        public decimal Nettopalkka { get; set; }
    }
}
