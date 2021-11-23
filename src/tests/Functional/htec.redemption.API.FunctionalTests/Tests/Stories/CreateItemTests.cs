using TestStack.BDDfy;
using Xunit;
using htec.redemption.API.FunctionalTests.Tests.Fixtures;
using htec.redemption.API.FunctionalTests.Tests.Steps;

namespace htec.redemption.API.FunctionalTests.Tests.Stories
{
    //Define the story/feature being tested
    [Story(
        AsA = "restaurant administrator",
        IWant = "to be able to create domains with categories and items",
        SoThat = "customers know what we have on offer")]
    public class CreateItemTests : IClassFixture<AuthFixture>
    {
        private readonly ItemSteps itemSteps;
        private readonly AuthFixture fixture;


        public CreateItemTests(AuthFixture fixture)
        {
            //Get instances of the fixture and steps required for the test
            this.fixture = fixture;
            itemSteps = new ItemSteps();
        }
        
        //Add all tests that make up the story to this class.
        [Fact]
        public void Create_item_for_domain()
        {
            this.Given(step => fixture.GivenAUser())
                .And(step => itemSteps.GivenIHaveSpecfiedAFullItem())
                .When(step => itemSteps.WhenICreateTheItemForAnExistingDOMAINAndCategory())
                .Then(step => itemSteps.ThenTheItemHasBeenCreated())
                .BDDfy();
        }
    }
}