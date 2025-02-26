using System.Xml.Serialization;

namespace iSki2gpx.Converter.Models.gpx {
    public class GpxMetadata {
        [XmlElement( ElementName = "name", IsNullable = false )]
        public string Name {
            get;
            set;
        }

        [XmlElement( ElementName = "desc", IsNullable = false )]
        public string? Description {
            get;
            set;
        }

        [XmlElement( ElementName = "time" )]
        public DateTime Time {
            get;
            set;
        }

        [XmlElement( ElementName = "keywords", IsNullable = false )]
        public string? Keywords {
            get;
            set;
        }
    }
}