using System.Xml.Serialization;

namespace iSki2gpx.Converter.Models.gpx {
    public class GpxTrack {
        [XmlElement( ElementName = "name", IsNullable = false )]
        public string? Name {
            get;
            set;
        }

        [XmlElement( ElementName = "desc", IsNullable = false )]
        public string? Description {
            get;
            set;
        }

        [XmlElement( ElementName = "src", IsNullable = false )]
        public string? Source {
            get;
            set;
        }

        [XmlElement( ElementName = "trkseg" )]
        public List<GpxTrackSegment> TrackSegments {
            get;
            set;
        } = new List<GpxTrackSegment>();
    }
}