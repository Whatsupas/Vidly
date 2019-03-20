namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Movies",
                    m => new
                    {
                        Id = m.Int(nullable: false, identity: true),
                        Name = m.String(nullable: false),
                        DateAdded = m.DateTime(nullable: false),
                        ReleaseDate = m.DateTime(nullable: false),
                        NumberInStock = m.Int(nullable: false),
                        GenreId = m.Byte(nullable:false)

                    })
                    .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
