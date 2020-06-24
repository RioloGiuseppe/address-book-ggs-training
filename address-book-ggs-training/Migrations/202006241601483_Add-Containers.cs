﻿namespace address_book_ggs_training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContainers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Containers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Containers");
        }
    }
}
