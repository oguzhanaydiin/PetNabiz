namespace PetNabiz.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class treatment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassportNumber = c.String(),
                        VetName = c.String(),
                        Info = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Treatments");
        }
    }
}
