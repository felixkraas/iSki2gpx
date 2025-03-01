using System.Collections.ObjectModel;
using iSki2gpx.Converter.iSki.Models;
using iSki2gpx.Converter.iSki.Reader;
using iSki2gpx.Converter.Tests.Util;
using iSki2gpx.Converter.Util;

namespace iSki2gpx.Converter.Tests.iSki {
    public class PointListConverterTest {
        private readonly iSkiPointsListConverter _converter = new iSkiPointsListConverter();
        private readonly string _testData = "\"10.59903,46.49089,2608,1740473674.246,0 10.59903,46.49089,2608,1740473674.246,0\"";

        private readonly iSkiTrackPoint _point1 = new iSkiTrackPoint() {
            Segment = "10.59903,46.49089,2608,1740473674.246,0",
            Elevation = 2608,
            Time = 1740473674.246M,
            Speed = 0,
            Latitude = 10.59903M,
            Longitude = 46.49089M
        };

        private readonly iSkiTrackPoint _point2 = new iSkiTrackPoint() {
            Segment = "10.59903,46.49089,2608,1740473674.246,0",
            Elevation = 2608,
            Time = 1740473674.246M,
            Speed = 0,
            Latitude = 10.59903M,
            Longitude = 46.49089M
        };

        [Fact]
        public void TestReadWorking() {
            var result = _converter.Read( _testData );
            Assert.NotNull( result );
            Assert.NotEmpty( result );
            Assert.Equal( 2, result.Count );
            Assert.Equal( _point1, result[0] );
            Assert.Equal( _point2, result[1] );
        }

        [Fact]
        public void TestWrite() {
            var result = _converter.Write( new ReadOnlyCollection<iSkiTrackPoint>( new List<iSkiTrackPoint>() {
                _point1,
                _point2
            } ) );
            Assert.Equal( _testData, result.Trim() );
        }
    }
}