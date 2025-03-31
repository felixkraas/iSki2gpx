using iSki2pgx.Scraper;
using Microsoft.Extensions.Configuration;

namespace iSki2gpx.Scraper.Tests {
    public class WebScraperFixture {
        public IConfiguration Configuration {
            get;
            init;
        }

        public iSkiScraper Scraper {
            get;
            init;
        } = new iSkiScraper( headless: true );

        public WebScraperFixture() {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<WebScraperFixture>()
                .AddEnvironmentVariables()
                .Build();
        }
    }
}