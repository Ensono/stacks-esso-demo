using TestStack.BDDfy;
using Xunit;
using htec.backend.API.FunctionalTests.Tests.Fixtures;
using htec.backend.API.FunctionalTests.Tests.Steps;

namespace htec.backend.API.FunctionalTests.Tests.Stories
{
    //Define the story/feature being tested
    [Story(
        AsA = "restaurant administrator",
        IWant = "to be able to create domains with categories",
        SoThat = "customers know what we have on offer")]
    public class CreateCategoryTests : IClassFixture<AuthFixture>
    {
        private readonly CategorySteps categorySteps;
        private readonly AuthFixture fixture;


        public CreateCategoryTests(AuthFixture fixture)
        {
            //Get instances of the fixture and steps required for the test
            this.fixture = fixture;
            categorySteps = new CategorySteps();
        }
        
        //Add all tests that make up the story to this class.
        [Fact]
        public void Create_category_for_domain()
        {
            this.Given(step => fixture.GivenAUser())
                .And(step => categorySteps.GivenIHaveSpecfiedAFullCategory())
                .When(step => categorySteps.WhenICreateTheCategoryForAnExistingDOMAIN())
                .Then(step => categorySteps.ThenTheCategoryHasBeenCreated())
                .BDDfy();
        }
    }
}