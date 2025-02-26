using iSki2gpx.Converter.GPX.Models;

namespace iSki2gpx.Converter.GPX.Builder {
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
}