namespace WindowsServiceManager.WebGui.Models
{
    public static class Bootstrap
    {
        public static class Icons
        {
            public static string Play
            {
                get
                {
                    return "glyphicon-play";
                }
            }

            public static string Stop
            {
                get
                {
                    return "glyphicon-stop";
                }
            }

            public static string Pause
            {
                get
                {
                    return "glyphicon-pause";
                }
            }

            public static string Refresh
            {
                get
                {
                    return "glyphicon-refresh";
                }
            }
        }

        public static class Tables
        {
            public const string BackGroundWarning = "warning";
            public const string BackGroundChanging = "active";
            public const string BackGroundOk = "success";
        }
    }
}