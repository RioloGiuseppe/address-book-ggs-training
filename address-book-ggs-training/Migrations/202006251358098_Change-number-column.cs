namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changenumbercolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailAddresses", "Email", c => c.String());
            DropColumn("dbo.EmailAddresses", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmailAddresses", "Number", c => c.String());
            DropColumn("dbo.EmailAddresses", "Email");
        }
    }
}
