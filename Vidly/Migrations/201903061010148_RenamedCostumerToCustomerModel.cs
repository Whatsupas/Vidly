namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedCostumerToCustomerModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Costumers", newName: "Customers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Customers", newName: "Costumers");
        }
    }
}
