namespace iSki2gpx.Scraper.Tests {
    public class TestWebScraper : IClassFixture<WebScraperFixture> {
        private readonly WebScraperFixture _fixture;

        public TestWebScraper( WebScraperFixture fixture ) {
            _fixture = fixture;
        }

        [Fact]
        public void TestDownload() {
            _fixture.Scraper.Authenticate( _fixture.Configuration["iSki:Username"], _fixture.Configuration["iSki:Password"] );

            var result = _fixture.Scraper.GetTrackUrls();

            Assert.NotNull( result );
            Assert.NotEmpty( result );
        }
    }
}