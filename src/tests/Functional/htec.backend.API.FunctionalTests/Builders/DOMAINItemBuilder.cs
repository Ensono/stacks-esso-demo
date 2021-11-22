using htec.backend.API.FunctionalTests.Models;

namespace htec.backend.API.FunctionalTests.Builders
{
    public class DOMAINItemBuilder : IBuilder<DOMAINItemRequest>
    {
        private readonly DOMAINItemRequest domainItem;

        public DOMAINItemBuilder()
        {
            domainItem = new DOMAINItemRequest();
        }

        public DOMAINItemBuilder WithName(string name)
        {
            domainItem.name = name;
            return this;
        }

        public DOMAINItemBuilder WithDescription(string description)
        {
            domainItem.description = description;
            return this;
        }

        public DOMAINItemBuilder WithPrice(double price)
        {
            domainItem.price = price;
            return this;
        }

        public DOMAINItemBuilder WithAvailablity(bool available)
        {
            domainItem.available = available;
            return this;
        }

        public DOMAINItemRequest Build()
        {
            return domainItem;
        }
        
        public DOMAINItemBuilder SetDefaultValues(string name)
        {
            domainItem.name = name;
            domainItem.description = "Item description";
            domainItem.price = 12.50;
            domainItem.available = true;
            return this;
        }
    }
}
