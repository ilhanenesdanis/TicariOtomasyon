﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class Departman
    {
        [Key]
        public int DepatmanId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> personels { get; set; }

    }
}