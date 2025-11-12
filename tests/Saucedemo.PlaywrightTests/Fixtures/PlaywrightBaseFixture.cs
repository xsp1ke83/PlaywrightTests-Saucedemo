using Microsoft.Playwright;
using NUnit.Framework.Internal;
using NUnit.Framework;

using Microsoft.Extensions.Logging;
using MSLogger = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;


namespace Saucedemo.PlaywrightTests.Fixtures
{
    public class PlaywrightBaseFixture
    {
        private IPlaywright Playwright;
        protected IBrowser Browser;
        protected IPage Page;
        protected IBrowserContext BrowserContext;
        public TestSettings Settings;

        protected MSLogger.ILogger Logger;         

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            // logger:
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole()       // логування у консоль
                    .AddDebug()
                    .SetMinimumLevel(LogLevel.Trace);                    
            });

            this.Logger = loggerFactory.CreateLogger<PlaywrightBaseFixture>();

            Logger.LogInformation("Launch browser...");

            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Settings = await ConfigManager.GetConfig();
            BrowserTypeLaunchOptions launchOptions = new BrowserTypeLaunchOptions { Headless = Settings.Headless, Timeout = Settings.Timeout, SlowMo = Settings.SlowMo, };
            
            Browser = Settings!.Browser!.ToLower() switch
            {
                "firefox" => await Playwright.Firefox.LaunchAsync(launchOptions),
                "chromium" => await Playwright.Chromium.LaunchAsync(launchOptions),
                _ => await Playwright.Chromium.LaunchAsync(launchOptions),    // default
            };
            Logger.LogInformation("Browser launched.");
        }

        [SetUp]
        public async Task TestSetup()
        {
            BrowserContext = await Browser.NewContextAsync(); 
            Page = await Browser.NewPageAsync(new BrowserNewPageOptions() { BaseURL = Settings.BaseURL } );
        }

        [TearDown]
        public async Task TestTearDown()
        {
            await BrowserContext.DisposeAsync();
            await Page.CloseAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await Browser.DisposeAsync();
            Playwright.Dispose();
        }

         
    }
}
