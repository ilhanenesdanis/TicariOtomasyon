using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcOnlineTicariOtomasyon.Models.sınıf
{
    public class Context:DbContext
    {
        //burayı tabloları sql e yansıtmadan önceki son kısım
        public DbSet<Admin> admins { get; set; }
        public DbSet<Cariler> carilers { get; set; }
        public DbSet<Departman> departmen { get; set; }
        public DbSet<FaturaKalem> faturaKalems { get; set; }
        public DbSet<Faturalar> faturalars { get; set; }
        public DbSet<Giderler> giderlers { get; set; }
        public DbSet<Kategori> kategoris { get; set; }
        public DbSet<Personel> personels { get; set; }
        public DbSet<SatışHareketi> satışHareketis { get; set; }
        public DbSet<Ürünler> ürünlers { get; set; }
        public DbSet<Detay> detays { get; set; }
        public DbSet<ToDo> toDos { get; set; }

    }
}