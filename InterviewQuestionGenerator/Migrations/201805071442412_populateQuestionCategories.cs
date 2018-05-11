namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateQuestionCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO QuestionCategories (Id, Category) VALUES (1, 'Behavioral')");
            Sql("INSERT INTO QuestionCategories (Id, Category) VALUES (2, 'Strings')");
            Sql("INSERT INTO QuestionCategories (Id, Category) VALUES (3, 'Arrays')");
            Sql("INSERT INTO QuestionCategories (Id, Category) VALUES (4, 'Alogrithms')");
            Sql("INSERT INTO QuestionCategories (Id, Category) VALUES (5, 'Data Structures')");
            Sql("INSERT INTO QuestionCategories (Id, Category) VALUES (6, 'Design and OOP')");
        }
        
        public override void Down()
        {
        }
    }
}
