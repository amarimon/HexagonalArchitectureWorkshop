using System;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using API;

namespace TestAPI
{
    [Binding]
    public class APICreateUserSteps : IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }

        protected HttpResponseMessage Response { get; set; }
        public APICreateUserSteps(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
        }

        /*[When(@"I make a post request to ""(.*)"" with the following data ""(.*)""")]
        public async Task WhenIMakeAPostRequestToWithTheFollowingDataAsync(string resourceEndPoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }*/

        [When(@"I make a post request to ""(.*)"" with the following data")]
        public async Task WhenIMakeAPostRequestToWithTheFollowingData(string resourceEndPoint, string postDataJson)
        {
            var postRelativeUri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(postRelativeUri, content).ConfigureAwait(false);
        }

        [When(@"I make a get request to ""(.*)"" with the following data ""(.*)""")]
        public async Task WhenIMakeAGetRequestToWithTheFollowingData(string resourceEndPoint, string UserId)
        {
            var getRelativeUri = new Uri(resourceEndPoint + "/" + UserId, UriKind.Relative);
            Response = await _client.GetAsync(getRelativeUri).ConfigureAwait(false);
        }


        [Then(@"the response status code is ""(.*)""")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }

        [Then(@"the response data should be ""(.*)""")]
        public void ThenTheResponseDataShouldBe(string expectedResponse)
        {
            var responseData = Response.Content.ReadAsStringAsync().Result;
            Assert.Equal(expectedResponse, responseData);
        }
    }
}
