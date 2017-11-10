namespace WebApi2.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryId = c.Long(nullable: false),
                        CityName = c.String(nullable: false, maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryCode = c.String(nullable: false, maxLength: 256),
                        CountryName = c.String(nullable: false, maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        ProfilePicturePath = c.String(),
                        Location = c.String(),
                        PhoneNumber = c.String(),
                        UserStatus = c.Int(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ExternalLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.String(nullable: false, maxLength: 200),
                        Secret = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(nullable: false, maxLength: 200),
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.RefreshTokens",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TokenId = c.String(nullable: false, maxLength: 4000),
                        Subject = c.String(nullable: false, maxLength: 100),
                        ClientId = c.String(nullable: false, maxLength: 200),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.EmailQueues",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FromEmailId = c.String(nullable: false, maxLength: 4000),
                        ToEmailId = c.String(nullable: false, maxLength: 4000),
                        EmailSubject = c.String(nullable: false, maxLength: 4000),
                        MessageBody = c.String(nullable: false, maxLength: 4000),
                        AttachedFiles = c.String(maxLength: 4000),
                        IsSucceedEmailSent = c.Boolean(nullable: false),
                        ErrorMessage = c.String(maxLength: 4000),
                        UpdatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeyGroups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        KeyGroup = c.String(nullable: false, maxLength: 256),
                        LocalizationKeys = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocalizationKeys",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LocalizationKey = c.String(nullable: false, maxLength: 256),
                        EnglishValue = c.String(nullable: false, maxLength: 4000),
                        IrishValue = c.String(nullable: false, maxLength: 4000),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PdfQueues",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CriminalId = c.Long(nullable: false),
                        GeneratedHtml = c.String(nullable: false, maxLength: 4000),
                        ReGenerationRequired = c.Boolean(nullable: false),
                        IsPdfGenerationSucceed = c.Boolean(nullable: false),
                        ErrorMessage = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestQueues",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SearchParameters = c.String(nullable: false, maxLength: 4000),
                        IsRequestSucceed = c.Boolean(nullable: false),
                        ErrorMessage = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefreshTokens", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Claims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ExternalLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.RefreshTokens", new[] { "ClientId" });
            DropIndex("dbo.ExternalLogins", new[] { "UserId" });
            DropIndex("dbo.Claims", new[] { "UserId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.RequestQueues");
            DropTable("dbo.PdfQueues");
            DropTable("dbo.LocalizationKeys");
            DropTable("dbo.KeyGroups");
            DropTable("dbo.EmailQueues");
            DropTable("dbo.RefreshTokens");
            DropTable("dbo.Clients");
            DropTable("dbo.Roles");
            DropTable("dbo.ExternalLogins");
            DropTable("dbo.Users");
            DropTable("dbo.Claims");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
