using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using iSki2gpx.Converter.GPX.Models;

namespace iSki2gpx.Converter.GPX.Writer {
    public class GpxWriter {
        public async Task<bool> WriteToFileAsync( GpxElement gpxElement, string filePath ) {
            XmlSerializer serializer = new XmlSerializer( typeof( GpxElement ) );
            XmlWriterSettings options = new XmlWriterSettings() {
                Indent = true, Encoding = Encoding.UTF8, NamespaceHandling = NamespaceHandling.OmitDuplicates, Async = true
            };
            using MemoryStream stream = new MemoryStream();
            serializer.Serialize( stream, gpxElement );

            stream.Position = 0;
            string xmlText = Encoding.UTF8.GetString( stream.ToArray() );
            
            XmlDocument xmlDocument = new XmlDocument();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add( "http://www.topografix.com/GPX/1/1", "http://www.topografix.com/GPX/1/1/gpx.xsd" );
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.IgnoreWhitespace = true;
            
            using XmlReader reader = XmlReader.Create( stream, xmlReaderSettings );
            xmlDocument.Load( reader );

            bool result = true;
            xmlDocument.Validate( ( sender, args ) => {
                if( args.Severity == XmlSeverityType.Error ) {
                    result = false;
                } else if( args.Severity == XmlSeverityType.Warning || args.Exception == null ) {
                    result = true;
                }
            } );

            if( result ) {
                await File.WriteAllTextAsync( filePath, xmlText, Encoding.UTF8 );
            }

            return result;
        }
    }
}