using System;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Saucedemo.PlaywrightTests.Pages;

public class ProductPage
{
    private readonly IPage _page;
    public ProductPage(IPage page) => _page = page;

    public async Task NavigateAsync()
    {
        await _page.GotoAsync("https://www.saucedemo.com/v1/inventory.html");
    }

    public async Task AddItemsToCartByName(params string[] itemNames)
    {
        foreach (var item in itemNames)
        {
            ILocator inventoryItem = _page.Locator($"//div[@class='inventory_item_name' and  contains(text(), '{item}')  ] /../../../*/button");
            if (await inventoryItem.CountAsync() < 1)
            {
                throw new Exception("Element not found.");
            }
            await inventoryItem.ClickAsync();
        }
    }
    
    
    public async Task ClickToCart()
    {        
        // go to cart
        //await _page.Locator("#shopping_cart_container").GetByRole(AriaRole.Link).ClickAsync();
        
        await _page.Locator("//a[@class='shopping_cart_link fa-layers fa-fw']").ClickAsync();

    }
}
