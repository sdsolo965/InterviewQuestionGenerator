using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterviewQuestionGenerator.Startup))]
namespace InterviewQuestionGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
