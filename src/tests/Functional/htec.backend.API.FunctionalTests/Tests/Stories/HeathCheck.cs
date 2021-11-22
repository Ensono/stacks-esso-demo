using TestStack.BDDfy;
using Xunit;
using htec.backend.API.FunctionalTests.Tests.Steps;

namespace htec.backend.API.FunctionalTests.Tests.Smoke
{
    public class HeathCheck
    {
        private readonly HealthCheckSteps steps;

        public HeathCheck()
        {
            steps = new HealthCheckSteps();
        }

        [Trait("Category", "SmokeTest")]
        [Fact]
        public void Health_Check_Api()
        {
            this.When(s => steps.ICheckTheApiHealth())
                .Then(s => steps.TheStatusIsHealthy())
                .BDDfy();
        }
    }
}
