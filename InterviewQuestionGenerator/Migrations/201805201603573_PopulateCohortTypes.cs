using System.Web.UI.WebControls;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace InterviewQuestionGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCohortTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CohortTypes (Id, Name) VALUES (1, 'Cloud Application Development')");
            Sql("INSERT INTO CohortTypes (Id, Name) VALUES (2, 'Server and Cloud Administrator')");
            Sql("INSERT INTO CohortTypes (Id, Name) VALUES (3, 'Cybersecurity Administration')");
            Sql("INSERT INTO CohortTypes (Id, Name) VALUES (4, 'Database & Business Intelligence')");
        }
        
        public override void Down()
        {
        }
    }
}
