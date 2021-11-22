using TestStack.BDDfy;
using Xunit;
using htec.backend.API.FunctionalTests.Tests.Fixtures;
using htec.backend.API.FunctionalTests.Tests.Steps;

namespace htec.backend.API.FunctionalTests.Tests.Functional
{
    //Define the story/feature being tested
    [Story(AsA = "Administrator for a restaurant",
        IWant = "To be able to update existing domains",
        SoThat = "The domains are always showing our latest offerings"
        )]
    public class UpdateDOMAINById : IClassFixture<AuthFixture>
    {
        private readonly AuthFixture fixture;
        private readonly DOMAINSteps steps;

        public UpdateDOMAINById(AuthFixture fixture)
        {
            //Get instances of the fixture and steps required for the test
            this.fixture = fixture;
            steps = new DOMAINSteps();
        }

        //Add all tests that make up the story to this class
        [Fact]
        public void Admins_Can_Update_Existing_DOMAINs()
        {
            this.Given(s => fixture.GivenAnAdmin())
                .And(s => steps.GivenADOMAINAlreadyExists())
                .When(s => steps.WhenISendAnUpdateDOMAINRequest())
                .Then(s => steps.ThenTheDOMAINIsUpdatedCorrectly())
                .BDDfy();
        }
    }
}
