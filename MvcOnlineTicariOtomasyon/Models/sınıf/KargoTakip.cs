using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Açıklama { get; set; }
        public DateTime Tarih { get; set; }

    }
}