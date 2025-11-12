using Saucedemo.PlaywrightTests.Fixtures;
using Saucedemo.PlaywrightTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Saucedemo.PlaywrightTests.Tests
{
    internal class AddAndCheckItemsInCartTest : PlaywrightBaseFixture
    {
        [Test]
        public async Task AddItemCheck()
        {
            LoginPage loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync(Settings.UserName!, Settings.Password!);

            ProductPage productPage = new ProductPage(Page);

            await productPage.AddItemsToCartByName(Settings.ItemsToBuy!);

            await productPage.ClickToCart();

            Cart cart = new Cart(Page);
            await cart.FindItemsOnCartPage(Settings.ItemsToBuy!);
        }
    }
}
