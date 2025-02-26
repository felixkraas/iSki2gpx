using System.Xml.Serialization;

namespace iSki2gpx.Converter.GPX.Models {
    public class GpxTrackSegment {
        [XmlElement( ElementName = "trkpt" )]
        public List<GpxTrackPoint> TrackPoints {
            get;
            set;
        } = new List<GpxTrackPoint>();
    }
}