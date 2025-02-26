using System.Xml.Serialization;

namespace iSki2gpx.Converter.Models.gpx {
    public class GpxTrackSegment {
        [XmlElement( ElementName = "trkpt" )]
        public List<GpxTrackPoint> TrackPoints {
            get;
            set;
        }
    }
}