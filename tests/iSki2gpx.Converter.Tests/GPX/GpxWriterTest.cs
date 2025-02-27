using iSki2gpx.Converter.GPX.Writer;
using iSki2gpx.Converter.iSki.Reader;
using iSki2gpx.Converter.Tests.iSki;

namespace iSki2gpx.Converter.Tests.GPX {
    public class GpxWriterTest : IClassFixture<iSkiDataFixture> {
        private readonly iSkiDataFixture _fixture;
        private readonly iSkiReader _reader = new iSkiReader();
        private readonly GpxWriter _gpxWriter = new GpxWriter();

        private readonly string _fileName = "test.gpx";

        public GpxWriterTest( iSkiDataFixture fixture ) {
            _fixture = fixture;
            File.Delete( _fileName );
        }

        [Fact]
        public async void TestWrite() {
            var track = await _reader.ReadFromJsonAsync( _fixture.iSkiData );

            iSki2gpxConverter converter = new iSki2gpxConverter();

            var gpx = converter.Convert( track );

            Assert.True( await _gpxWriter.WriteToFileAsync( gpx, _fileName ) );

            Assert.True( File.Exists( _fileName ) );
        }
    }
}