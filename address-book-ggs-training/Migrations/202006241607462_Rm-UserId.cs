namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RmUserId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Containers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Containers", "UserId", c => c.String());
        }
    }
}
