namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Street1 = c.String(nullable: false),
                        Street2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsACompany = c.Boolean(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        EstimatedAmount = c.Decimal(precision: 18, scale: 2),
                        CurrentStatus = c.Int(nullable: false),
                        EstimatedTime = c.DateTime(),
                        DueDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        Language = c.String(),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Note_Comment = c.String(nullable: false),
                        Topic = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        UserName = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        PlatformId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlatformId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        BilledHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BilledAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        TaskName = c.String(nullable: false),
                        IsBug = c.Boolean(nullable: false),
                        TotalTimeSpent = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        Current_Status = c.Int(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
            CreateTable(
                "dbo.ClientProjects",
                c => new
                    {
                        Client_ClientId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_ClientId, t.Project_ProjectId })
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.Client_ClientId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.AspNetUserAspNetRoles",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.AspNetRole_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserLogins", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClientProjects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ClientProjects", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Platforms", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Notes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Phones", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Addresses", "ClientId", "dbo.Clients");
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.ClientProjects", new[] { "Project_ProjectId" });
            DropIndex("dbo.ClientProjects", new[] { "Client_ClientId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Platforms", new[] { "ProjectId" });
            DropIndex("dbo.Notes", new[] { "ProjectId" });
            DropIndex("dbo.Phones", new[] { "ClientId" });
            DropIndex("dbo.Addresses", new[] { "ClientId" });
            DropTable("dbo.AspNetUserAspNetRoles");
            DropTable("dbo.ClientProjects");
            DropTable("dbo.Tasks");
            DropTable("dbo.Invoices");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Platforms");
            DropTable("dbo.Notes");
            DropTable("dbo.Projects");
            DropTable("dbo.Phones");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
