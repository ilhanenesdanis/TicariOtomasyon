using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 karakter yazılabilir")]
        public string CariAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        public bool durum { get; set; }
        
        public ICollection<SatışHareketi> satışHareketis { get; set; }

    }
}