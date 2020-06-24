namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RmProva : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Prova");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Prova", c => c.String());
        }
    }
}
