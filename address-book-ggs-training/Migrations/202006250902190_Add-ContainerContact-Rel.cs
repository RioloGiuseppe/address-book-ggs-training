namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContainerContactRel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Container_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "Container_Id");
            AddForeignKey("dbo.Contacts", "Container_Id", "dbo.Containers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Container_Id", "dbo.Containers");
            DropIndex("dbo.Contacts", new[] { "Container_Id" });
            DropColumn("dbo.Contacts", "Container_Id");
        }
    }
}
