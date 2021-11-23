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
    /// These are the steps required for testing the DOMAIN endpoints
    /// </summary>
    public class DOMAINSteps
    {
        private DOMAINRequest createDOMAINRequest;
        private DOMAINRequest updateDOMAINRequest;
        private HttpResponseMessage lastResponse;
        public string existingDOMAINId;
        private readonly string baseUrl;
        public const string domainPath = "v1/domain/";

        public DOMAINSteps()
        {
            var config = ConfigAccessor.GetApplicationConfiguration();
            baseUrl = config.BaseUrl;
        }

        #region Step Definitions

        #region Given

        public void GivenIHaveSpecfiedAFullDOMAIN()
        {
            createDOMAINRequest = new DOMAINRequestBuilder()
                .SetDefaultValues("Yumido Test DOMAIN")
                .Build();
        }

        #endregion Given

        #region When

        public async Task WhenISendAnUpdateDOMAINRequest()
        {
            updateDOMAINRequest = new DOMAINRequestBuilder()
                .WithName("Updated DOMAIN Name")
                .WithDescription("Updated Description")
                .SetEnabled(true)
                .Build();

            lastResponse = await HttpRequestFactory.Put(baseUrl, $"{domainPath}{existingDOMAINId}", updateDOMAINRequest);
        }

        public string GivenADOMAINAlreadyExists()
        {
            //NOTE: create here with post and return id. Any id will work in this case, as the API is not persisting data
            existingDOMAINId = Guid.NewGuid().ToString();
            return existingDOMAINId;
        }

        public async Task WhenICreateTheDOMAIN()
        {
            lastResponse = await HttpRequestFactory.Post(baseUrl, domainPath, createDOMAINRequest);
        }

        public async Task WhenIDeleteADOMAIN()
        {
            lastResponse = await HttpRequestFactory.Delete(baseUrl, $"{domainPath}{existingDOMAINId}");
        }

        public async Task WhenIGetADOMAIN()
        {
            lastResponse = await HttpRequestFactory.Get(baseUrl, $"{domainPath}{existingDOMAINId}");
        }

        #endregion When

        #region Then

        public void ThenTheDOMAINHasBeenCreated()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.Created,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
        }

        public void ThenTheDOMAINHasBeenDeleted()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
        }

        public async Task ThenICanReadTheDOMAINReturned()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.OK,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            var responseDOMAIN = JsonConvert.DeserializeObject<DOMAIN>(await lastResponse.Content.ReadAsStringAsync());
            responseDOMAIN.ShouldNotBeNull();

            //NOTE: compare the initial request sent to the API against the actual response
            //Not doable here because the response given in the API is not related to the request, currently
        }

        public async Task ThenTheDOMAINIsUpdatedCorrectly()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            //NOTE: compare the initial request sent to the API against the actual response
        }

        #endregion Then

        #endregion Step Definitions
    }
}