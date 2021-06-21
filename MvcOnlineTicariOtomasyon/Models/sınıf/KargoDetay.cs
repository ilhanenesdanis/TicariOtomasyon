using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class KargoDetay
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(250)]
        public string Açıklama { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Alıcı { get; set; }
        public DateTime Tarih { get; set; }
    }
}