namespace MISA.Entities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Refs",
                c => new
                    {
                        RefID = c.Guid(nullable: false, defaultValueSql: "newid()", identity: true),
                        RefDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        RefNo = c.String(nullable: false),
                        RefType = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContactName = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.RefID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Refs");
        }
    }
}
