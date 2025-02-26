using System.Xml.Serialization;

namespace iSki2gpx.Converter.Models.gpx {
    public class GpxTrackPoint {
        [XmlElement( ElementName = "ele" )]
        public decimal Elevation {
            get;
            set;
        }

        [XmlAttribute( AttributeName = "lat" )]
        public decimal Latitude {
            get;
            set;
        }

        [XmlAttribute( AttributeName = "lon" )]
        public decimal Longitude {
            get;
            set;
        }

        [XmlElement( ElementName = "time" )]
        public DateTime Time {
            get;
            set;
        }
    }
}