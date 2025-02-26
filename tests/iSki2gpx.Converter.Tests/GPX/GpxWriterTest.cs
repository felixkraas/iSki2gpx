using iSki2gpx.Converter.GPX.Writer;
using iSki2gpx.Converter.iSki.Reader;
using iSki2gpx.Converter.Tests.iSki;

namespace iSki2gpx.Converter.Tests.GPX {
    public class GpxWriterTest : IClassFixture<iSkiDataFixture> {
        private readonly iSkiDataFixture _fixture;
        private readonly iSkiReader _reader = new iSkiReader();
        private readonly GpxWriter _gpxWriter = new GpxWriter();
        public GpxWriterTest( iSkiDataFixture fixture ) {
            _fixture = fixture;
        }

        [Fact]
        public async void TestWrite() {
            var track = await _reader.ReadFromJsonAsync( _fixture.iSkiData );

            iSki2gpxConverter converter = new iSki2gpxConverter();

            var gpx = converter.Convert( track );
            
            _gpxWriter.WriteToFile( gpx, "test.gpx" );
            
        }
    }
}