using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.PlaywrightTests
{
    public class TestSettings
    {
        public string? Browser { get; set; }
        public bool Headless { get; set; }
        public int Timeout { get; set; }
        public int SlowMo { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string[]? ItemsToBuy { get; set; }
        public string? BaseURL { get; set; }
    }

}
