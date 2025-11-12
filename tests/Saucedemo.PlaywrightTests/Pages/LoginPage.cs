using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Saucedemo.PlaywrightTests.Fixtures;
using NUnit;

namespace Saucedemo.PlaywrightTests.Pages
{
    internal class LoginPage : PlaywrightBaseFixture
    {
        private readonly IPage _page;
        public LoginPage(IPage page) => _page = page;


        public async Task NavigateAsync()
        {
            await _page.GotoAsync("#");
        }

        public async Task LoginAsync(string user, string password)
        {
            //await _page.GotoAsync(Settings.BaseURL);
            await _page.Locator("//input[@id='user-name']").ClickAsync();
            await _page.Locator("[data-test=\"username\"]").FillAsync(user);
            await _page.Locator("[data-test=\"password\"]").ClickAsync();
            await _page.Locator("[data-test=\"password\"]").FillAsync(password);
            await _page.GetByRole(AriaRole.Button, new() { Name = "LOGIN" }).ClickAsync();
        }
        
    }
}
