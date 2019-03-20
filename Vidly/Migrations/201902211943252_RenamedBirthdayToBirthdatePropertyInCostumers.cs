namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedBirthdayToBirthdatePropertyInCostumers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Costumers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Costumers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Costumers", "Birthday", c => c.DateTime());
            DropColumn("dbo.Costumers", "Birthdate");
        }
    }
}
