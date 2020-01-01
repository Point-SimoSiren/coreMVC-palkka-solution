using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Palkkasovellus.Entity
{
    public class Maksuhistoria
    {
        public int Id { get; set; }
        [ForeignKey("Henkilo")]
        public int HenkiloId { get; set; }
        public Henkilo Henkilo { get; set; }
        [MaxLength(100)]
        public string Kokonimi { get; set; }
        public string Sotu { get; set; }
        public DateTime Maksupaiva { get; set; }
        public string MaksuKuukausi { get; set; }
        [ForeignKey("Verovuosi")]
        public int VerovuosiId { get; set; }
        public Verovuosi Verovuosi { get; set; }
        public string Veronumero { get; set; }
        [Column(TypeName = "money")]
        public decimal Tuntipalkka { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tuntimaara { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SaannollisetTunnit { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ylityotunnit { get; set; }
        [Column(TypeName = "Money")]
        public decimal SaannolPalkka { get; set; }
        [Column(TypeName = "Money")]
        public decimal YlityoPalkka { get; set; }
        [Column(TypeName = "Money")]
        public decimal Ennakonpidatys { get; set; }
        [Column(TypeName = "Money")]
        public decimal Tyoelakemaksu { get; set; }
        [Column(TypeName = "Money")]
        public decimal Sosiaaliturvamaksu { get; set; }
        [Column(TypeName = "Money")]
        public decimal Tyottomyysvakuutus { get; set; }
        [Column(TypeName = "Money")]
        public decimal? Jasenmaksu { get; set; }
        [Column(TypeName = "Money")]
        public decimal PalkkaYhteensa { get; set; }
        [Column(TypeName = "Money")]
        public decimal VahennyksetYhteensa { get; set; }
        [Column(TypeName = "Money")]
        public decimal Nettopalkka { get; set; }
    }
}
