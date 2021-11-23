using TestStack.BDDfy;
using Xunit;
using htec.redemption.API.FunctionalTests.Tests.Fixtures;
using htec.redemption.API.FunctionalTests.Tests.Steps;

namespace htec.redemption.API.FunctionalTests.Tests.Functional
{
    //Define the story/feature being tested
    [Story(
        AsA = "user of the Yumido website",
        IWant = "to be able to view specific domains",
        SoThat = "I can choose what to eat")]
    public class GetDOMAINByIdTests : IClassFixture<AuthFixture>
    {
        private readonly AuthFixture fixture;
        private readonly DOMAINSteps steps;

        public GetDOMAINByIdTests(AuthFixture fixture)
        {
            //Get instances of the fixture and steps required for the test
            this.fixture = fixture;
            steps = new DOMAINSteps();
        }

        //Add all tests that make up the story to this class.
        [Fact]
        public void Users_Can_View_Existing_DOMAINs()
        {
            this.Given(s => fixture.GivenAUser())
                //.And(s => steps.GivenADOMAINAlreadyExists())
                .When(s => steps.WhenIGetADOMAIN())
                .Then(s => steps.ThenICanReadTheDOMAINReturned())
                .BDDfy();
        }

        [Fact]
        [Trait("Category", "SmokeTest")]
        public void Admins_Can_View_Existing_DOMAINs()
        {
            this.Given(s => fixture.GivenAnAdmin())
                //.And(s => steps.GivenADOMAINAlreadyExists())
                .When(s => steps.WhenIGetADOMAIN())
                .Then(s => steps.ThenICanReadTheDOMAINReturned())
                .BDDfy();
        }
    }
}
