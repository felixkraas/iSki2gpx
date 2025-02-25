namespace iSki2gpx.Converter.Models.iSki;

public record Track {
    public long TrackId {
        get;
        init;
    }

    public DateTime StartDate {
        get;
        init;
    }

    public long Duration {
        get;
        init;
    }

    public string ResortName {
        get;
        init;
    }

    public decimal Distance {
        get;
        init;
    }

    public decimal HighestPoint {
        get;
        init;
    }

    public decimal DistanceUp {
        get;
        init;
    }

    public decimal DistanceDown {
        get;
        init;
    }

    public decimal AltitudeUp {
        get;
        init;
    }

    public decimal AltitudeDown {
        get;
        init;
    }

    public decimal AverageSpeed {
        get;
        init;
    }

    public bool AverageSpeedRestricted {
        get;
        init;
    }

    public decimal MaxSpeed {
        get;
        init;
    }

    public bool MaxSpeedRestricted {
        get;
        init;
    }

    public bool GeometryProcessed {
        get;
        init;
    }

    public bool HasDimensionM {
        get;
        init;
    }

    public long DurationActive {
        get;
        init;
    }

    public long DurationPassice {
        get;
        init;
    }

    public int Lifts {
        get;
        init;
    }

    public bool MyTrack {
        get;
        init;
    }

    public List<TrackPoint> TrackPoints {
        get;
        init;
    }
}