namespace reg_claim4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ad_users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        UserName = c.String(),
                        DisplayName = c.String(),
                        role = c.String(),
                        group = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        NameGroups = c.String(),
                        Ad_users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ad_users", t => t.Ad_users_Id)
                .Index(t => t.Ad_users_Id);
            
            CreateTable(
                "dbo.claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserNameFrom = c.String(),
                        UserNameWhom = c.String(),
                        GroupWhom = c.String(),
                        ClaimeName = c.String(),
                        claimBody = c.String(),
                        dataTimeOpen = c.DateTime(nullable: false),
                        dataTimeEnd = c.DateTime(nullable: false),
                        evants = c.String(),
                        parents = c.String(),
                        category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        events = c.String(),
                        dataTime = c.DateTime(nullable: false),
                        pc_ip = c.String(),
                        pc_name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Ad_users_Id", "dbo.Ad_users");
            DropIndex("dbo.Groups", new[] { "Ad_users_Id" });
            DropTable("dbo.logs");
            DropTable("dbo.claims");
            DropTable("dbo.Groups");
            DropTable("dbo.Ad_users");
        }
    }
}
