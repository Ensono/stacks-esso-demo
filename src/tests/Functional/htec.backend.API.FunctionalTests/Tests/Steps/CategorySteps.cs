using Newtonsoft.Json;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using htec.backend.API.FunctionalTests.Builders;
using htec.backend.API.FunctionalTests.Configuration;
using htec.backend.API.FunctionalTests.Models;
using htec.backend.Tests.Api.Builders.Http;

namespace htec.backend.API.FunctionalTests.Tests.Steps
{
    /// <summary>
    /// These are the steps required for testing the Category endpoints
    /// </summary>
    public class CategorySteps
    {
        private readonly string baseUrl;
        private HttpResponseMessage lastResponse;
        private string existingDOMAINId;
        private CategoryRequest createCategoryRequest;
        private CategoryRequest updateCategoryRequest;
        private string existingCategoryId;
        private const string categoryPath = "/category/";
        private readonly DOMAINSteps domainSteps = new DOMAINSteps();

        public CategorySteps()
        {
            var config = ConfigAccessor.GetApplicationConfiguration();
            baseUrl = config.BaseUrl;
        }

        #region Step Definitions

        #region Given

        public void GivenIHaveSpecfiedAFullCategory()
        {
            createCategoryRequest = new CategoryRequestBuilder()
                .SetDefaultValues("Yumido Test Category")
                .Build();
        }

        #endregion Given

        #region When

        public async Task<string> WhenICreateTheCategoryForAnExistingDOMAIN()
        {
            existingDOMAINId = domainSteps.GivenADOMAINAlreadyExists();

            lastResponse = await HttpRequestFactory.Post(baseUrl,
                $"{DOMAINSteps.domainPath}{existingDOMAINId}{categoryPath}", createCategoryRequest);

            existingCategoryId = JsonConvert
                .DeserializeObject<CreateObjectResponse>(await lastResponse.Content.ReadAsStringAsync()).id;
            
            return existingCategoryId;
        }

        public async Task<string> CreateCategoryForSpecificDOMAIN(String domainId)
        {
            lastResponse = await HttpRequestFactory.Post(baseUrl,
                $"{DOMAINSteps.domainPath}{domainId}{categoryPath}",
                new CategoryRequestBuilder()
                    .SetDefaultValues("Yumido Test Category")
                    .Build());

            existingCategoryId = JsonConvert
                .DeserializeObject<CreateObjectResponse>(await lastResponse.Content.ReadAsStringAsync()).id;
            return existingCategoryId;
        }

        public async Task WhenISendAnUpdateCategoryRequest()
        {
            updateCategoryRequest = new CategoryRequestBuilder()
                .WithName("Updated Category Name")
                .WithDescription("Updated Category Description")
                .Build();
            String path = $"{DOMAINSteps.domainPath}{domainSteps.existingDOMAINId}{categoryPath}{existingCategoryId}";

            lastResponse = await HttpRequestFactory.Put(baseUrl, path, updateCategoryRequest);
        }

        public async Task WhenIDeleteTheCategory()
        {
            lastResponse = await HttpRequestFactory.Delete(baseUrl,
                $"{DOMAINSteps.domainPath}{existingDOMAINId}{categoryPath}{existingCategoryId}");
        }

        #endregion When

        #region Then

        public void ThenTheCategoryHasBeenCreated()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.Created,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
        }

        public void ThenTheCategoryHasBeenDeleted()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            //NOTE: add here validations other than the response StatusCode. For example, code trying to get the deleted record
            //var getCurrentDOMAIN = await HttpRequestFactory.Get(baseUrl, $"{DOMAINSteps.domainPath}{existingDOMAINId}");
            //if (getCurrentDOMAIN.StatusCode == HttpStatusCode.OK)
            //{
            //    var getCurrentDOMAINResponse =
            //        JsonConvert.DeserializeObject<DOMAIN>(await getCurrentDOMAIN.Content.ReadAsStringAsync());
            //    getCurrentDOMAINResponse.categories.ShouldBeEmpty();
            //}
        }

        public async Task ThenTheCategoryIsUpdatedCorrectly()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            //NOTE: add here validations other than the response StatusCode. For example, code trying to get the deleted record
        }

        #endregion Then

        #endregion Step Definitions
    }
}