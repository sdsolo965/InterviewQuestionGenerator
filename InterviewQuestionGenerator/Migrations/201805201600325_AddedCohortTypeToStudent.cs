namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCohortTypeToStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CohortTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "CohortTypeId", c => c.Byte(nullable: true));
            CreateIndex("dbo.Students", "CohortTypeId");
            AddForeignKey("dbo.Students", "CohortTypeId", "dbo.CohortTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CohortTypeId", "dbo.CohortTypes");
            DropIndex("dbo.Students", new[] { "CohortTypeId" });
            DropColumn("dbo.Students", "CohortTypeId");
            DropTable("dbo.CohortTypes");
        }
    }
}
