using iSki2gpx.Converter.GPX.Models;
using iSki2gpx.Converter.Util;

namespace iSki2gpx.Converter.GPX.Builder {
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