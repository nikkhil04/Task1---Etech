namespace WEBAPPMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WEBAPPMVC1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MODEL1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        itemName = c.String(),
                        itemPrice = c.Int(nullable: false),
                        itemImagestring = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MODEL1");
        }
    }
}
