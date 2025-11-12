using Saucedemo.PlaywrightTests;
using Saucedemo.PlaywrightTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.PlaywrightTests.Tests
{
    internal class ConfigManagerTest
    {

        [Test]
        public async Task ConfigManagerDeserealisationTest()
        {
            //Assert.That(13, Is.EqualTo(13) );
            //Assert.That(true, Is. );
            // Is.InRange(13, 15)

            TestSettings testSettings = await ConfigManager.GetConfig();

            Assert.That(testSettings.UserName, Does.Match("standard_user"));
            Assert.That(testSettings.Password, Does.Match("secret_sauce"));
            Assert.That(testSettings.Browser, Is.EqualTo("chromium"));

            Assert.That(testSettings.Headless, Is.False );
            Assert.That(testSettings.Timeout, Is.EqualTo(1000));
            Assert.That(testSettings.SlowMo, Is.EqualTo(500));
            Assert.That(testSettings.BaseURL, Is.EqualTo("https://www.saucedemo.com/v1/"));

            var itemsToBuy = new string[] { "Sauce Labs Bike Light", "Sauce Labs Fleece Jacket", "Sauce Labs Onesie" };
            Assert.That(testSettings.ItemsToBuy, Is.EquivalentTo(itemsToBuy));            
        }
    }
}
