namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testmig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Container_Id", "dbo.Containers");
            DropIndex("dbo.Contacts", new[] { "Container_Id" });
            RenameColumn(table: "dbo.Contacts", name: "Container_Id", newName: "ContainerId");
            AddColumn("dbo.Contacts", "Prova", c => c.String());
            AlterColumn("dbo.Contacts", "ContainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "ContainerId");
            AddForeignKey("dbo.Contacts", "ContainerId", "dbo.Containers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ContainerId", "dbo.Containers");
            DropIndex("dbo.Contacts", new[] { "ContainerId" });
            AlterColumn("dbo.Contacts", "ContainerId", c => c.Int());
            DropColumn("dbo.Contacts", "Prova");
            RenameColumn(table: "dbo.Contacts", name: "ContainerId", newName: "Container_Id");
            CreateIndex("dbo.Contacts", "Container_Id");
            AddForeignKey("dbo.Contacts", "Container_Id", "dbo.Containers", "Id");
        }
    }
}
