using System.Text.Json;

namespace Saucedemo.PlaywrightTests.Fixtures
{
    public static class ConfigManager
    {
        private static TestSettings? _settings;

        public static async Task<TestSettings> GetConfig()
        {
            string path = Path.Combine("Config", "Settings.local-debug.json");
            string json = await File.ReadAllTextAsync(path);
            _settings = JsonSerializer.Deserialize<TestSettings>(json)!;

            return _settings;
        }
    }
}
