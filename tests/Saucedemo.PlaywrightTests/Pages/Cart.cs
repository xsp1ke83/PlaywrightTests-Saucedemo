using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.PlaywrightTests.Pages
{
    internal class Cart
    {
        private readonly IPage _page;
        public Cart(IPage page) => _page = page;
        
        public async Task FindItemsOnCartPage(params string[] itemNames)
        {
            foreach (var item in itemNames)
            {
                ILocator inventoryItem = _page.Locator($"//div[@class='inventory_item_name' and contains(text(), '{item}')]");
                if (await inventoryItem.CountAsync() < 1)
                {
                    throw new Exception("Element not found.");
                }
            }
        }
    }
}
