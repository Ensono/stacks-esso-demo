using Newtonsoft.Json;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using htec.redemption.API.FunctionalTests.Builders;
using htec.redemption.API.FunctionalTests.Configuration;
using htec.redemption.API.FunctionalTests.Models;
using htec.redemption.Tests.Api.Builders.Http;

namespace htec.redemption.API.FunctionalTests.Tests.Steps
{
    /// <summary>
    /// These are the steps required for testing the Category endpoints
    /// </summary>
    public class ItemSteps
    {
        private readonly DOMAINSteps domainSteps = new DOMAINSteps();
        private readonly CategorySteps categorySteps = new CategorySteps();
        private readonly string baseUrl;
        private HttpResponseMessage lastResponse;
        private string existingDOMAINId;
        private string existingCategoryId;
        private string existingItemId;
        private DOMAINItemRequest createItemRequest;
        private DOMAINItemRequest updateItemRequest;
        private const string categoryPath = "/category/";
        private const string itemPath = "/items/";

        public ItemSteps()
        {
            var config = ConfigAccessor.GetApplicationConfiguration();
            baseUrl = config.BaseUrl;
        }

        #region Step Definitions

        #region Given

        public void GivenIHaveSpecfiedAFullItem()
        {
            createItemRequest = new DOMAINItemBuilder()
                .SetDefaultValues("Yumido Test Item")
                .Build();
        }

        #endregion Given

        #region When

        public async Task WhenISendAnUpdateItemRequest()
        {
            updateItemRequest = new DOMAINItemBuilder()
                .WithName("Updated item name")
                .WithDescription("Updated item description")
                .WithPrice(4.5)
                .WithAvailablity(true)
                .Build();
            String path =
                $"{DOMAINSteps.domainPath}{existingDOMAINId}{categoryPath}{existingCategoryId}{itemPath}{existingItemId}";

            lastResponse = await HttpRequestFactory.Put(baseUrl, path, updateItemRequest);
        }

        public async Task WhenICreateTheItemForAnExistingDOMAINAndCategory()
        {
            existingDOMAINId = domainSteps.GivenADOMAINAlreadyExists();
            existingCategoryId = await categorySteps.CreateCategoryForSpecificDOMAIN(existingDOMAINId);

            lastResponse = await HttpRequestFactory.Post(baseUrl,
                $"{DOMAINSteps.domainPath}{existingDOMAINId}{categoryPath}{existingCategoryId}{itemPath}", createItemRequest);
            existingItemId = JsonConvert
                .DeserializeObject<CreateObjectResponse>(await lastResponse.Content.ReadAsStringAsync()).id;
        }

        public async Task WhenIDeleteTheItem()
        {
            lastResponse = await HttpRequestFactory.Delete(baseUrl,
                $"{DOMAINSteps.domainPath}{existingDOMAINId}{categoryPath}{existingCategoryId}{itemPath}{existingItemId}");
        }

        #endregion When

        #region Then

        public void ThenTheItemHasBeenCreated()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.Created,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
        }

        public void ThenTheItemHasBeenDeleted()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            //NOTE: check here if the item deleted is not available anymore, like this code below
            //var getCurrentDOMAIN = await HttpRequestFactory.Get(baseUrl, $"{DOMAINSteps.domainPath}{existingDOMAINId}");
            //if (getCurrentDOMAIN.StatusCode == HttpStatusCode.OK)
            //{
            //    var getCurrentDOMAINResponse =
            //        JsonConvert.DeserializeObject<DOMAIN>(await getCurrentDOMAIN.Content.ReadAsStringAsync());
            //    getCurrentDOMAINResponse.categories[0].items.ShouldBeEmpty();
            //}
        }

        public async Task ThenTheItemIsUpdatedCorrectly()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            //NOTE: check here if the item deleted is not available anymore, like this code below
        }

        #endregion Then

        #endregion Step Definitions
    }
}