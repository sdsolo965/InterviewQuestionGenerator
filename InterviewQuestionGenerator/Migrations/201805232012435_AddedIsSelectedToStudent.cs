namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSelectedToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsSelectedForQuestions", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "IsSelectedForQuestions");
        }
    }
}
