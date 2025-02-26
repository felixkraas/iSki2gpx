using iSki2gpx.Converter.Reader;
using iSki2gpx.Converter.Tests.iSki;

namespace iSki2gpx.Converter.Tests.GPX {
    public class ConverterTest : IClassFixture<iSkiDataFixture> {
        private readonly iSkiDataFixture _fixture;
        private readonly iSkiReader _reader = new iSkiReader();

        public ConverterTest( iSkiDataFixture fixture ) {
            _fixture = fixture;
        }


        [Fact]
        public async void ConvertToGpx() {
            var track = await _reader.ReadFromJsonAsync( _fixture.iSkiData );

            iSki2gpxConverter converter = new iSki2gpxConverter();

            var result = converter.Convert( track );
            Assert.Multiple( () => {
                Assert.NotNull( result );
                Assert.NotNull( result.Metadata );
                Assert.NotNull( result.Track );
                Assert.NotNull( result.Track.TrackSegments );
                Assert.NotEmpty( result.Track.TrackSegments );
                Assert.Single( result.Track.TrackSegments );
                Assert.NotNull( result.Track.TrackSegments.First().TrackPoints );
                Assert.NotEmpty( result.Track.TrackSegments.First().TrackPoints );
                Assert.Equal( track.TrackPoints.Count(), result.Track.TrackSegments.First().TrackPoints.Count );
            } );
        }
    }
}