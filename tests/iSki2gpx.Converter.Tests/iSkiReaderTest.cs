namespace iSki2gpx.Converter.Tests {
    public class iSkiReaderTest : IClassFixture<iSkiDataFixture> {
        private readonly iSkiDataFixture _fixture;
        private readonly iSkiReader _reader = new iSkiReader();

        public iSkiReaderTest( iSkiDataFixture fixture ) {
            _fixture = fixture;
        }

        [Fact]
        public async void DeserializeTrackFromString() {
            Exception? exception = await Record.ExceptionAsync( async () => await _reader.ReadFromJsonAsync( _fixture.iSkiData ) );
            Assert.Null( exception );
        }

        [Fact]
        public async void DeserializeTrackFromFile() {
            Exception? exception = await Record.ExceptionAsync( async () => await _reader.ReadFromFileAsync( _fixture.DataFilePath ) );
            Assert.Null( exception );
        }
    }
}