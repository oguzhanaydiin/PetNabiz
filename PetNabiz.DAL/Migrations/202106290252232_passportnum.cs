namespace PetNabiz.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passportnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PassportNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "PassportNumber");
        }
    }
}
