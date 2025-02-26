namespace iSki2gpx.Converter.Util {
    public class DateTimeUtil {
        /// <summary>
        /// Converts a Unix timestamp to a DateTime object.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp in milliseconds to be converted, represented as a decimal.</param>
        /// <param name="local">A boolean indicating whether to return the local time. If false, returns UTC time. Defaults to false.</param>
        /// <returns>A DateTime object representing the given Unix timestamp.</returns>
        public static DateTime UnixToDateTime( decimal timestamp, bool local = false ) {
            var offset = DateTimeOffset.FromUnixTimeMilliseconds( (long) (timestamp * 1000) );
            return local ? offset.LocalDateTime : offset.UtcDateTime;
        }
    }
}