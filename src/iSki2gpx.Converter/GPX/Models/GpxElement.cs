using System.Xml.Schema;
using System.Xml.Serialization;

namespace iSki2gpx.Converter.GPX.Models {
    [XmlRoot( ElementName = "gpx", IsNullable = false )]
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

        [XmlAttribute( AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance", Form = XmlSchemaForm.Qualified )]
        public string SchemaLocation {
            get => "http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd";
            set => throw new System.NotImplementedException();
        }

        [XmlAttribute( AttributeName = "version" )]
        public string Version {
            get => "1.1";
            set => throw new System.NotImplementedException();
        }
    }
}