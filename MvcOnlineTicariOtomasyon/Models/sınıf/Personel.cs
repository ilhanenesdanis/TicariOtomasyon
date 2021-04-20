using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Display(Name ="Personel Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelSoyad   { get; set; }
        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatışHareketi> satışHareketis { get; set; }
        public int DepatmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}