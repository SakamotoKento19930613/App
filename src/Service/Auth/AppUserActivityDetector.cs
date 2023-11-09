public static class AppUserActivityDetector
{
    public static UserActivityDetector UserActivityDetector { get; private set; }

    static AppUserActivityDetector()
    {
        UserActivityDetector = new UserActivityDetector();
    }
}