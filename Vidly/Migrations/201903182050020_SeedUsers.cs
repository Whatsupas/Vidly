namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'40e9a700-9f69-4edd-a7df-8ce6ebc45583', N'Admin@vidly.com', 0, N'AOWsqhVmGqpFpVemmHXsM8WrcVtc9ZTi/hGl9fd5sXVC9c+CtRI2oNsBBfIwJ+hsQw==', N'19b3f40e-de6d-4932-b9a1-d40c45dc14de', NULL, 0, 0, NULL, 1, 0, N'Admin@vidly.com', N'CBA321', N'987654321')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'd1af0b01-d8f6-49ea-bf9e-8edb9ace316a', N'Guest@vidly.com', 0, N'AI6IjQhQQCU4YlfZUYHAEwmWIyMYH/xe9W4bpS+cDSPeBN5rE5p6YkiGBQOdpEAgrg==', N'8c4a9abe-0889-4864-a8e0-3e341bb4f7a8', NULL, 0, 0, NULL, 1, 0, N'Guest@vidly.com', N'ABC123', N'123456789')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b9b3efc5-6d3b-4969-a849-16fda0f2a644', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'40e9a700-9f69-4edd-a7df-8ce6ebc45583', N'b9b3efc5-6d3b-4969-a849-16fda0f2a644')
               ");
        }
        public override void Down()
        {
        }
    }
}
