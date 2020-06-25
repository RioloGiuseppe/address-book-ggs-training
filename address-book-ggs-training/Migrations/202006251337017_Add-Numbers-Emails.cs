namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumbersEmails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Type = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.TelephoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Type = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelephoneNumbers", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.EmailAddresses", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.TelephoneNumbers", new[] { "Contact_Id" });
            DropIndex("dbo.EmailAddresses", new[] { "Contact_Id" });
            DropTable("dbo.TelephoneNumbers");
            DropTable("dbo.EmailAddresses");
        }
    }
}
