using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class Ürünler
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlışFiyat { get; set; }
        public decimal SatışFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int kategoriid { get; set; }
        public virtual Kategori kategori { get; set; }
        public ICollection<SatışHareketi> satışHareketis { get; set; }
    }
}