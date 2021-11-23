using TestStack.BDDfy;
using Xunit;
using htec.redemption.API.FunctionalTests.Tests.Fixtures;
using htec.redemption.API.FunctionalTests.Tests.Steps;

namespace htec.redemption.API.FunctionalTests.Tests.Functional
{
    //Define the story/feature being tested
    [Story(AsA = "Administrator of a restaurant",
        IWant = "To be able to delete old domains",
        SoThat = "Customers do not see out of date options")]
    public class DeleteDOMAINTests : IClassFixture<AuthFixture>
    {
        private readonly DOMAINSteps steps;
        private readonly AuthFixture fixture;

        public DeleteDOMAINTests(AuthFixture fixture)
        {
            //Get instances of the fixture and steps required for the test
            this.fixture = fixture;
            steps = new DOMAINSteps();
        }

        //Add all tests that make up the story to this class
        [Fact]
        public void Admins_Can_Delete_DOMAINs()
        {
            this.Given(step => fixture.GivenAUser())
                .And(step => steps.GivenADOMAINAlreadyExists())
                .When(step => steps.WhenIDeleteADOMAIN())
                .Then(step => steps.ThenTheDOMAINHasBeenDeleted())
                .BDDfy();
        }
    }
}
