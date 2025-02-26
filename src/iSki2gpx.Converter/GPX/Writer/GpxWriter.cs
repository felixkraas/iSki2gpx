using System.Text;
using System.Xml;
using System.Xml.Serialization;
using iSki2gpx.Converter.GPX.Models;

namespace iSki2gpx.Converter.GPX.Writer {
    public class GpxWriter {
        public void WriteToFile( GpxElement gpxElement, string filePath ) {
            XmlSerializer serializer = new XmlSerializer( typeof( GpxElement ) );
            XmlWriterSettings options = new XmlWriterSettings() {
                Indent = true, Encoding = Encoding.UTF8, NamespaceHandling = NamespaceHandling.OmitDuplicates
            };
            StringWriter writer = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create( writer, options );
            serializer.Serialize( xmlWriter, gpxElement );
            var sb = writer.GetStringBuilder();
            var test = sb.ToString();
        }
    }
}