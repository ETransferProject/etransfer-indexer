namespace ETransferIndexer;
    
public static class DateTimeHelper
{
    public static long ToUtcMilliSeconds(this DateTime dateTime)
    {
        return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
    }
}
