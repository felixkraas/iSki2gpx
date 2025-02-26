namespace iSki2gpx.Converter.iSki.Models {
    public record iSkiTrackPoint {
        
        public string Segment {
            get;
            init;
        }
        
        public decimal Latitude {
            get;
            init;
        }
        
        public decimal Longitude {
            get;
            init;
        }
        
        public int Elevation {
            get;
            init;
        }
        
        public decimal Time {
            get;
            init;
        }
        
        public int Speed {
            get;
            init;
        }
        
    }
}