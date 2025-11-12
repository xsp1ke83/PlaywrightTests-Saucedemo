using System.Text.Json;

namespace Saucedemo.PlaywrightTests.Fixtures
{
    public static class ConfigManager
    {
        private static TestSettings? _settings;

        public static async Task<TestSettings> GetConfig()
        {
            string json = await File.ReadAllTextAsync("Config\\Settings.local-debug.json");
            _settings = JsonSerializer.Deserialize<TestSettings>(json)!;

            return _settings;
        }
    }
}
