namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prova : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Prova", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Prova");
        }
    }
}
