using System.Text;
using System.Text.Json;
using iSki2gpx.Converter.Models.iSki;

namespace iSki2gpx.Converter {
    public static class iSkiReader {
        private static readonly JsonSerializerOptions _options;

        static iSkiReader() {
            _options = new JsonSerializerOptions() {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };
        }

        public static async Task<Track?> ReadAsync( string json ) {
            using Stream jsonStream = new MemoryStream( Encoding.UTF8.GetBytes( json ?? string.Empty ) );
            Track? track = await JsonSerializer.DeserializeAsync<Track>( jsonStream, _options );

            return track;
        }

        public static async Task<Track?> ReadAsync( FileStream stream ) {
            Track? track = await JsonSerializer.DeserializeAsync<Track>( stream, _options );

            return track;
        }
    }
}