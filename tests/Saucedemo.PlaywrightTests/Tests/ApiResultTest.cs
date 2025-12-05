using Microsoft.Playwright;
using Saucedemo.PlaywrightTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Saucedemo.PlaywrightTests.Tests
{
    internal class ApiResultTest : PlaywrightBaseFixture
    {

        private IAPIRequestContext Request = null!;

        [Test]
        public async Task ApiTest() 
        {
            //var f = await this.Playwright.APIRequest.NewContextAsync(new()
            //{
            //    // All requests we send go to this API endpoint.
            //    BaseURL = "https://api.github.com",
            //    ExtraHTTPHeaders = headers,
            //});

            //Api.PostAsync()
            IAPIResponse apiResponse =  await Api.GetAsync("/posts/1");

            JsonElement? jsonEL = await apiResponse.JsonAsync();

            //jsonEL.
            Assert.That(apiResponse.Ok, Is.True, "Expected HTTP response to be OK (2xx).");

            var json = jsonEL.Value;


            JsonplaceholderClass jsonplaceholderClass = json.Deserialize<JsonplaceholderClass>()!;
            //Assert.That(, Is.True)


            //JsonSerializer.Deserialize()

        }
    }
}
