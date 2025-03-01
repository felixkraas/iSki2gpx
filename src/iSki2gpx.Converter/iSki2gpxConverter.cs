using iSki2gpx.Converter.GPX.Builder;
using iSki2gpx.Converter.GPX.Models;
using iSki2gpx.Converter.iSki.Models;
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

            builder.AddMetadata( metadataBuilder => {
                    metadataBuilder.WithName( $"{track.ResortName} - {track.StartDate.Date.ToShortDateString()}" )
                        .WithTime( track.StartDate );
                } )
                .AddTrack( trackBuilder => {
                    trackBuilder.WithName( "Ski Track" )
                        .AddTrackSegment( segmentBuilder => {
                            foreach( iSkiTrackPoint trackPoint in track.TrackPoints ) {
                                segmentBuilder.AddTrackPoint( pointBuilder => {
                                    pointBuilder.WithElevation( trackPoint.Elevation )
                                        .WithLatitude( trackPoint.Latitude )
                                        .WithLongitude( trackPoint.Longitude )
                                        .WithTime( trackPoint.Time );
                                } );
                            }
                        } );
                } );

            return builder.Build();
        }
    }
}