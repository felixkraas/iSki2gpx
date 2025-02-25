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

        /// <summary>
        /// Asynchronously reads and deserializes a JSON string into a <see cref="Track"/> object.
        /// </summary>
        /// <param name="json">The JSON string to be deserialized into a <see cref="Track"/> object.
        /// If null or empty, an empty JSON string will be used.</param>
        /// <returns>A <see cref="Track"/> object if deserialization is successful; otherwise, null.</returns>
        public static async Task<Track?> ReadAsync( string json ) {
            using Stream jsonStream = new MemoryStream( Encoding.UTF8.GetBytes( json ?? string.Empty ) );
            Track? track = await JsonSerializer.DeserializeAsync<Track>( jsonStream, _options );

            return track;
        }

        /// <summary>
        /// Asynchronously reads and deserializes a JSON stream into a <see cref="Track"/> object.
        /// </summary>
        /// <param name="stream">The stream containing JSON data to be deserialized into a <see cref="Track"/> object. If null, a null track will be returned.</param>
        /// <returns>A <see cref="Track"/> object if deserialization is successful; otherwise, null.</returns>
        public static async Task<Track?> ReadAsync( FileStream stream ) {
            Track? track = await JsonSerializer.DeserializeAsync<Track>( stream, _options );

            return track;
        }
    }
}