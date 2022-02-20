namespace Simplex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ec36c21f-3001-48fe-9dd1-95d553901ae0', N'CanManageCustomer')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'00732d30-331b-4db0-b1b9-8d65bf2c596c', N'guest@simplex.com', 0, N'ABB5NGF/6K+ufSzs55VUaDp6xN+zC9ULgA6gqwp0S/FkbjnM2hW8TxsHuVO1g2WXMA==', N'b2310bad-7a01-4758-bbfb-e89e70544b55', NULL, 0, 0, NULL, 1, 0, N'guest@simplex.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb680a9a-7d8b-407e-b4cf-a39cd293a11d', N'admin@simplex.com', 0, N'AAFqTQcmH3D+8DjhukvbZWr6TGCNBf43GvUIQ4Vpf/kQLGQyBZdvOlvrzsAwkAQWsw==', N'bbaa8a76-4342-4968-947a-722b1ef6ec49', NULL, 0, 0, NULL, 1, 0, N'admin@simplex.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb680a9a-7d8b-407e-b4cf-a39cd293a11d', N'ec36c21f-3001-48fe-9dd1-95d553901ae0')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
