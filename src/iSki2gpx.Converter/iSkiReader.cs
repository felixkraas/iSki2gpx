using System.Text.Json;
using iSki2gpx.Converter.Models.iSki;

namespace iSki2gpx.Converter {
    public class iSkiReader {
        private readonly JsonSerializerOptions _options;

        public iSkiReader() {
            _options = new JsonSerializerOptions() {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };
        }

        public async Task<Track?> ReadAsync( string json ) {
            using Stream jsonStream = new MemoryStream();
            using StreamWriter writer = new StreamWriter( jsonStream );
            await writer.WriteAsync( json );
            writer.Flush();
            jsonStream.Position = 0;
            Track? track = await JsonSerializer.DeserializeAsync<Track>( jsonStream, _options );

            return track;
        }

        public async Task<Track?> ReadAsync( FileStream stream ) {
            Track? track = await JsonSerializer.DeserializeAsync<Track>( stream, _options );

            return track;
        }
    }
}