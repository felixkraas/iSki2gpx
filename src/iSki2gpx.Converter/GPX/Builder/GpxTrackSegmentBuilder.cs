using iSki2gpx.Converter.GPX.Models;

namespace iSki2gpx.Converter.GPX.Builder {
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
}