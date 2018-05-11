namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.InterviewQuestions", "QuestionCategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.InterviewQuestions", "QuestionCategoryId");
            AddForeignKey("dbo.InterviewQuestions", "QuestionCategoryId", "dbo.QuestionCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.InterviewQuestions", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewQuestions", "Category", c => c.String());
            DropForeignKey("dbo.InterviewQuestions", "QuestionCategoryId", "dbo.QuestionCategories");
            DropIndex("dbo.InterviewQuestions", new[] { "QuestionCategoryId" });
            DropColumn("dbo.InterviewQuestions", "QuestionCategoryId");
            DropTable("dbo.QuestionCategories");
        }
    }
}
