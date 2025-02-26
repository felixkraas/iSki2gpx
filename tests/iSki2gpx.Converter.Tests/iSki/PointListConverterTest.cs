using System.Collections.ObjectModel;
using iSki2gpx.Converter.Models.iSki;
using iSki2gpx.Converter.Tests.Util;
using iSki2gpx.Converter.Util;

namespace iSki2gpx.Converter.Tests.iSki {
    public class PointListConverterTest {
        private readonly PointsListConverter _converter = new PointsListConverter();
        private readonly string _testData = "\"10.59903,46.49089,2608,1740473674.246,0 10.59903,46.49089,2608,1740473674.246,0\"";

        [Fact]
        public void TestReadWorking() {
            var result = _converter.Read( _testData );
            Assert.NotNull( result );
            Assert.NotEmpty( result );
            Assert.Equal( 2, result.Count );
        }

        [Fact]
        public void TestWrite() {
            var result = _converter.Write( new ReadOnlyCollection<iSkiTrackPoint>( new List<iSkiTrackPoint>() {
                new iSkiTrackPoint() {
                    Segment = "10.59903,46.49089,2608,1740473674.246,0",
                    Elevation = 2608,
                    Time = 1740473674.246M,
                    Speed = 0,
                    Longitude = 10.59903M,
                    Latitude = 46.49089M
                },
                new iSkiTrackPoint() {
                    Segment = "10.59903,46.49089,2608,1740473674.246,0",
                    Elevation = 2608,
                    Time = 1740473674.246M,
                    Speed = 0,
                    Longitude = 10.59903M,
                    Latitude = 46.49089M
                }
            } ) );
            Assert.Equal( _testData, result.Trim() );
        }
    }
}