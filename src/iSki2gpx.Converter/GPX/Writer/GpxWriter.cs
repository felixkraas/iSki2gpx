using System.Text;
using System.Xml;
using System.Xml.Serialization;
using iSki2gpx.Converter.GPX.Models;

namespace iSki2gpx.Converter.GPX.Writer {
    public class GpxWriter {
        public async Task WriteToFileAsync( GpxElement gpxElement, string filePath ) {
            XmlSerializer serializer = new XmlSerializer( typeof( GpxElement ) );
            XmlWriterSettings options = new XmlWriterSettings() {
                Indent = true, Encoding = Encoding.UTF8, NamespaceHandling = NamespaceHandling.OmitDuplicates, Async = true
            };
            using StreamWriter writer = new StreamWriter( filePath, false, Encoding.UTF8 );
            using XmlWriter xmlWriter = XmlWriter.Create( writer, options );
            serializer.Serialize( xmlWriter, gpxElement );
            await writer.FlushAsync();
        }
    }
}