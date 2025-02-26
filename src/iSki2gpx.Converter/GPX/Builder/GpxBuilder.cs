using iSki2gpx.Converter.GPX.Models;

namespace iSki2gpx.Converter.GPX.Builder {
    public class GpxBuilder {
        private GpxElement _gpx = new GpxElement();

        public GpxBuilder AddMetadata( Action<GpxMetadataBuilder> metadataBuilder ) {
            var metadata = new GpxMetadataBuilder();
            metadataBuilder( metadata );
            _gpx.Metadata = metadata.Build();
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
}