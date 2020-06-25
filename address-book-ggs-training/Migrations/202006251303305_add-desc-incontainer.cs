namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddescincontainer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Containers", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Containers", "Description");
        }
    }
}
