using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Palkkasovellus.Entity
{
    public class Henkilo
    {
        public int Id { get; set; }
        [Required]
        public string HenkiloNro { get; set; }
        [Required, MaxLength(50)]
        public string Etunimi { get; set; }
        [MaxLength(50)]
        public string ToinenNimi { get; set; }
        [Required, MaxLength(50)]
        public string Sukunimi { get; set; }
        public string Kokonimi { get; set; }
        public string Sukupuoli { get; set; }
        public string KuvaUrl { get; set; }
        public DateTime SyntymaAika { get; set; }
        public DateTime AloitusPvm { get; set; }
        public string Tehtava { get; set; }
        public string Sahkoposti { get; set; }
        public string Puhelin { get; set; }
        [Required, MaxLength(50)]
        public string SosTurvaTunnus { get; set; }
        public Maksutapa Maksutapa { get; set; }
        public LiitonJasen LiitonJasen { get; set; }
        [Required, MaxLength(150)]
        public string Osoite { get; set; }
        [Required, MaxLength(50)]
        public string Kaupunki { get; set; }
        [Required, MaxLength(50)]
        public string Postinro { get; set; }
        public IEnumerable<Maksutapahtuma> Maksutapahtuma { get; set; }

    }
}
