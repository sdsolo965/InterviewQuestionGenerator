namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InterviewQuestions", "Section");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterviewQuestions", "Section", c => c.String());
        }
    }
}
