using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace iSki2pgx.Scraper {
    public class iSkiScraper : IDisposable {
        private readonly string _iSkiBaseUrl = "https://iski.cc/";
        private readonly string _iSkiLoginUrl = "https://iski.cc/en/community";
        private readonly string _iSkiTracksUrl = "https://iski.cc/en/community/tracks";
        private readonly string _iSkiLogoutUrl = "https://delphi.iski.cc/logout";
        private readonly IWebDriver _webDriver;
        private readonly ILogger<iSkiScraper>? _logger;

        public iSkiScraper( ILogger<iSkiScraper> logger = null, bool headless = true ) {
            var options = new ChromeOptions();
            if( headless ) {
                options.AddArgument( "--headless=new" );
            }

            _webDriver = new ChromeDriver( options );
            _webDriver.Navigate().GoToUrl( _iSkiBaseUrl );
            _webDriver.Manage().Cookies.AddCookie( new Cookie( "cookieconsent_status", "dismiss" ) );
        }

        public void Authenticate( string username, string password ) {
            if( string.IsNullOrEmpty( username ) ) {
                throw new ArgumentException( nameof( username ) );
            }

            if( string.IsNullOrEmpty( password ) ) {
                throw new ArgumentException( nameof( password ) );
            }

            _webDriver.Navigate().GoToUrl( _iSkiLoginUrl );

            Thread.Sleep( 2000 );

            var cookies = _webDriver.Manage().Cookies.AllCookies;
            if( cookies.Any( c => string.Equals( c.Name, "remember_buddy_token", StringComparison.InvariantCultureIgnoreCase ) ) ) {
                return;
            }

            IWebElement frame = null;
            try {
                frame = _webDriver.FindElement( By.TagName( "iframe" ) );
            } catch( NoSuchElementException ex ) {
                return;
            }

            _webDriver.SwitchTo().Frame( frame );
            _webDriver.FindElement( By.Name( "buddy[login]" ) ).SendKeys( username );
            _webDriver.FindElement( By.Name( "buddy[password]" ) ).SendKeys( password );

            _webDriver.FindElement( By.XPath( "/html/body/div/form/input[3]" ) ).Click();
        }

        public List<string> GetTrackUrls() {
            List<string> tracks = new();
            _webDriver.Navigate().GoToUrl( _iSkiTracksUrl );
            Thread.Sleep( 2000 );
            var selectElement = _webDriver.FindElement( By.TagName( "select" ) );
            var select = new SelectElement( selectElement );
            select.SelectByText( "All seasons" );

            Thread.Sleep( 1000 );

            var trackElements = _webDriver.FindElements( By.ClassName( "track-box" ) );

            List<string> trackUrls = new List<string>();

            foreach( IWebElement trackElement in trackElements ) {
                var trackUrl = trackElement.FindElement( By.ClassName( "track-box--left" ) ).GetAttribute( "href" );
                trackUrls.Add( trackUrl );
            }

            foreach( var trackUrl in trackUrls ) {
                var trackId = trackUrl.Split( '/' ).Last();
                var jsonUrl = $"https://delphi.iski.cc/api/tracks/{trackId}/details";
                tracks.Add( jsonUrl );
            }

            return tracks;
        }

        public List<long> GetTrackIds() {
            List<long> tracks = new();
            _webDriver.Navigate().GoToUrl( _iSkiTracksUrl );
            Thread.Sleep( 2000 );
            var selectElement = _webDriver.FindElement( By.TagName( "select" ) );
            var select = new SelectElement( selectElement );
            select.SelectByText( "All seasons" );

            Thread.Sleep( 1000 );

            var trackElements = _webDriver.FindElements( By.ClassName( "track-box" ) );

            List<string> trackUrls = new List<string>();

            foreach( IWebElement trackElement in trackElements ) {
                var trackUrl = trackElement.FindElement( By.ClassName( "track-box--left" ) ).GetAttribute( "href" );
                trackUrls.Add( trackUrl );
            }

            foreach( var trackUrl in trackUrls ) {
                var trackId = trackUrl.Split( '/' ).Last();
                tracks.Add( Convert.ToInt64( trackId ) );
            }

            return tracks;
        }

        public void Logout() {
            _webDriver.Navigate().GoToUrl( _iSkiLogoutUrl );
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Navigate().GoToUrl( _iSkiBaseUrl );
        }

        public string GetTrackData( string trackUrl ) {
            _webDriver.Navigate().GoToUrl( trackUrl );
            return _webDriver.PageSource;
        }

        public string GetTrackData( long trackId ) {
            return GetTrackData( $"https://delphi.iski.cc/api/tracks/{trackId}/details" );
        }

        public void Dispose() {
            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }
}