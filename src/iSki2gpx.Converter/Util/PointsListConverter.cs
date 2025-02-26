using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using iSki2gpx.Converter.Models.iSki;

namespace iSki2gpx.Converter.Util {
    public class PointsListConverter : JsonConverter<List<iSkiTrackPoint>> {
        public override List<iSkiTrackPoint>? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options ) {
            var points = new List<iSkiTrackPoint>();

            var stringValue = reader.GetString();
            var segments = stringValue.Split( ' ' );

            foreach( string segment in segments ) {
                var values = segment.Split( ',' );
                points.Add( new iSkiTrackPoint {
                    Segment = segment,
                    Latitude = decimal.Parse( values[0] ),
                    Longitude = decimal.Parse( values[1] ),
                    Elevation = int.Parse( values[2] ),
                    Time = decimal.Parse( values[3] ),
                    Speed = int.Parse( values[4] ) } );
            }

            return points;
        }

        public override void Write( Utf8JsonWriter writer, List<iSkiTrackPoint> value, JsonSerializerOptions options ) {
            
            StringBuilder sb = new StringBuilder();
            foreach( iSkiTrackPoint point in value ) {
                sb.Append( $"{point.Segment} " );
            }

            writer.WriteStringValue( sb.ToString() );
        }
    }
}