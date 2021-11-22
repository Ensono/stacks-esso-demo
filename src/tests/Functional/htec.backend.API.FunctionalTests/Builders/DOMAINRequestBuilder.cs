using htec.backend.API.FunctionalTests.Models;

namespace htec.backend.API.FunctionalTests.Builders
{
    public class DOMAINRequestBuilder : IBuilder<DOMAINRequest>
    {
        private DOMAINRequest domain;

        public DOMAINRequestBuilder()
        {
            domain = new DOMAINRequest();
        }

        public DOMAINRequestBuilder SetDefaultValues(string name)
        {
            domain.name = name;
            domain.description = "Updated domain description";
            domain.enabled = true;
            return this;
        }

        public DOMAINRequestBuilder WithName(string name)
        {
            domain.name = name;
            return this;
        }

        public DOMAINRequestBuilder WithDescription(string description)
        {
            domain.description = description;
            return this;
        }

        public DOMAINRequestBuilder SetEnabled(bool enabled)
        {
            domain.enabled = enabled;
            return this;
        }

        public DOMAINRequest Build()
        {
            return domain;
        }
    }
}
