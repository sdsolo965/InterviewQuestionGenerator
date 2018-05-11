namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InterviewQuestions", "Question", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.InterviewQuestions", "Question", c => c.String());
        }
    }
}
