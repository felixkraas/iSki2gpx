using System.Xml.Serialization;

namespace iSki2gpx.Converter.Models.gpx {
    [XmlRoot( ElementName = "gpx", Namespace = "http://www.topografix.com/GPX/1/1", IsNullable = false )]
    public class GpxElement {
        [XmlElement( ElementName = "metadata" )]
        public GpxMetadata Metadata {
            get;
            set;
        }

        [XmlElement( ElementName = "trk" )]
        public GpxTrack Track {
            get;
            set;
        }
    }
}