using System.Text;
using System.Text.Json;
using iSki2gpx.Converter.Models.iSki;
using iSki2gpx.Converter.Util;
using Microsoft.Extensions.Logging;

namespace iSki2gpx.Converter {
    /// <summary>
    /// Provides functionality to read and deserialize iSki JSON data into <see cref="Track"/> objects.
    /// </summary>
    public class iSkiReader {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions() {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        private ILogger? _logger;

        public iSkiReader( ILogger<iSkiReader>? logger = null ) {
            _logger = logger;
            _options.Converters.Add( new PointsListConverter() );
        }

        /// <summary>
        /// Asynchronously reads and deserializes a JSON string into a <see cref="Track"/> object.
        /// </summary>
        /// <param name="json">The JSON string to be deserialized into a <see cref="Track"/> object.
        /// If null or empty, an empty JSON string will be used.</param>
        /// <returns>A <see cref="Track"/> object if deserialization is successful; otherwise, null.</returns>
        public async Task<Track?> ReadFromJsonAsync( string json ) {
            if( string.IsNullOrEmpty( json ) ) {
                throw new ArgumentNullException( nameof( json ), "JSON string cannot be null or empty." );
            }
            await using Stream jsonStream = new MemoryStream( Encoding.UTF8.GetBytes( json ) );
            Track? track = await JsonSerializer.DeserializeAsync<Track>( jsonStream, _options );

            return track;
        }

        /// <summary>
        /// Asynchronously reads and deserializes a JSON stream into a <see cref="Track"/> object.
        /// </summary>
        /// <param name="stream">The stream containing JSON data to be deserialized into a <see cref="Track"/> object. If null, a null track will be returned.</param>
        /// <returns>A <see cref="Track"/> object if deserialization is successful; otherwise, null.</returns>
        public async Task<Track?> ReadFromFileAsync( string filePath ) {
            Track? track = await JsonSerializer.DeserializeAsync<Track>( new FileStream( filePath, FileMode.Open ), _options );

            return track;
        }
    }
}