using iSki2gpx.Converter.GPX.Models;
using iSki2gpx.Converter.Util;

namespace iSki2gpx.Converter.GPX.Builder {
    public class GpxMetadataBuilder {
        private GpxMetadata _metadata = new GpxMetadata();

        public GpxMetadataBuilder WithName( string name ) {
            _metadata.Name = name;
            return this;
        }

        public GpxMetadataBuilder WithDescription( string description ) {
            _metadata.Description = description;
            return this;
        }

        public GpxMetadataBuilder WithTime( DateTime time ) {
            _metadata.Time = time;
            return this;
        }

        public GpxMetadataBuilder WithTime( decimal unixEpoch ) {
            _metadata.Time = DateTimeUtil.UnixToDateTime( unixEpoch );
            return this;
        }
        
        internal GpxMetadata Build() {
            return _metadata;
        }
    }
}