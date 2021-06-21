namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargotakip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Açıklama = c.String(maxLength: 250, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Personel = c.String(maxLength: 20, unicode: false),
                        Alıcı = c.String(maxLength: 20, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipId = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Açıklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
