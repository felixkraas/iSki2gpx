namespace iSki2gpx.Converter.Tests.iSki {
    public class iSkiDataFixture {
        public string iSkiData {
            get;
            set;
        }

        public string DataFilePath {
            get;
            set;
        } = "./Assets/2025-02-25.json";

        public iSkiDataFixture() {
            iSkiData = File.ReadAllText( DataFilePath );
        }
    }
}