using TestStack.BDDfy;
using Xunit;
using htec.backend.API.FunctionalTests.Tests.Fixtures;
using htec.backend.API.FunctionalTests.Tests.Steps;

namespace htec.backend.API.FunctionalTests.Tests.Functional
{
    //Define the story/feature being tested
    [Story(
        AsA = "restaurant administrator",
        IWant = "to be able to create domains",
        SoThat = "customers know what we have on offer")]

    public class CreateDOMAINTests : IClassFixture<AuthFixture>
    {
        private readonly DOMAINSteps steps;
        private readonly AuthFixture fixture;

        public CreateDOMAINTests(AuthFixture fixture)
        {
            //Get instances of the fixture and steps required for the test
            this.fixture = fixture;
            steps = new DOMAINSteps();
        }

        //Add all tests that make up the story to this class.
        [Fact]
        public void Create_a_domain()
        {
            this.Given(step => fixture.GivenAUser())
                .Given(step => steps.GivenIHaveSpecfiedAFullDOMAIN())
                .When(step => steps.WhenICreateTheDOMAIN())
                .Then(step => steps.ThenTheDOMAINHasBeenCreated())
                .BDDfy();
        }
    }
}
