using Microsoft.Playwright;
using NUnit;
using Saucedemo.PlaywrightTests.Fixtures;
using Saucedemo.PlaywrightTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.PlaywrightTests.Tests
{
    /// <summary>
    /// Tests related to the login flow of the Saucedemo application.
    /// </summary>
    internal class LoginTest : PlaywrightBaseFixture
    {
        /// <summary>
        /// Verifies that a valid user can log in and is redirected to the inventory page.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous test operation.</returns>
        [Test]
        public async Task LoginCheck()
        {
            LoginPage loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync(Settings.UserName!, Settings.Password!);
            
            await Task.Delay(300);
            Assert.That(Page.Url, Does.Contain("/inventory.html"));

            

        }
        
    }
}
