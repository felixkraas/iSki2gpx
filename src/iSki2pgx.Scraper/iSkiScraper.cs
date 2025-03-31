using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace iSki2pgx.Scraper {
    public class iSkiScraper {
        private readonly string _iSkiBaseUrl = "https://iski.cc/";
        private readonly string _iSkiLoginUrl = "https://iski.cc/en/community";
        private readonly string _iSkiTracksUrl = "https://iski.cc/en/community/tracks";
        private readonly IWebDriver _webDriver;

        public iSkiScraper( bool headless = true ) {
            var options = new ChromeOptions();
            if( headless ) {
                options.AddArgument( "--headless=new" );
            }

            _webDriver = new ChromeDriver( options );
            _webDriver.Navigate().GoToUrl( _iSkiBaseUrl );
            _webDriver.Manage().Cookies.AddCookie( new Cookie( "cookieconsent_status", "dismiss" ) );
        }

        public void Authenticate( string username, string password ) {
            var cookies = _webDriver.Manage().Cookies.AllCookies;
            if( cookies.Any( c => string.Equals( c.Name, "remember_buddy_token", StringComparison.InvariantCultureIgnoreCase ) ) ) {
                return;
            }

            _webDriver.Navigate().GoToUrl( _iSkiLoginUrl );

            Thread.Sleep( 2000 );

            var frame = _webDriver.FindElement( By.TagName( "iframe" ) );

            _webDriver.SwitchTo().Frame( frame );
            _webDriver.FindElement( By.Name( "buddy[login]" ) ).SendKeys( username );
            _webDriver.FindElement( By.Name( "buddy[password]" ) ).SendKeys( password );

            _webDriver.FindElement( By.XPath( "/html/body/div/form/input[3]" ) ).Click();
        }

        public List<Tuple<string, string>> GetTrackUrls() {
            List<Tuple<string, string>> tracks = new();
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
                tracks.Add( new Tuple<string, string>( trackId, jsonUrl ) );
            }

            return tracks;
        }
    }
}