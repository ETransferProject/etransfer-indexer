namespace ETransfer.Indexer;
    
public static class DateTimeHelper
{
    public static long ToUtcMilliSeconds(this DateTime dateTime)
    {
        return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
    }
    
    public static long ToUnixTimeMilliseconds(DateTime value)
    {
        var span = value - DateTime.UnixEpoch;
        return (long) span.TotalMilliseconds;
    }

    public static DateTime FromUnixTimeMilliseconds(long value)
    {
        return DateTime.UnixEpoch.AddMilliseconds(value);
    }
}
