namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c91524f-525f-407d-a805-b49777502bcf', N'admin@interview.com', 0, N'ADEjoU3Z5m1M4FR81vvLEL9NV4mJRVEjXQSC1miafwW2smpM3EIrYazh0o59oeRmGw==', N'f5e1fb48-19b3-4566-821c-217bd3d35abe', NULL, 0, 0, NULL, 1, 0, N'admin@interview.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3d7097a2-7a29-46a3-a538-8e426c699332', N'guest@interview.com', 0, N'AGXFyQUCMu4x9JXXqXpMGSPMOFNTgio/it7Qgm1qrnF6TzsZ9ECTm8kIhsUoi4bRnQ==', N'ffb72a91-d5ff-494a-b0b8-c630a2c517aa', NULL, 0, 0, NULL, 1, 0, N'guest@interview.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'05357e8d-7be0-4b9a-adcc-59915a574459', N'CanManageStudents')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c91524f-525f-407d-a805-b49777502bcf', N'05357e8d-7be0-4b9a-adcc-59915a574459')
");
        }
        
        public override void Down()
        {
        }
    }
}
