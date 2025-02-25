namespace iSki2gpx.Converter.Models.iSki;

public class Track {
    public long TrackId {
        get;
        set;
    }

    public DateTime StartDate {
        get;
        set;
    }

    public long Duration {
        get;
        set;
    }

    public string ResortName {
        get;
        set;
    }

    public decimal Distance {
        get;
        set;
    }

    public decimal HighestPoint {
        get;
        set;
    }

    public decimal DistanceUp {
        get;
        set;
    }

    public decimal DistanceDown {
        get;
        set;
    }

    public decimal AltitudeUp {
        get;
        set;
    }

    public decimal AltitudeDown {
        get;
        set;
    }

    public decimal AverageSpeed {
        get;
        set;
    }

    public bool AverageSpeedRestricted {
        get;
        set;
    }

    public decimal MaxSpeed {
        get;
        set;
    }

    public bool MaxSpeedRestricted {
        get;
        set;
    }

    public bool GeometryProcessed {
        get;
        set;
    }

    public bool HasDimensionM {
        get;
        set;
    }

    public long DurationActive {
        get;
        set;
    }

    public long DurationPassice {
        get;
        set;
    }

    public int Lifts {
        get;
        set;
    }

    public bool MyTrack {
        get;
        set;
    }

    public List<TrackPoint> TrackPoints {
        get;
        set;
    }
}