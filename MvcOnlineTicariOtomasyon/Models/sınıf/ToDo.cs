using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName ="Varchar")]
        [StringLength(150)]
        public string Baslık { get; set; }
        [Column(TypeName ="bit")]
        public bool Durum { get; set; }



    }
}