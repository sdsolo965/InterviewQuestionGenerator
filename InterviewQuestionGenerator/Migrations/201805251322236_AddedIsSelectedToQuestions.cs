namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSelectedToQuestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InterviewQuestions", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterviewQuestions", "IsSelected");
        }
    }
}
