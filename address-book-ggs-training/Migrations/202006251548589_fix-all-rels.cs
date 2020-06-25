namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixallrels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailAddresses", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.TelephoneNumbers", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.EmailAddresses", new[] { "Contact_Id" });
            DropIndex("dbo.TelephoneNumbers", new[] { "Contact_Id" });
            RenameColumn(table: "dbo.EmailAddresses", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.TelephoneNumbers", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.Containers", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Containers", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AlterColumn("dbo.EmailAddresses", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.TelephoneNumbers", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmailAddresses", "ContactId");
            CreateIndex("dbo.TelephoneNumbers", "ContactId");
            AddForeignKey("dbo.EmailAddresses", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TelephoneNumbers", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            DropColumn("dbo.Contacts", "Prova");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Prova", c => c.String());
            DropForeignKey("dbo.TelephoneNumbers", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.EmailAddresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.TelephoneNumbers", new[] { "ContactId" });
            DropIndex("dbo.EmailAddresses", new[] { "ContactId" });
            AlterColumn("dbo.TelephoneNumbers", "ContactId", c => c.Int());
            AlterColumn("dbo.EmailAddresses", "ContactId", c => c.Int());
            RenameIndex(table: "dbo.Containers", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Containers", name: "UserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.TelephoneNumbers", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.EmailAddresses", name: "ContactId", newName: "Contact_Id");
            CreateIndex("dbo.TelephoneNumbers", "Contact_Id");
            CreateIndex("dbo.EmailAddresses", "Contact_Id");
            AddForeignKey("dbo.TelephoneNumbers", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.EmailAddresses", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
