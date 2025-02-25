namespace iSki2gpx.Converter.Models.iSki {
    public class TrackPoint {
        
        public string Segment {
            get;
            set;
        }
        
        public decimal Latitude {
            get;
            set;
        }
        
        public decimal Longitude {
            get;
            set;
        }
        
        public int Elevation {
            get;
            set;
        }
        
        public decimal Time {
            get;
            set;
        }
        
        public int Speed {
            get;
            set;
        }
        
    }
}