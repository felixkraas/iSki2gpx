using iSki2gpx.Converter.Models.gpx;
using iSki2gpx.Converter.Models.iSki;
using iSki2gpx.Converter.Util;
using Microsoft.Extensions.Logging;

namespace iSki2gpx.Converter {
    public class iSki2gpxConverter {
        private readonly ILogger<iSki2gpxConverter>? _logger;

        public iSki2gpxConverter( ILogger<iSki2gpxConverter>? logger = null ) {
            _logger = logger;
        }

        public GpxElement Convert( iSkiTrack track ) {
            GpxBuilder builder = new GpxBuilder();

            builder.WithMetadata( $"{track.ResortName} - {track.StartDate.Date.ToShortDateString()}", null, track.StartDate );
            builder.AddTrack( trackBuilder => {
                trackBuilder.WithName( "Ski Track" );
                trackBuilder.AddTrackSegment( segmentBuilder => {
                    foreach( iSkiTrackPoint trackPoint in track.TrackPoints ) {
                        segmentBuilder.AddTrackPoint( pointBuilder => {
                            pointBuilder.WithElevation( trackPoint.Elevation );
                            pointBuilder.WithLatitude( trackPoint.Latitude );
                            pointBuilder.WithLongitude( trackPoint.Longitude );
                            pointBuilder.WithTime( trackPoint.Time );
                        } );
                    }
                } );
            } );

            return builder.Build();
        }
    }
}