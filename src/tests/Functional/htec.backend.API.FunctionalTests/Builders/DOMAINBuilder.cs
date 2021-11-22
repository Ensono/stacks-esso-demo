using System;
using System.Collections.Generic;
using htec.backend.API.FunctionalTests.Models;

namespace htec.backend.API.FunctionalTests.Builders
{
    public class DOMAINBuilder : IBuilder<DOMAIN>
    {
        private DOMAIN domain;

        public DOMAINBuilder()
        {
            domain = new DOMAIN();
        }


        public DOMAINBuilder SetDefaultValues(string name)
        {
            var categoryBuilder = new CategoryBuilder();

            domain.id = Guid.NewGuid().ToString();
            domain.name = name;
            domain.description = "Default test domain description";
            domain.enabled = true;
            domain.categories = new List<Category>()
            {
                categoryBuilder.SetDefaultValues("Burgers")
                .Build()
            };

            return this;
        }

        public DOMAINBuilder WithId(Guid id)
        {
            domain.id = id.ToString();
            return this;
        }

        public DOMAINBuilder WithName(string name)
        {
            domain.name = name;
            return this;
        }

        public DOMAINBuilder WithDescription(string description)
        {
            domain.description = description;
            return this;
        }

        public DOMAINBuilder WithNoCategories()
        {
            domain.categories = new List<Category>();
            return this;
        }

        public DOMAINBuilder WithCategories(List<Category> categories)
        {
            domain.categories = categories;
            return this;
        }

        public DOMAINBuilder SetEnabled(bool enabled)
        {
            domain.enabled = enabled;
            return this;
        }

        public DOMAIN Build()
        {
            return domain;
        }
    }
}
