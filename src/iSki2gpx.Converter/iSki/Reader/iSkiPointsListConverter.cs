using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using iSki2gpx.Converter.iSki.Models;

namespace iSki2gpx.Converter.iSki.Reader {
    public class iSkiPointsListConverter : JsonConverter<IReadOnlyList<iSkiTrackPoint>> {
        public override IReadOnlyList<iSkiTrackPoint>? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options ) {
            var points = new List<iSkiTrackPoint>();

            var stringValue = reader.GetString();
            var segments = stringValue.Split( ' ' );

            foreach( string segment in segments ) {
                var values = segment.Split( ',' );
                points.Add( new iSkiTrackPoint {
                    Segment = segment,
                    Longitude = decimal.Parse( values[0], System.Globalization.CultureInfo.InvariantCulture ),
                    Latitude = decimal.Parse( values[1], System.Globalization.CultureInfo.InvariantCulture ),
                    Elevation = int.Parse( values[2], System.Globalization.CultureInfo.InvariantCulture ),
                    Time = decimal.Parse( values[3], System.Globalization.CultureInfo.InvariantCulture ),
                    Speed = int.Parse( values[4], System.Globalization.CultureInfo.InvariantCulture )
                } );
            }

            return new ReadOnlyCollection<iSkiTrackPoint>( points.OrderBy( p => p.Time ).ToList() );
        }

        public override void Write( Utf8JsonWriter writer, IReadOnlyList<iSkiTrackPoint> value, JsonSerializerOptions options ) {
            writer.WriteStringValue( string.Join( " ", value.Select( p => p.Segment ) ) );
        }
    }
}