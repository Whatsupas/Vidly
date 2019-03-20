namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFree = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Costumers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Costumers", "MembershipTypeId");
            AddForeignKey("dbo.Costumers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Costumers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Costumers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Costumers", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
