using System.Reflection.Emit;
using iSki2gpx.Converter.Models.gpx;

namespace iSki2gpx.Converter.Util {
    public class GpxBuilder {
        private GpxElement _gpx = new GpxElement();

        public GpxBuilder WithMetadata( string name, string? description, DateTime time ) {
            _gpx.Metadata = new GpxMetadata() {
                Name = name, Description = description, Time = time
            };
            return this;
        }

        public GpxBuilder WithMetadata( string name, string description, decimal time ) {
            _gpx.Metadata = new GpxMetadata() {
                Name = name, Description = description
            };

            _gpx.Metadata.Time = DateTimeUtil.UnixToDateTime( time );
            return this;
        }

        public GpxBuilder AddTrack( Action<GpxTrackBuilder> trackBuilder ) {
            var track = new GpxTrackBuilder();
            trackBuilder( track );
            _gpx.Track = track.Build();
            return this;
        }

        public GpxElement Build() {
            if( _gpx.Track == null ) {
                throw new Exception( "Track is required." );
            }

            if( _gpx.Metadata == null ) {
                throw new Exception( "Metadata is required." );
            }


            return _gpx;
        }
    }

    public class GpxTrackBuilder {
        private GpxTrack _track = new GpxTrack();

        public GpxTrackBuilder WithName( string name ) {
            _track.Name = name;
            return this;
        }

        public GpxTrackBuilder WithDescription( string description ) {
            _track.Description = description;
            return this;
        }

        public GpxTrackBuilder WithSource( string source ) {
            _track.Source = source;
            return this;
        }

        public GpxTrackBuilder AddTrackSegment( Action<GpxTrackSegmentBuilder> trackSegmentBuilder ) {
            var trackSegment = new GpxTrackSegmentBuilder();
            trackSegmentBuilder( trackSegment );
            _track.TrackSegments.Add( trackSegment.Build() );
            return this;
        }

        internal GpxTrack Build() {
            if( _track.TrackSegments == null || _track.TrackSegments.Count == 0 ) {
                throw new Exception( "At least one Track segment is required." );
            }

            return _track;
        }
    }

    public class GpxTrackSegmentBuilder {
        private GpxTrackSegment _trackSegment = new GpxTrackSegment();

        public GpxTrackSegmentBuilder AddTrackPoint( Action<GpxTrackPointBuilder> trackPointBuilder ) {
            var trackPoint = new GpxTrackPointBuilder();
            trackPointBuilder( trackPoint );
            _trackSegment.TrackPoints.Add( trackPoint.Build() );
            return this;
        }

        internal GpxTrackSegment Build() {
            return _trackSegment;
        }
    }

    public class GpxTrackPointBuilder {
        private GpxTrackPoint _trackPoint = new GpxTrackPoint();

        public GpxTrackPointBuilder WithLatitude( decimal latitude ) {
            _trackPoint.Latitude = latitude;
            return this;
        }

        public GpxTrackPointBuilder WithLongitude( decimal longitude ) {
            _trackPoint.Longitude = longitude;
            return this;
        }

        public GpxTrackPointBuilder WithElevation( int elevation ) {
            _trackPoint.Elevation = elevation;
            return this;
        }

        public GpxTrackPointBuilder WithTime( decimal time ) {
            _trackPoint.Time = DateTimeUtil.UnixToDateTime( time );
            return this;
        }

        public GpxTrackPointBuilder WithTime( DateTime time ) {
            _trackPoint.Time = time;
            return this;
        }

        internal GpxTrackPoint Build() {
            return _trackPoint;
        }
    }
}