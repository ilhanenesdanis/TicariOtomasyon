using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        //alttaki şu anlama geliyor her bir kategoride birden fazla ürün yer alabilir
        public ICollection<Ürünler> Ürünlers { get; set; }
    }
}